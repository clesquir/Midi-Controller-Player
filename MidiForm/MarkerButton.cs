/*
 * Created by SharpDevelop.
 * User: cedric
 * Date: 11/01/2011
 * Time: 5:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MidiForm
{
	/// <summary>
	/// Description of MarkerButton.
	/// </summary>
	public class MarkerButton : System.Windows.Forms.Label {
		
		int buttonIndex = 0;
		int stepIndex = 0;
		
		public MarkerButton() : base() {
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		}
		
		public int getButtonIndex() {
			return this.buttonIndex;
		}
		
		public void setButtonIndex(int buttonIndex) {
			this.buttonIndex = buttonIndex;
		}
		
		public int getStepIndex() {
			return this.stepIndex;
		}
		
		public void setStepIndex(int stepIndex) {
			this.stepIndex = stepIndex;
		}
	}
}
