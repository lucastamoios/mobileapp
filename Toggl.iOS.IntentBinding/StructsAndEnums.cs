using ObjCRuntime;

namespace Toggl.iOS.Intents
{
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum ContinueTimerIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch,
		FailureNoApiToken = 100,
		SuccessWithEntryDescription
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum ShowReportIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch
	}

	[Introduced (PlatformName.iOS, 12, 0, message: "ShowReportPeriodReportPeriod is deprecated. Please use ReportPeriod instead. You can update this by tapping the warning icon next to this enum in the Intent Definition file")]
	[Deprecated (PlatformName.iOS, 12, 0, message: "ShowReportPeriodReportPeriod is deprecated. Please use ReportPeriod instead. You can update this by tapping the warning icon next to this enum in the Intent Definition file")]
	[Introduced (PlatformName.WatchOS, 5, 0, message: "ShowReportPeriodReportPeriod is deprecated. Please use ReportPeriod instead. You can update this by tapping the warning icon next to this enum in the Intent Definition file")]
	[Deprecated (PlatformName.WatchOS, 5, 0, message: "ShowReportPeriodReportPeriod is deprecated. Please use ReportPeriod instead. You can update this by tapping the warning icon next to this enum in the Intent Definition file")]
	[Native]
	public enum ShowReportPeriodReportPeriod : long
	{
		Unknown = 0,
		Today = 1,
		Yesterday = 2,
		ThisWeek = 3,
		LastWeek = 4,
		ThisMonth = 5,
		LastMonth = 6,
		ThisYear = 7,
		LastYear = 8
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum ShowReportPeriodIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum StartTimerFromClipboardIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch,
		FailureNoApiToken = 100,
		FailureSyncConflict
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum StartTimerIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch,
		FailureNoApiToken = 100,
		FailureSyncConflict
	}

	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Native]
	public enum StopTimerIntentResponseCode : long
	{
		Unspecified = 0,
		Ready,
		ContinueInApp,
		InProgress,
		Success,
		Failure,
		FailureRequiringAppLaunch,
		FailureNoTimerRunning = 100,
		FailureNoApiToken,
		SuccessWithEmptyDescription,
		FailureSyncConflict
	}
}
