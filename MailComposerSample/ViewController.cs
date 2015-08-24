using System;

using UIKit;
using MessageUI;

namespace MailComposerSample
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			var mailController = new MFMailComposeViewController();
			mailController.SetToRecipients(new[] { "me@example.com" });
			mailController.SetSubject("This seems to work :)");
			mailController.SetMessageBody("Lorem ipsum", false);
			mailController.Finished += (sender, e) => 
			{
				this.DismissViewController (true, null);
			};
			this.PresentViewController(mailController, true, null);
		}
	}
}