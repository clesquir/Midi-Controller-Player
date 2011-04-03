/*
 * Created by SharpDevelop.
 * User: cedric
 * Date: 06/01/2011
 * Time: 10:20 PM
 */
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;

using Midi;
using IrrKlang;

namespace MidiForm
{
	public partial class MainForm : Form {
		
		/// <summary>
		/// The maximum velocity of a Midi button click
		/// </summary>
		private const int VELOCITY_MAX = 127;
		
		/// <summary>
		/// The configuration filename
		/// </summary>
		private const string INIT_FILE_NAME = "configuration.xml";
		
		/// <summary>
		/// Default 
		/// </summary>
		private const string DEFAULT_XML_SETLIST_FILE = "setlist.xml";
		
		private const string TEST_SOUND_NAME = "test.wav";
		
		XMLConfig xmlConfiguration = null;
		
		/// <summary>
		/// The filename to load the XML from
		/// </summary>
		string xmlSetlistFilename = "";
		
		Audio test_sound = null;
		
		/// <summary>
		/// The list of the buttons (each note is a button)
		/// </summary>
		Pitch[] deviceButtons = {
			Pitch.C4,
			Pitch.CSharp4
		};
		
		/// <summary>
		/// The device sending a MIDI signal
		/// </summary>
		InputDevice inputDevice = null;
		
		/// <summary>
		/// The sound engine
		/// </summary>
		ISoundEngine engine = null;
		
		/// <summary>
		/// The window containing the videos
		/// </summary>
		VideoForm videoForm = null;
		
		/// <summary>
		/// The current video being played
		/// </summary>
		Microsoft.DirectX.AudioVideoPlayback.Video currentVideo = null;
		
		/// <summary>
		/// A counter keeping the active index for each button
		/// </summary>
		List<int> buttonCounter = new List<int>();
		
		/// <summary>
		/// List of the buttons
		/// First index == Button index
		/// Second index == Step index
		/// </summary>
		Dictionary<int, Dictionary<int, MarkerButton>> markerButtons = new Dictionary<int, Dictionary<int, MarkerButton>>();
		
		/// <summary>
		/// True if the device click only show which button is triggered
		/// False to execute the action related to the button click
		/// </summary>
		bool checkPause = false;
		
		/// <summary>
		/// The setlist ordered by button and step order
		/// </summary>
		Dictionary<Pitch, List<Media[]>> setlistByPitch = new Dictionary<Pitch, List<Media[]>>();
		
		/// <summary>
		/// The pitch meaning STOP
		/// </summary>
		Pitch pitchStop = Pitch.CNeg1;
		
		/// <summary>
		/// The setlist in the order it will be played
		/// </summary>
		Media[][] setlist = null;
		
		public MainForm() {
			InitializeComponent();
			
			//Initializing the configuration file
			InitializeConfiguration();
			
			//Initializing the MIDI input device and pauses its action
			InitializeInputDevice();
			TbBtnPauseClick(null, null);
			
			//Reading the default setlist XML
			ReadSetlistFile(this.xmlSetlistFilename);
			
			//Initialize the default setlist
			InitializeSetlist();
			
			//Initialize a videoform
			this.videoForm = new VideoForm();
			this.videoForm.MouseEnter += new System.EventHandler(Video_MouseEnter);
			this.videoForm.MouseLeave += new System.EventHandler(Video_MouseLeave);
		}
		
		public void InitializeConfiguration() {
			try {
				this.xmlConfiguration = new XMLConfig(INIT_FILE_NAME, false);
				
			} catch(Exception) {
				//Create the config file
				this.xmlConfiguration = new XMLConfig(INIT_FILE_NAME, true);
				this.xmlConfiguration.Settings["lastsetlistfile"].Value = DEFAULT_XML_SETLIST_FILE;
				this.xmlConfiguration.Save(INIT_FILE_NAME);
			}
				
			this.xmlSetlistFilename = this.xmlConfiguration.Settings["lastsetlistfile"].Value;
		}
		
