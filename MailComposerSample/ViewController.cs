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

			if (MFMailComposeViewController.CanSendMail)
			{
				var mailController = new MFMailComposeViewController();
				mailController.SetToRecipients(new[] {
						"me@example.com"
					});
				mailController.SetSubject("This seems to work :)");
				mailController.SetMessageBody("Lorem ipsum", false);
				mailController.Finished += (sender, e) =>
				{
					this.DismissViewController(true, null);
				};
				this.PresentViewController(mailController, true, null);
			}
			else
			{
				var alert = UIAlertController.Create("Mail sending disabled", "It seems this device can't send mail!", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
				this.PresentViewController(alert, true, null);
			}
		}
	}
}