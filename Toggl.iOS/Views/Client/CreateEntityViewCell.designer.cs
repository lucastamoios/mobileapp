// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using Foundation;

namespace Toggl.iOS.Views.Client
{
	[Register ("CreateClientViewCell")]
	partial class CreateClientViewCell
	{
		[Outlet]
		UIKit.UILabel TextLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (TextLabel != null) {
				TextLabel.Dispose ();
				TextLabel = null;
			}
		}
	}
}
