﻿using Java.Util;
using Toggl.Core;

namespace Toggl.Droid
{
    public sealed class PlatformInfoAndroid : BasePlatformInfo
    {
        public override string TimezoneIdentifier => TimeZone.Default.ID;

        public PlatformInfoAndroid()
            : base("https://support.toggl.com/toggl-timer-for-android/",
                   "https://play.google.com/store/apps/details?id=com.toggl.giskard",
                    Platform.Giskard)
        {
        }
    }
}
