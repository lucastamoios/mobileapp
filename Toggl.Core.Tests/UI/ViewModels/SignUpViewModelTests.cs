using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using FluentAssertions;
using FsCheck.Xunit;
using Microsoft.Reactive.Testing;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Toggl.Core.Analytics;
using Toggl.Core.Models;
using Toggl.Core.Tests.Generators;
using Toggl.Core.Tests.Helpers;
using Toggl.Core.Tests.TestExtensions;
using Toggl.Core.UI.Parameters;
using Toggl.Core.UI.ViewModels;
using Toggl.Networking.Exceptions;
using Toggl.Networking.Network;
using Toggl.Shared;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Toggl.Core.Tests.UI.ViewModels
{
    public sealed class SignUpViewModelTests
    {
        public abstract class SignUpViewModelTest : BaseViewModelWithInputTests<SignUpViewModel, CredentialsParameter>
        {
            protected Email ValidEmail { get; } = Email.From("person@company.com");
            protected Password ValidPassword { get; } = Password.From("123456");

            protected override SignUpViewModel CreateViewModel()
                => new SignUpViewModel(
                    TimeService,
                    PlatformInfo,
                    RxActionFactory,
                    AnalyticsService,
                    UserAccessManager,
                    SchedulerProvider,
                    InteractorFactory,
                    NavigationService,
                    OnboardingStorage,
                    LastTimeUsageStorage,
                    ErrorHandlingService);
        }

        public sealed class TheConstructor : SignUpViewModelTest
        {
            [NUnit.Framework.Theory, LogIfTooSlow]
            [ConstructorData]
            public void ThrowsIfAnyOfTheArgumentsIsNull(
                bool useTimeService,
                bool usePlatformInfo,
                bool userRxActionFactory,
                bool useAnalyticsService,
                bool useUserAccessManager,
                bool useSchedulerProvider,
                bool useInteractorFactory,
                bool useNavigationService,
                bool useOnboardingStorage,
                bool useLastTimeUsageStorage,
                bool useErrorHandlingService)
            {
                Action tryingToConstructWithEmptyParameters =
                    () => new SignUpViewModel(
                        useTimeService ? TimeService : null,
                        usePlatformInfo ? PlatformInfo : null,
                        userRxActionFactory ? RxActionFactory : null,
                        useAnalyticsService ? AnalyticsService : null,
                        useUserAccessManager ? UserAccessManager : null,
                        useSchedulerProvider ? SchedulerProvider : null,
                        useInteractorFactory ? InteractorFactory : null,
                        useNavigationService ? NavigationService : null,
                        useOnboardingStorage ? OnboardingStorage : null,
                        useLastTimeUsageStorage ? LastTimeUsageStorage : null,
                        useErrorHandlingService ? ErrorHandlingService : null);

                tryingToConstructWithEmptyParameters
                    .Should().Throw<ArgumentNullException>();
            }
        }

        public sealed class TheInitializeMethod : SignUpViewModelTest
        {
            [Fact, LogIfTooSlow]
            public async Task FillsTheEmailField()
            {
                var email = Email.From("person@company.com");
                var credentials = CredentialsParameter.With(email, Password.Empty);
                var emailObserver = TestScheduler.CreateObserver<Email>();
                ViewModel.Email.Subscribe(emailObserver);

                await ViewModel.Initialize(credentials);
                TestScheduler.Start();

                var expectedEmails = new[]
                {
                    Email.Empty,
                    email
                };
                emailObserver.Values()
                    .Should()
                    .BeEquivalentTo(expectedEmails);
            }

            [Fact, LogIfTooSlow]
            public async Task FillsThePasswordField()
            {
                var password = Password.From("123");
                var credentials = CredentialsParameter.With(Email.Empty, password);
                var passwordObserver = TestScheduler.CreateObserver<Password>();
                ViewModel.Password.Subscribe(passwordObserver);

                await ViewModel.Initialize(credentials);
                TestScheduler.Start();

                var expectedPasswords = new[]
                {
                    Password.Empty,
                    password
                };
                passwordObserver.Values()
                    .Should()
                    .BeEquivalentTo(expectedPasswords);
            }
        }


        public sealed class ThePasswordVisibleProperty : SignUpViewModelTest
        {
            [Fact, LogIfTooSlow]
            public void StartsWithFalse()
            {
                var observer = TestScheduler.CreateObserver<bool>();
                ViewModel.PasswordVisible.Subscribe(observer);

                TestScheduler.Start();

                observer.Values().Should().BeEquivalentTo(new[] { false });
            }

            [Theory, LogIfTooSlow]
            [InlineData(1, new[] { false, true })]
            [InlineData(2, new[] { false, true, false })]
            public void EmitsTheOppositeValueWhenTogglePasswordVisibilityActionIsExecuted(int count, bool[] expectedPasswordVisibility)
            {
                var observer = TestScheduler.CreateObserver<bool>();
                ViewModel.PasswordVisible.Subscribe(observer);

                ViewModel.TogglePasswordVisibility.ExecuteSequentially(count)
                    .Subscribe();
                TestScheduler.Start();

                observer.Values().Should().BeEquivalentTo(expectedPasswordVisibility);
            }
        }

        public sealed class TheSignUpEnabledProperty : SignUpViewModelTest
        {
            [Fact, LogIfTooSlow]
            public void ReturnsTrueWhenEmailAndPasswordAreValid()
            {
                var observer = TestScheduler.CreateObserver<bool>();
                ViewModel.SignUpEnabled.Subscribe(observer);

                ViewModel.Email.Accept(ValidEmail);
                ViewModel.Password.Accept(ValidPassword);

                TestScheduler.Start();
                observer.Values().Should().BeEquivalentTo(new[] { false, true });
            }

            [Theory]
            [InlineData("not an email", "123")]
            [InlineData("not an email", "1234567")]
            [InlineData("this@is.email", "123")]
            public void ReturnsFalseWhenEmailOrPasswordIsInvalid(string email, string password)
            {
                var observer = TestScheduler.CreateObserver<bool>();
                ViewModel.SignUpEnabled.Subscribe(observer);

                ViewModel.Email.Accept(Email.From(email));
                ViewModel.Password.Accept(Password.From(password));

                TestScheduler.Start();
                observer.Values().Should().BeEquivalentTo(new[] { false });
            }
        }

        public sealed class TheSignUpMethod : SignUpViewModelTest
        {
            [Fact, LogIfTooSlow]
            public void SetsNoEmailErrorIfNoEmailIsEntered()
            {
                var emailErrorObserver = TestScheduler.CreateObserver<string>();
                ViewModel.EmailError.Subscribe(emailErrorObserver);

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                emailErrorObserver.Values().Should().BeEquivalentTo(new[] { "", Resources.NoEmailError });
        }

            [Fact, LogIfTooSlow]
            public void SetsTheInvalidEmailErrorIfInvalidEmailIsEntered()
            {
                var emailErrorObserver = TestScheduler.CreateObserver<string>();
                ViewModel.EmailError.Subscribe(emailErrorObserver);
                ViewModel.Email.Accept(Email.From("not an email"));

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                emailErrorObserver.Values().Should().BeEquivalentTo(new[] { "", Resources.InvalidEmailError });
            }

            [Fact, LogIfTooSlow]
            public void SetsNoPasswordErrorIfNoPasswordIsEntered()
            {
                var passwordErrorObserver = TestScheduler.CreateObserver<string>();
                ViewModel.PasswordError.Subscribe(passwordErrorObserver);

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                passwordErrorObserver.Values().Should().BeEquivalentTo(new[] { "", Resources.NoPasswordError });
            }

            [Fact, LogIfTooSlow]
            public void SetsInvalidPasswordErrorIfInvalidPasswordIsEntered()
            {
                var passwordErrorObserver = TestScheduler.CreateObserver<string>();
                ViewModel.PasswordError.Subscribe(passwordErrorObserver);
                ViewModel.Password.Accept(Password.From("123"));

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                passwordErrorObserver.Values().Should().BeEquivalentTo(new[] { "", Resources.InvalidPasswordError });
            }

            [Theory, LogIfTooSlow]
            [InlineData("", "")]
            [InlineData("not an email", "123")]
            [InlineData("not an email", "1234567")]
            [InlineData("person@company.com", "123")]
            public void DoesNotShowTheTermsAndCountryViewModelIfInvalidCredentialsAreProvided(string email, string password)
            {
                ViewModel.Email.Accept(Email.From(email));
                ViewModel.Password.Accept(Password.From(password));

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                // await NavigationService.DidNotReceive().Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View);
            }

            [Fact, LogIfTooSlow]
            public async Task NavigatesToTheTermsOfServiceViewModelIfValidCredentialsAreProvided()
            {
                ViewModel.Email.Accept(ValidEmail);
                ViewModel.Password.Accept(ValidPassword);

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                // await NavigationService.Received().Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View);
            }

            [Fact, LogIfTooSlow]
            public void DoesNotTryToSignUpIfUserDoesNotAcceptTermsOfService()
            {
                // NavigationService.Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View).Returns(null);

                ViewModel.SignUp.Execute();
                TestScheduler.Start();

                UserAccessManager.DidNotReceive().SignUp(
                    Arg.Any<Email>(),
                    Arg.Any<Password>(),
                    Arg.Any<bool>(),
                    Arg.Any<int>(),
                    Arg.Any<string>());
            }

            [Fact, LogIfTooSlow]
            public void ShowsTheTermsOfServiceViewModelOnlyOnceIfUserAcceptsTheTerms()
            {
                // NavigationService.Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View).Returns(new Country("Latvia", "LV", 70));
                UserAccessManager
                    .SignUp(Arg.Any<Email>(), Arg.Any<Password>(), Arg.Any<bool>(), Arg.Any<int>(), Arg.Any<string>())
                    .Returns(Observable.Throw<Unit>(new Exception()));

                ViewModel.SignUp.ExecuteSequentially(2).Subscribe();
                TestScheduler.Start();

                // NavigationService.Received(1).Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View);
            }

            public sealed class WhenUserAcceptsTheTermsOfService : SignUpViewModelTest
            {
                private static readonly Country country = new Country("Latvia", "LV", 70);

                protected override void AdditionalSetup()
                {
                    base.AdditionalSetup();

                    // NavigationService.Navigate<TermsAndCountryViewModel, Country?>(View).Returns(country);
                }

                protected override void AdditionalViewModelSetup()
                {
                    base.AdditionalViewModelSetup();

                    ViewModel.Email.Accept(ValidEmail);
                    ViewModel.Password.Accept(ValidPassword);
                }

                [Fact, LogIfTooSlow]
                public void SetsIsLoadingToTrue()
                {
                    var observer = TestScheduler.CreateObserver<bool>();
                    ViewModel.IsLoading.Subscribe(observer);
                    ViewModel.Email.Accept(ValidEmail);
                    ViewModel.Password.Accept(ValidPassword);

                    ViewModel.SignUp.Execute();
                    TestScheduler.Start();

                    observer.Values().Should().BeEquivalentTo(new[] { false, true });
                }

                [Fact, LogIfTooSlow]
                public void TriesToSignUp()
                {
                    ViewModel.SignUp.Execute();
                    TestScheduler.Start();

                    UserAccessManager.Received().SignUp(
                        ValidEmail,
                        ValidPassword,
                        true,
                        (int)country.Id,
                        Arg.Any<string>());
                }

                [Fact, LogIfTooSlow]
                public void TracksSignUpEvent()
                {
                    ViewModel.SignUp.Execute();
                    TestScheduler.Start();

                    AnalyticsService.SignUp.Received().Track(AuthenticationMethod.EmailAndPassword);
                }

                public sealed class WhenSignUpSucceeds : SignUpViewModelTest
                {
                    protected override void AdditionalViewModelSetup()
                    {
                        base.AdditionalViewModelSetup();

                        ViewModel.Email.Accept(ValidEmail);
                        ViewModel.Password.Accept(ValidPassword);
                        UserAccessManager
                            .SignUp(Arg.Any<Email>(), Arg.Any<Password>(), Arg.Any<bool>(), Arg.Any<int>(), Arg.Any<string>())
                            .Returns(Observable.Return(Unit.Default));
                        // NavigationService.Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View).Returns(country);
                    }

                    [Property]
                    public void SavesTheTimeOfLastLogin(DateTimeOffset now)
                    {
                        ViewModel.Email.Accept(ValidEmail);
                        ViewModel.Password.Accept(ValidPassword);
                        TimeService.CurrentDateTime.Returns(now);

                        ViewModel.SignUp.Execute();
                        TestScheduler.Start();

                        LastTimeUsageStorage.Received().SetLogin(now);
                    }
                }

                public sealed class WhenSignUpFails : OldSignUpViewModelTests.OldSignUpViewModelTest
                {
                    private void prepareException(Exception exception)
                    => UserAccessManager
                            .SignUp(Arg.Any<Email>(), Arg.Any<Password>(), Arg.Any<bool>(), Arg.Any<int>(), Arg.Any<string>())
                            .Returns(Observable.Throw<Unit>(exception));

                    protected override void AdditionalViewModelSetup()
                    {
                        base.AdditionalViewModelSetup();

                        ViewModel.Initialize(DefaultParameters).Wait();

                        ViewModel.SetEmail(ValidEmail);
                        ViewModel.SetPassword(ValidPassword);

                        // NavigationService.Navigate<TermsAndCountryViewModel, Country?>(ViewModel.View).Returns(country);
                    }

                    [Fact, LogIfTooSlow]
                    public void SetsIsLoadingToFalse()
                    {
                        var observer = TestScheduler.CreateObserver<bool>();
                        ViewModel.IsLoading.Subscribe(observer);

                        prepareException(new Exception());

                        ViewModel.Signup.Execute();

                        TestScheduler.Start();
                        observer.Messages.AssertEqual(
                            ReactiveTest.OnNext(1, false),
                            ReactiveTest.OnNext(2, true),
                            ReactiveTest.OnNext(3, false)
                        );
                    }

                    [Fact, LogIfTooSlow]
                    public void SetsIncorrectEmailOrPasswordErrorIfReceivedUnauthorizedException()
                    {
                        var observer = TestScheduler.CreateObserver<string>();
                        ViewModel.ErrorMessage.Subscribe(observer);

                        prepareException(new UnauthorizedException(
                            ApiExceptions.Request,
                            ApiExceptions.Response));

                        ViewModel.Signup.Execute();

                        TestScheduler.Start();
                        observer.Messages.AssertEqual(
                            ReactiveTest.OnNext(1, ""),
                            ReactiveTest.OnNext(2, Resources.IncorrectEmailOrPassword)
                        );
                    }

                    [Fact, LogIfTooSlow]
                    public void SetsEmailAlreadyUsedErrorIfReceivedEmailIsAlreadyUsedException()
                    {
                        var observer = TestScheduler.CreateObserver<string>();
                        ViewModel.ErrorMessage.Subscribe(observer);

                        var request = Substitute.For<IRequest>();
                        request.Endpoint.Returns(new Uri("https://any.url.com"));
                        prepareException(new EmailIsAlreadyUsedException(
                            new BadRequestException(
                                request,
                                ApiExceptions.Response
                            )
                        ));

                        ViewModel.Signup.Execute();

                        TestScheduler.Start();
                        observer.Messages.AssertEqual(
                            ReactiveTest.OnNext(1, ""),
                            ReactiveTest.OnNext(2, Resources.EmailIsAlreadyUsedError)
                        );
                    }

                    [Fact, LogIfTooSlow]
                    public void SetsGenericErrorForAnyOtherException()
                    {
                        var observer = TestScheduler.CreateObserver<string>();
                        ViewModel.ErrorMessage.Subscribe(observer);

                        prepareException(new Exception());

                        ViewModel.Signup.Execute();

                        TestScheduler.Start();
                        observer.Messages.AssertEqual(
                            ReactiveTest.OnNext(1, ""),
                            ReactiveTest.OnNext(2, Resources.GenericSignUpError)
                        );
                    }

                    [Fact, LogIfTooSlow]
                    public void TracksTheEventAndException()
                    {
                        var exception = new Exception();
                        prepareException(exception);

                        ViewModel.Signup.Execute();

                        TestScheduler.Start();
                        AnalyticsService.UnknownSignUpFailure.Received()
                            .Track(exception.GetType().FullName, exception.Message);
                        AnalyticsService.Received().TrackAnonymized(exception);
                    }

                    [Fact, LogIfTooSlow]
                    public void DoesNotFiresSuccessfulSignUpEvent()
                    {
                        var observer = TestScheduler.CreateObserver<Unit>();
                        ViewModel.SuccessfulSignup.Subscribe(observer);

                        prepareException(new Exception());

                        ViewModel.Signup.Execute();

                        TestScheduler.Start();
                        observer.Messages.Count.Should().Be(0);
                    }
                }
            }
        }
    }
}