		/// <summary>
		/// Initialize a MIDI input device and add the noteon event
		/// </summary>
		public void InitializeInputDevice() {
			this.inputDevice = null;
			if (InputDevice.InstalledDevices.Count == 0) {
				PrintMessage("No input devices...");
                return;
			} else {
                this.inputDevice = InputDevice.InstalledDevices[0];
            }
			
            PrintMessage(this.inputDevice.Name);
            
            this.inputDevice.Open();
            this.inputDevice.StartReceiving(null);
            this.inputDevice.NoteOn += new InputDevice.NoteOnHandler(this.NoteOn);
		}
		
		/// <summary>
		/// Reads the filename and creates the setlist from
		/// </summary>
		/// <param name="filename"></param>
		void ReadSetlistFile(string filename) {
			//Loads a new setlist
			try {
				XmlSerializer SerializerObj = new XmlSerializer(typeof(Media[][]));
				TextReader ReaderFileStream = new StreamReader(filename);
				this.setlist = (Media[][])SerializerObj.Deserialize(ReaderFileStream);
				ReaderFileStream.Close();
				
				//Saving the last file loaded in configuration file
				this.xmlConfiguration.Settings["lastsetlistfile"].Value = filename;
				this.xmlConfiguration.Save(INIT_FILE_NAME);
            }
            catch (IOException)
            {}
		}
		
		/// <summary>
		/// Saves the current setlist in the filepath specified
		/// </summary>
		/// <param name="filepath"></param>
		void SaveSetlistFile(string filepath) {
			try {
				/**
				 * Saving the setlist to a XML
				 */
            	XmlSerializer SerializerObj = new XmlSerializer(typeof(Media[][]));
            	TextWriter WriteFileStream = new StreamWriter(filepath);
				SerializerObj.Serialize(WriteFileStream, setlist);
				WriteFileStream.Close();
            }
            catch (IOException)
            {}
		}
		
		/// <summary>
		/// Initialize the setlist ordered by Pitch
		/// Initialize the sounds engine
		/// Initialize the step labels
		/// Set the color marker to the beginning
		/// </summary>
		public void InitializeSetlist() {
			
			this.buttonCounter.Clear();
			this.setlistByPitch.Clear();
			
			var buttonPointer = 0;
			for (var i = 0; i < this.setlist.Length; i++) {
				
				this.buttonCounter.Add(0);
				
				if (!this.setlistByPitch.ContainsKey(this.deviceButtons[buttonPointer])) {
					List<Media[]> action = new List<Media[]>();
					action.Add(this.setlist[i]);
					this.setlistByPitch.Add(this.deviceButtons[buttonPointer], action);
				} else {
					this.setlistByPitch[this.deviceButtons[buttonPointer]].Add(this.setlist[i]);
				}
				
				buttonPointer++;
				if (buttonPointer >= this.deviceButtons.Length) {
					buttonPointer = 0;
				}
			}
			
			InitializeSoundEngine();
			InitializeActionComponents();
			SetColorMarker();
		}
		
