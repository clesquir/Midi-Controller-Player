/*
 * Created by SharpDevelop.
 * User: cedric
 * Date: 10/01/2011
 * Time: 12:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Serialization;

namespace MidiForm
{
	[Serializable()]
	[System.Xml.Serialization.XmlInclude(typeof(Audio))]
	[System.Xml.Serialization.XmlInclude(typeof(Video))]
	public abstract class Media {
		public string name = "";
		public string url = "";
		
		public Media() {}
		
		public Media(string name, string url) {
			this.setName(name);
			this.setUrl(url);
		}
		
		public string getName() {
			return this.name;
		}
		
		public void setName(string name) {
			this.name = name;
		}
		
		public void setUrl(string url) {
			this.url = url;
		}
		
		public abstract string getUrl();
		public abstract string print();
	}
	
	[XmlRootAttribute(ElementName="Audio", IsNullable=false)]
	public class Audio : Media {
		
		public Audio() {}
		
		public Audio(string name, string url) : base(name, url) {}
		
		public override string print() {
			return "[AUDIO] " + this.name;
		}
		
		public override string getUrl() {
			return "../../../media/audio files/" + this.url;
		}
	}
	
	[XmlRootAttribute(ElementName="Video", IsNullable=false)]
	public class Video : Media {
		
		public Video() {}
		
		public Video(string name, string url) : base(name, url) {}
		
		public override string print() {
			return "[VIDEO] " + this.name;
		}
		
		public override string getUrl() {
			return "../../../media/video files/" + this.url;
		}
	}
	
}
