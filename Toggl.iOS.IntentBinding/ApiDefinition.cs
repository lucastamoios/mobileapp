using System;
using Foundation;
using Intents;
using ObjCRuntime;

namespace Toggl.iOS.Intents
{
	// @interface ContinueTimerIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface ContinueTimerIntent
	{
	}

	// @protocol ContinueTimerIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface ContinueTimerIntentHandling
	{
		// @required -(void)handleContinueTimer:(ContinueTimerIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ContinueTimerIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleContinueTimer:completion:")]
		void HandleContinueTimer (ContinueTimerIntent intent, Action<ContinueTimerIntentResponse> completion);

		// @optional -(void)confirmContinueTimer:(ContinueTimerIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ContinueTimerIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmContinueTimer:completion:")]
		void ConfirmContinueTimer (ContinueTimerIntent intent, Action<ContinueTimerIntentResponse> completion);
	}

	// @interface ContinueTimerIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface ContinueTimerIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(ContinueTimerIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (ContinueTimerIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successWithEntryDescriptionIntentResponseWithEntryDescription:(NSString * _Nonnull)entryDescription __attribute__((swift_name("successWithEntryDescription(_:)")));
		[Static]
		[Export ("successWithEntryDescriptionIntentResponseWithEntryDescription:")]
		ContinueTimerIntentResponse SuccessWithEntryDescriptionIntentResponseWithEntryDescription (string entryDescription);

		// @property (readwrite, copy, nonatomic) NSString * _Nullable entryDescription;
		[NullAllowed, Export ("entryDescription")]
		string EntryDescription { get; set; }