		/// <summary>
		/// Creates an instance of the sound engine
		/// Removes any sound source that may exist
		/// Keeps all sounds in memory
		/// </summary>
		public void InitializeSoundEngine() {
			this.engine = new ISoundEngine();
			
			this.engine.RemoveAllSoundSources();
			
			//Initializing the test sound
			this.test_sound = new Audio("TEST", TEST_SOUND_NAME);
			this.engine.Play2D(this.test_sound.getUrl(), false, true);
			
			//Foreach buttons
			for (var i = 0; i < this.deviceButtons.Length; i++) {
				
				var steps = this.setlistByPitch[this.deviceButtons[i]];
				//Foreach steps
				for (var j = 0; j < steps.Count; j++) {
					
					Media[] actions = steps[j];
					//Foreach actions
					for (var k = 0; k < actions.Length; k++) {
						if (actions[k] is Audio) {
							this.engine.Play2D(actions[k].getUrl(), false, true);
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Initialize all the labels corresponding to the steps and the buttons
		/// </summary>
		public void InitializeActionComponents() {
			this.SuspendLayout();
			
			//Clear the labels inside the panel buttons
			panelButtons.Controls.Clear();
			
			//Clears the button list
			markerButtons.Clear();
			
			var margin = 25;
			var panelWidth = panelButtons.Width - 16;
			
			//Foreach buttons
			for (var i = 0; i < this.deviceButtons.Length; i++) {
				
				var labelButton = new System.Windows.Forms.Label();
				labelButton.Name = "lblButton" + i;
				labelButton.Location = new System.Drawing.Point(i * (panelWidth / this.deviceButtons.Length) + margin, 0);
				labelButton.Size = new System.Drawing.Size((panelWidth / this.deviceButtons.Length) - (margin * 2), 15);
				labelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				labelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				labelButton.Text = "BUTTON " + (i+1);
				panelButtons.Controls.Add(labelButton);
				
				var steps = this.setlistByPitch[this.deviceButtons[i]];
				//Foreach steps
				for (var j = 0; j < steps.Count; j++) {
					
					//Creating the markerButton corresponding to this button step
					var markerButton = new MarkerButton();
					markerButton.Name = "lblButton" + i + "_" + j;
					markerButton.Location = new System.Drawing.Point(i * (panelWidth / this.deviceButtons.Length) + margin, 24 + (j * 40));
					markerButton.Size = new System.Drawing.Size((panelWidth / this.deviceButtons.Length) - (margin * 2), 30);
					markerButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					markerButton.Text = "";
					//On click, change the internal index
					markerButton.Click += new System.EventHandler(ChangeButtonCounter);
					//On double click, execute all actions of the marker button
					markerButton.DoubleClick += new System.EventHandler(ExecuteMarkerButton);
					markerButton.setButtonIndex(i);
					markerButton.setStepIndex(j);
					
					var actions = steps[j];
					//Write down all the actions for this button/counter
					for (var k = 0; k < actions.Length; k++) {
						markerButton.Text += actions[k].print() + "\n";
					}
					
					panelButtons.Controls.Add(markerButton);
					
					//Add the button to the list of buttons
					if (!markerButtons.ContainsKey(i)) {
						markerButtons.Add(i, new Dictionary<int, MarkerButton>());
					}
					markerButtons[i].Add(j, markerButton);
				}
			}
			this.ResumeLayout(false);
		}
		
		public void PrintMessage(string msg) {
			txtMessages.Text = msg + "\r\n" + txtMessages.Text;
		}
		
		delegate void NoteOnCallback(NoteOnMessage msg);
        
        public void NoteOn(NoteOnMessage msg) {
			/**
			 * Keeping the control from cross-threading
			 */
    		if (txtMessages.InvokeRequired) {
    			NoteOnCallback d = new NoteOnCallback(NoteOn);
				txtMessages.Invoke(d, new object[] { msg });
    		} else {
				PrintMessage("ON / " + msg.Pitch + " / " + msg.Velocity);
				
				if (msg.Velocity == VELOCITY_MAX) {
					/**
					 * When Pause is ON, just play the test_sound
					 */
					if (checkPause) {
						PlayMedia(this.test_sound);
						return;
					}
					
					/**
					 * If the button means STOP, stop everything
					 */
					if (msg.Pitch == this.pitchStop) {
						TbBtnStopClick(null, null);
						return;
					}
				}
				
				/**
				 * Which button is selected
				 */
				int selectedButton = Array.BinarySearch(this.deviceButtons, msg.Pitch);
				
				if (selectedButton == -1) {
					return;
				}
				
				if (msg.Velocity == VELOCITY_MAX) {
					
					var actions = this.setlistByPitch[msg.Pitch][buttonCounter[selectedButton]];
					
					// Execute each action at this position
					for (var i = 0; i < actions.Length; i++) {
						Media selectedItem = actions[i];
						
						PrintMessage(selectedItem.print());
						
						//Playing the media
						PlayMedia(selectedItem);
					}
					
					//Selecting ON ACTION
					markerButtons[selectedButton][buttonCounter[selectedButton]].BackColor = System.Drawing.Color.GreenYellow;
				} else {
					/**
					 * Increment the counter or restart
					 */
					buttonCounter[selectedButton]++;
					if (buttonCounter[selectedButton] >= this.setlistByPitch[msg.Pitch].Count) {
						buttonCounter[selectedButton] = 0;
					}
					
					SetColorMarker();
				}
    		}
        }
		
		public void PlayMedia(Media media) {
			try {
				if (media is Audio) {
					//Playing the sound
					this.engine.Play2D(media.getUrl(), false);
					
				} else if (media is Video) {
					//If a video is initialize, destroy it
					if (this.currentVideo != null) {
						this.currentVideo.Stop();
						this.currentVideo.Dispose();
					}
					
					//Playing the video
					Microsoft.DirectX.AudioVideoPlayback.Video video = new Microsoft.DirectX.AudioVideoPlayback.Video(media.getUrl());
					this.currentVideo = video;
					PlayFullScreenVideo();
				}
			} catch (Microsoft.DirectX.DirectXException) {
				//Video file not existing
			}
		}
		
		public void PlayFullScreenVideo() {
			this.currentVideo.Owner = this.videoForm.panVideo;
			
			//Centers the video window
			this.videoForm.Width = Screen.PrimaryScreen.Bounds.Width;
			this.videoForm.Height = Screen.PrimaryScreen.Bounds.Height;
			this.videoForm.Left = 0;
			this.videoForm.Top = 0;
			this.videoForm.Show();
			
			//Resizes the video and centers it
			double prop = ((double)this.currentVideo.Size.Width / (double)this.currentVideo.Size.Height);
			this.videoForm.panVideo.Size = new Size(
				(int) (this.videoForm.Size.Height * prop),
				this.videoForm.Size.Height
			);
			this.videoForm.panVideo.Left = (this.videoForm.Width / 2 - this.videoForm.panVideo.Width / 2);
			this.videoForm.panVideo.Top = (this.videoForm.Height / 2 - this.videoForm.panVideo.Height / 2);
			
			this.currentVideo.HideCursor();
			this.currentVideo.Play();
		}
		
		/// <summary>
		/// Executes the marker button corresponding to sender
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ExecuteMarkerButton(object sender, System.EventArgs e) {
			if (sender is MarkerButton) {
				MarkerButton markerButton = (MarkerButton) sender;
				var actions = this.setlistByPitch[this.deviceButtons[markerButton.getButtonIndex()]][markerButton.getStepIndex()];
				
				// Execute each action at this position
				for (var i = 0; i < actions.Length; i++) {
					Media selectedItem = actions[i];
					
					PrintMessage(selectedItem.print());
					
					//Playing the media
					PlayMedia(selectedItem);
				}
			}
		}
		
		public void ChangeButtonCounter(object sender, System.EventArgs e) {
			if (sender is MarkerButton) {
				MarkerButton markerButton = (MarkerButton) sender;
				buttonCounter[markerButton.getButtonIndex()] = markerButton.getStepIndex();
				SetColorMarker();
			}
		}
		
		public void SetColorMarker() {
			//Foreach buttons
			for (var i = 0; i < this.deviceButtons.Length; i++) {
				
				var steps = this.setlistByPitch[this.deviceButtons[i]];
				//Foreach steps
				for (var j = 0; j < steps.Count; j++) {
					
					MarkerButton markerButton = markerButtons[i][j];
					
					if (markerButton != null) {
						if (buttonCounter[i] == j) {
							markerButton.BackColor = System.Drawing.Color.Maroon;
							markerButton.ForeColor = System.Drawing.Color.White;
						} else {
							markerButton.BackColor = System.Drawing.SystemColors.Control;
							markerButton.ForeColor = System.Drawing.Color.Black;
						}
					}
				}
			}
		}
	}
}
