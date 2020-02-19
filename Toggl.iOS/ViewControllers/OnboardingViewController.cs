using Toggl.iOS.Extensions;
using UIKit;

namespace Toggl.iOS.ViewControllers
{
    public partial class OnboardingViewController : UIViewController
    {
        public OnboardingViewController() : base("OnboardingViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TogglmanImage.SetAnimatedImage("togglman");
        }
    }
}

