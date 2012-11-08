using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestCountdown
{
	public partial class TestCountdownViewController : UIViewController
	{

		private int timerCount;
		private UIView countdownView;

		public TestCountdownViewController () : base ("TestCountdownViewController", null)
		{
			timerCount = 0;
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
			NSTimer timer;

			timer = NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds (1), UpdateTimer);

			countdownView = new UIView(this.View.Bounds);
		
			UIImageView countdownImageView = new UIImageView();
			countdownImageView.AnimationImages = new UIImage[] {
				UIImage.FromBundle("images/5"),
				UIImage.FromBundle("images/4"),
				UIImage.FromBundle("images/3"),
				UIImage.FromBundle("images/2"),
				UIImage.FromBundle("images/1"),
				UIImage.FromBundle("images/go")
			};
			countdownImageView.AnimationRepeatCount = 1;
			countdownImageView.AnimationDuration = 2.0;



			countdownImageView.Frame = new RectangleF(122.5f, 202.5f, 75, 75);


			countdownView.AddSubview(countdownImageView);
			countdownView.BackgroundColor = UIColor.Black;

			this.View.AddSubview(countdownView);

			countdownImageView.StartAnimating();

		}

		[Export ("UpdateTimer")]
		private void UpdateTimer ()
		{
			this.timerCount++; 
			if (this.timerCount >= 2) {
				this.countdownView.RemoveFromSuperview();
			} 
		}
	}
}

