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
		/// The minimum velocity of a Midi button click
		/// </summary>
		private const int VELOCITY_MIN = 0;
		
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
		/// The pitch meaning PLAY
		/// </summary>
		Pitch pitchPlay = Pitch.C4;
		
		/// <summary>
		/// The pitch meaning PREVIOUS
		/// </summary>
		Pitch pitchPrevious = Pitch.B3;
		
		/// <summary>
		/// The pitch meaning STOP
		/// </summary>
		Pitch pitchStop = Pitch.CNeg1;
		
		/// <summary>
		/// The pitch meaning NEXT
		/// </summary>
		Pitch pitchNext = Pitch.CSharp4;
		
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
		/// The window loading the next video to be played
		/// </summary>
		LoadForm loadForm = null;
		
		/// <summary>
		/// The current video being played
		/// </summary>
		Microsoft.DirectX.AudioVideoPlayback.Video currentVideo = null;
		
		/// <summary>
		/// Video to be disposed of when the next one will be played
		/// </summary>
		Microsoft.DirectX.AudioVideoPlayback.Video videoToDispose = null;
		
		/// <summary>
		/// Video loaded and to be played next
		/// </summary>
		Microsoft.DirectX.AudioVideoPlayback.Video loadedVideo = null;

        String lastPlayedVideoUrl = "";

        int lastLoadedIndex = -1;
		
		/// <summary>
		/// A counter keeping the active index
		/// </summary>
		int buttonCounter = 0;
		
		/// <summary>
		/// List of the buttons by step index
		/// </summary>
		Dictionary<int, MarkerButton> markerButtons = new Dictionary<int, MarkerButton>();
		
		/// <summary>
		/// True if the device click only show which button is triggered
		/// False to execute the action related to the button click
		/// </summary>
		bool checkPause = false;
		
		/// <summary>
		/// The setlist ordered by step order
		/// </summary>
		List<Media[]> mediaList = new List<Media[]>();
		
		/// <summary>
		/// The setlist in the order it will be played
		/// </summary>
		Media[][] setlist = null;
		
		public MainForm() {
			InitializeComponent();
			
			//Initialize a videoForm
			this.videoForm = new VideoForm();
			this.videoForm.MouseEnter += new System.EventHandler(Video_MouseEnter);
			this.videoForm.MouseLeave += new System.EventHandler(Video_MouseLeave);
			this.videoForm.panVideo.MouseEnter += new System.EventHandler(Video_MouseEnter);
			this.videoForm.panVideo.MouseLeave += new System.EventHandler(Video_MouseLeave);

            //Initialize the loadForm
            this.loadForm = new LoadForm();
            this.loadForm.Visible = false;
			
			//Initializing the configuration file
			InitializeConfiguration();
			
			//Initializing the MIDI input device and pauses its action
			InitializeInputDevice();
			TbBtnPauseClick(null, null);
			
			//Reading the default setlist XML
			ReadSetlistFile(this.xmlSetlistFilename);
			
			//Initialize the default setlist
			InitializeSetlist();
		}

        public void removeInputDevice() {
            try {
                if (this.inputDevice != null) {
				    this.inputDevice.StopReceiving();
	                this.inputDevice.Close();
	                this.inputDevice.RemoveAllEventHandlers();
			    }
                this.inputDevice = null;
            } catch(DeviceException) {}
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
			try {
                this.inputDevice = null;
			    if (InputDevice.InstalledDevices.Count == 0) {
				    PrintMessage("No input devices...");
                    return;
			    } else {
                    this.inputDevice = InputDevice.InstalledDevices[0];
                }
                if (this.inputDevice.IsOpen) {
                    this.inputDevice.Close();
                }
                this.inputDevice.Open();
                this.inputDevice.StartReceiving(null);
                this.inputDevice.NoteOn += new InputDevice.NoteOnHandler(this.NoteOn);

                PrintMessage(this.inputDevice.Name);
            } catch (DeviceException) {
                this.removeInputDevice();
                PrintMessage("No input devices...");
            }
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
			
			this.buttonCounter = 0;
			this.mediaList.Clear();
			
			for (var i = 0; i < this.setlist.Length; i++) {
				this.mediaList.Add(this.setlist[i]);
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
			
			var margin = 10;
			var panelWidth = panelButtons.Width - 16;
				
			var steps = this.mediaList;
			//Foreach steps
			for (var j = 0; j < steps.Count; j++) {
					
				//Creating the markerButton corresponding to this button step
				var markerButton = new MarkerButton();
				markerButton.Name = "lblButton" + j;
				markerButton.Location = new System.Drawing.Point(margin, margin + (j * 40));
				markerButton.Size = new System.Drawing.Size(panelWidth - (margin * 2), 30);
				markerButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				markerButton.Text = "";
				//On click, focus the buttons panel (to allow mouse scroll)
				markerButton.Click += new System.EventHandler(panelButtons_Click);
                //On click, change the internal index
                markerButton.Click += new System.EventHandler(ChangeButtonCounter);
				//On double click, execute all actions of the marker button
				markerButton.DoubleClick += new System.EventHandler(ExecuteMarkerButton);
				markerButton.setStepIndex(j);
					
				var actions = steps[j];
				//Write down all the actions for this button/counter
				for (var k = 0; k < actions.Length; k++) {
					markerButton.Text += actions[k].print() + "\n";
				}
					
				panelButtons.Controls.Add(markerButton);
					
				//Add the button to the list of buttons
				markerButtons.Add(j, markerButton);
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
				
				/**
				 * When Pause is ON, just play the test_sound
				 */
				if (checkPause) {
					if (msg.Velocity > VELOCITY_MIN) {
						this.doPlay();
					}
				} else {
				    /**
				     * If the button means NEXT, put the cursor on the next marker
				     */
				    if (msg.Pitch == this.pitchPrevious) {
					    if (msg.Velocity > VELOCITY_MIN) {
						    this.doPrevious();
					    }
				
				    /**
				     * If the button means STOP, stop everything
				     */
                    } else if (msg.Pitch == this.pitchStop) {
					    if (msg.Velocity > VELOCITY_MIN) {
                            this.doStop();
					    }
				
				    /**
				     * If the button means NEXT, put the cursor on the next marker
				     */
				    } else if (msg.Pitch == this.pitchNext) {
					    if (msg.Velocity > VELOCITY_MIN) {
                            this.doNext();
					    }

                    /**
                     * If the button means PLAY, play the media marker
                     */
				    } else if (msg.Pitch == this.pitchPlay) {
				        if (msg.Velocity > VELOCITY_MIN) {
                            //Selecting ON ACTION
					        markerButtons[buttonCounter].BackColor = System.Drawing.ColorTranslator.FromHtml("#a1f73b");
                            this.doPlay();
				        } else if (msg.Velocity == VELOCITY_MIN) {
					        this.doNext();
				        }
                    }
                }
    		}
        }

        public void doPrevious() {
            /**
			 * Decrement the counter of the first button or restart
			 */
			buttonCounter--;
			if (buttonCounter < 0) {
				buttonCounter = this.mediaList.Count - 1;
			}
			
			SetColorMarker();
        }

        public void doNext() {
            /**
			 * Increment the counter or restart
			 */
			buttonCounter++;
			if (buttonCounter >= this.mediaList.Count) {
				buttonCounter = 0;
			}
			
			SetColorMarker();
        }

        public void doStop() {
            this.engine.StopAllSounds();
            this.DisposeAllVideos();
			this.videoForm.Hide();
        }

        public void doPlay() {
            if (checkPause) {
                PlayMedia(this.test_sound);
            } else {
                //Play the selected item
                this.PlayMediaListByIndex(this.buttonCounter);
            }
        }

        public void PlayMediaListByIndex(int stepIndex) {
            var actions = this.mediaList[stepIndex];
				
			// Execute each action at this position
			for (var i = 0; i < actions.Length; i++) {
				Media selectedItem = actions[i];
				
				PrintMessage(selectedItem.print());
				
				//Playing the media
				PlayMedia(selectedItem);
			}
        }
		
		public void PlayMedia(Media media) {
			try {
				if (media is Audio) {
					//Playing the sound
					this.engine.Play2D(media.getUrl(), false);
					
				} else if (media is Video) {
					//Taking note of the video before it was replaced
					if (this.currentVideo != null && this.lastPlayedVideoUrl != media.getUrl()) {
                        this.videoToDispose = this.currentVideo;
					}

                    if (this.loadedVideo != null) {
                        this.currentVideo = this.loadedVideo;
                    } else {
					    //Playing the video
					    this.currentVideo = Microsoft.DirectX.AudioVideoPlayback.Video.FromFile(media.getUrl(), false);
                        this.currentVideo.HideCursor();
                    }
					PlayFullScreenVideo(this.lastPlayedVideoUrl == media.getUrl());

                    this.lastPlayedVideoUrl = media.getUrl();
				}
			} catch (Microsoft.DirectX.DirectXException) {
				//Video file not existing
			}
		}

        public void LoadMediaListByIndex(int stepIndex) {
            if (this.lastLoadedIndex != stepIndex) {
                //Dispose of loadedVideo if not being played
                if (this.loadedVideo != null && this.loadedVideo != this.currentVideo) {
                    this.DisposeVideo(ref this.loadedVideo);
                }
                this.loadedVideo = null;

                var actions = this.mediaList[stepIndex];
				
			    // Execute each action at this position
			    for (var i = 0; i < actions.Length; i++) {
				    Media selectedItem = actions[i];
				
				    //Load the media
				    LoadMedia(selectedItem);
			    }

                this.lastLoadedIndex = stepIndex;
            }
        }

        public void LoadMedia(Media media) {
            try {
				if (media is Audio) {
					//Loads the sound
					this.engine.Play2D(media.getUrl(), false, true);
					
				} else if (media is Video) {
					//Loads the video
					this.loadedVideo = Microsoft.DirectX.AudioVideoPlayback.Video.FromFile(media.getUrl(), false);
                    this.loadedVideo.HideCursor();
                    this.loadedVideo.Owner = this.loadForm.panVideo;
                    this.loadedVideo.StopWhenReady();
				}
			} catch (Microsoft.DirectX.DirectXException) {
				//Video file not existing
			}
        }

        public void SetFullScreenForm(Form form) {
            //Checks if the form is opened
            bool isOpen = false;
            foreach (Form OpenForm in Application.OpenForms) {
                if (OpenForm.GetType() == form.GetType()) {
                    isOpen = true;
                }
            }
            if (isOpen == false || form.Visible == false) {
                //Centers the form
			    form.Width = Screen.PrimaryScreen.Bounds.Width;
			    form.Height = Screen.PrimaryScreen.Bounds.Height;
			    form.Left = 0;
			    form.Top = 0;
			    form.Show();
            }
        }

        public void CenterVideo() {
            //Resizes video to its maximum size
			double prop = ((double) this.currentVideo.DefaultSize.Width / (double) this.currentVideo.DefaultSize.Height);
            int width = (int) (this.videoForm.Size.Height * prop);
            int height = this.videoForm.Size.Height;

            this.videoForm.panVideo.Size = new Size(width, height);
            this.videoForm.panVideo.MinimumSize = new Size(width, height);
            this.videoForm.panVideo.MaximumSize = new Size(width, height);

            //Resizes loadForm as well to avoid changing video size when loading new video in memory
            this.loadForm.panVideo.Size = new Size(width, height);
            this.loadForm.panVideo.MinimumSize = new Size(width, height);
            this.loadForm.panVideo.MaximumSize = new Size(width, height);
                
            //Centers video into screen
            int left = (this.videoForm.Width / 2 - this.videoForm.panVideo.Size.Width / 2);
            if (this.videoForm.panVideo.Left != left) {
			    this.videoForm.panVideo.Left = (this.videoForm.Width / 2 - this.videoForm.panVideo.Size.Width / 2);
            }

            int top = (this.videoForm.Height / 2 - this.videoForm.panVideo.Size.Height / 2);
            if (this.videoForm.panVideo.Top != top) {
			    this.videoForm.panVideo.Top = (this.videoForm.Height / 2 - this.videoForm.panVideo.Size.Height / 2);
            }
        }

		public void PlayFullScreenVideo(Boolean restart = false) {

			this.SetFullScreenForm(this.videoForm);

            //Lock size of video before playing it - because setOwner changes size of video
            this.CenterVideo();

            this.currentVideo.Owner = this.videoForm.panVideo;
			
            if (restart) {
                this.currentVideo.CurrentPosition = 0;
                if (this.currentVideo.Playing == false) {
                    this.currentVideo.Play();
                }
            } else {
			    this.currentVideo.Play();
            }

            this.DisposeVideo(ref this.videoToDispose);
		}

        void DisposeAllVideos() {
            this.DisposeVideo(ref this.currentVideo);
            this.DisposeVideo(ref this.videoToDispose);
            this.DisposeVideo(ref this.loadedVideo);
        }

        /// <summary>
        /// Dispose of the video if not null
        /// </summary>
        /// <param name="video"></param>
        public void DisposeVideo(ref Microsoft.DirectX.AudioVideoPlayback.Video video) {
            if (video != null && video.Disposed == false) {
                if (video.Playing == true) {
                    video.Stop();
                }
			    video.Dispose();
                video = null;
            }
        }
		
		/// <summary>
		/// Executes the marker button corresponding to sender
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ExecuteMarkerButton(object sender, System.EventArgs e) {
			if (sender is MarkerButton) {
                this.doPlay();
			}
		}
		
		public void ChangeButtonCounter(object sender, System.EventArgs e) {
			if (sender is MarkerButton) {
				MarkerButton markerButton = (MarkerButton) sender;
				buttonCounter = markerButton.getStepIndex();
				SetColorMarker();
			}
		}
		
		public void SetColorMarker() {
            //Always display the button in the scroll view
            this.panelButtons.ScrollControlIntoView(markerButtons[buttonCounter]);

			var steps = this.mediaList;

			//Foreach steps
			for (var j = 0; j < steps.Count; j++) {
				MarkerButton markerButton = markerButtons[j];
					
				if (markerButton != null) {
					if (buttonCounter == j) {
						markerButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#84ce2c");

                        /**
                         * Loads next media list
                         */
                        this.LoadMediaListByIndex(buttonCounter);
					} else {
						markerButton.BackColor = System.Drawing.SystemColors.Control;
					}
				}
			}
		}
	}
}
