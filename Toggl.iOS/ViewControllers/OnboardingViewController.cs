using Toggl.Core.UI.ViewModels;
using Toggl.iOS.Extensions;
using UIKit;

namespace Toggl.iOS.ViewControllers
{
    public partial class OnboardingViewController : ReactiveViewController<OnboardingViewModel>
    {
        public OnboardingViewController(OnboardingViewModel viewModel) : base(viewModel, "OnboardingViewController")
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TogglmanImage.SetAnimatedImage("togglman");
        }
    }
}