		// @property (readonly, nonatomic) ContinueTimerIntentResponseCode code;
		[Export ("code")]
		ContinueTimerIntentResponseCode Code { get; }
	}

	// @interface ShowReportIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface ShowReportIntent
	{
	}

	// @protocol ShowReportIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface ShowReportIntentHandling
	{
		// @required -(void)handleShowReport:(ShowReportIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ShowReportIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleShowReport:completion:")]
		void HandleShowReport (ShowReportIntent intent, Action<ShowReportIntentResponse> completion);

		// @optional -(void)confirmShowReport:(ShowReportIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ShowReportIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmShowReport:completion:")]
		void ConfirmShowReport (ShowReportIntent intent, Action<ShowReportIntentResponse> completion);
	}

	// @interface ShowReportIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface ShowReportIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(ShowReportIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (ShowReportIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// @property (readonly, nonatomic) ShowReportIntentResponseCode code;
		[Export ("code")]
		ShowReportIntentResponseCode Code { get; }
	}

	// @interface ShowReportPeriodIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface ShowReportPeriodIntent
	{
		// @property (assign, readwrite, nonatomic) ShowReportPeriodReportPeriod period;
		[Export ("period", ArgumentSemantic.Assign)]
		ShowReportPeriodReportPeriod Period { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable workspace;
		[NullAllowed, Export ("workspace", ArgumentSemantic.Copy)]
		INObject Workspace { get; set; }
	}

	// @protocol ShowReportPeriodIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface ShowReportPeriodIntentHandling
	{
		// @required -(void)handleShowReportPeriod:(ShowReportPeriodIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ShowReportPeriodIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleShowReportPeriod:completion:")]
		void HandleShowReportPeriod (ShowReportPeriodIntent intent, Action<ShowReportPeriodIntentResponse> completion);

		// @optional -(void)confirmShowReportPeriod:(ShowReportPeriodIntent * _Nonnull)intent completion:(void (^ _Nonnull)(ShowReportPeriodIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmShowReportPeriod:completion:")]
		void ConfirmShowReportPeriod (ShowReportPeriodIntent intent, Action<ShowReportPeriodIntentResponse> completion);
	}

	// @interface ShowReportPeriodIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface ShowReportPeriodIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(ShowReportPeriodIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (ShowReportPeriodIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successIntentResponseWithPeriod:(ShowReportPeriodReportPeriod)period __attribute__((swift_name("success(period:)")));
		[Static]
		[Export ("successIntentResponseWithPeriod:")]
		ShowReportPeriodIntentResponse SuccessIntentResponseWithPeriod (ShowReportPeriodReportPeriod period);

		// @property (assign, readwrite, nonatomic) ShowReportPeriodReportPeriod period;
		[Export ("period", ArgumentSemantic.Assign)]
		ShowReportPeriodReportPeriod Period { get; set; }

		// @property (readonly, nonatomic) ShowReportPeriodIntentResponseCode code;
		[Export ("code")]
		ShowReportPeriodIntentResponseCode Code { get; }
	}

	// @interface StartTimerFromClipboardIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface StartTimerFromClipboardIntent
	{
		// @property (readwrite, copy, nonatomic) INObject * _Nullable workspace;
		[NullAllowed, Export ("workspace", ArgumentSemantic.Copy)]
		INObject Workspace { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable billable;
		[NullAllowed, Export ("billable", ArgumentSemantic.Copy)]
		INObject Billable { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable projectId;
		[NullAllowed, Export ("projectId", ArgumentSemantic.Copy)]
		INObject ProjectId { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable taskId;
		[NullAllowed, Export ("taskId", ArgumentSemantic.Copy)]
		INObject TaskId { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray<INObject *> * _Nullable tags;
		[NullAllowed, Export ("tags", ArgumentSemantic.Copy)]
		INObject[] Tags { get; set; }
	}

	// @protocol StartTimerFromClipboardIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface StartTimerFromClipboardIntentHandling
	{
		// @required -(void)handleStartTimerFromClipboard:(StartTimerFromClipboardIntent * _Nonnull)intent completion:(void (^ _Nonnull)(StartTimerFromClipboardIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleStartTimerFromClipboard:completion:")]
		void HandleStartTimerFromClipboard (StartTimerFromClipboardIntent intent, Action<StartTimerFromClipboardIntentResponse> completion);

		// @optional -(void)confirmStartTimerFromClipboard:(StartTimerFromClipboardIntent * _Nonnull)intent completion:(void (^ _Nonnull)(StartTimerFromClipboardIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmStartTimerFromClipboard:completion:")]
		void ConfirmStartTimerFromClipboard (StartTimerFromClipboardIntent intent, Action<StartTimerFromClipboardIntentResponse> completion);
	}

	// @interface StartTimerFromClipboardIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface StartTimerFromClipboardIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(StartTimerFromClipboardIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (StartTimerFromClipboardIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// @property (readonly, nonatomic) StartTimerFromClipboardIntentResponseCode code;
		[Export ("code")]
		StartTimerFromClipboardIntentResponseCode Code { get; }
	}

	// @interface StartTimerIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface StartTimerIntent
	{
		// @property (readwrite, copy, nonatomic) INObject * _Nullable workspace;
		[NullAllowed, Export ("workspace", ArgumentSemantic.Copy)]
		INObject Workspace { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable entryDescription;
		[NullAllowed, Export ("entryDescription")]
		string EntryDescription { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable billable;
		[NullAllowed, Export ("billable", ArgumentSemantic.Copy)]
		INObject Billable { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable projectId;
		[NullAllowed, Export ("projectId", ArgumentSemantic.Copy)]
		INObject ProjectId { get; set; }

		// @property (readwrite, copy, nonatomic) INObject * _Nullable taskId;
		[NullAllowed, Export ("taskId", ArgumentSemantic.Copy)]
		INObject TaskId { get; set; }

		// @property (readwrite, copy, nonatomic) NSArray<INObject *> * _Nullable tags;
		[NullAllowed, Export ("tags", ArgumentSemantic.Copy)]
		INObject[] Tags { get; set; }
	}

	// @protocol StartTimerIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface StartTimerIntentHandling
	{
		// @required -(void)handleStartTimer:(StartTimerIntent * _Nonnull)intent completion:(void (^ _Nonnull)(StartTimerIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleStartTimer:completion:")]
		void HandleStartTimer (StartTimerIntent intent, Action<StartTimerIntentResponse> completion);

		// @optional -(void)confirmStartTimer:(StartTimerIntent * _Nonnull)intent completion:(void (^ _Nonnull)(StartTimerIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmStartTimer:completion:")]
		void ConfirmStartTimer (StartTimerIntent intent, Action<StartTimerIntentResponse> completion);
	}

	// @interface StartTimerIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface StartTimerIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(StartTimerIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (StartTimerIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// @property (readonly, nonatomic) StartTimerIntentResponseCode code;
		[Export ("code")]
		StartTimerIntentResponseCode Code { get; }
	}

	// @interface StopTimerIntent : INIntent
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntent))]
	interface StopTimerIntent
	{
	}

	// @protocol StopTimerIntentHandling <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[Protocol]
	[BaseType (typeof(NSObject))]
	interface StopTimerIntentHandling
	{
		// @required -(void)handleStopTimer:(StopTimerIntent * _Nonnull)intent completion:(void (^ _Nonnull)(StopTimerIntentResponse * _Nonnull))completion __attribute__((swift_name("handle(intent:completion:)")));
		[Abstract]
		[Export ("handleStopTimer:completion:")]
		void HandleStopTimer (StopTimerIntent intent, Action<StopTimerIntentResponse> completion);

		// @optional -(void)confirmStopTimer:(StopTimerIntent * _Nonnull)intent completion:(void (^ _Nonnull)(StopTimerIntentResponse * _Nonnull))completion __attribute__((swift_name("confirm(intent:completion:)")));
		[Export ("confirmStopTimer:completion:")]
		void ConfirmStopTimer (StopTimerIntent intent, Action<StopTimerIntentResponse> completion);
	}

	// @interface StopTimerIntentResponse : INIntentResponse
	[Watch (5,0), NoTV, NoMac, iOS (12,0)]
	[BaseType (typeof(INIntentResponse))]
	[DisableDefaultCtor]
	interface StopTimerIntentResponse
	{
		// -(instancetype _Nonnull)initWithCode:(StopTimerIntentResponseCode)code userActivity:(NSUserActivity * _Nullable)userActivity __attribute__((objc_designated_initializer));
		[Export ("initWithCode:userActivity:")]
		[DesignatedInitializer]
		IntPtr Constructor (StopTimerIntentResponseCode code, [NullAllowed] NSUserActivity userActivity);

		// +(instancetype _Nonnull)successIntentResponseWithEntryDescription:(NSString * _Nonnull)entryDescription entryDurationString:(NSString * _Nonnull)entryDurationString __attribute__((swift_name("success(entryDescription:entryDurationString:)")));
		[Static]
		[Export ("successIntentResponseWithEntryDescription:entryDurationString:")]
		StopTimerIntentResponse SuccessIntentResponseWithEntryDescription (string entryDescription, string entryDurationString);

		// +(instancetype _Nonnull)successWithEmptyDescriptionIntentResponseWithEntryDurationString:(NSString * _Nonnull)entryDurationString __attribute__((swift_name("successWithEmptyDescription(entryDurationString:)")));
		[Static]
		[Export ("successWithEmptyDescriptionIntentResponseWithEntryDurationString:")]
		StopTimerIntentResponse SuccessWithEmptyDescriptionIntentResponseWithEntryDurationString (string entryDurationString);

		// @property (readwrite, copy, nonatomic) NSString * _Nullable entryDescription;
		[NullAllowed, Export ("entryDescription")]
		string EntryDescription { get; set; }

		// @property (readwrite, copy, nonatomic) NSString * _Nullable entryDurationString;
		[NullAllowed, Export ("entryDurationString")]
		string EntryDurationString { get; set; }

		// @property (readwrite, copy, nonatomic) NSNumber * _Nullable entryStart;
		[NullAllowed, Export ("entryStart", ArgumentSemantic.Copy)]
		NSNumber EntryStart { get; set; }

		// @property (readwrite, copy, nonatomic) NSNumber * _Nullable entryDuration;
		[NullAllowed, Export ("entryDuration", ArgumentSemantic.Copy)]
		NSNumber EntryDuration { get; set; }

		// @property (readonly, nonatomic) StopTimerIntentResponseCode code;
		[Export ("code")]
		StopTimerIntentResponseCode Code { get; }
	}
}
