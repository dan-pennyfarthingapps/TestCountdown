using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestCountdown
{
	public partial class TestCountdownViewController : UIViewController
	{
		public TestCountdownViewController () : base ("TestCountdownViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.btnStart.TouchUpInside += (object sender, EventArgs e) => Countdown();
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		private void Countdown() {
			UIView countdownView = new UIView(this.View.Bounds);
			UILabel number = new UILabel(RectangleF.FromLTRB(40.0f, 40.0f, 5.0f, 5.0f));
			number.Text = "5";
			countdownView.Add(number);

			this.View.AddSubview(countdownView);

		}
	}
}

