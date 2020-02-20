using System;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Toggl.Droid.Activities
{
    public partial class OnboardingActivity : ISurfaceHolderCallback
    {
        private const long animationReplayDelay = 4000L;

        private SurfaceView onboardingSurfaceView;
        private View continueWithGoogleButton;
        private Button continueWithEmailButton;

        private MediaPlayer mediaPlayer;
        private Handler handler;

        protected override void InitializeViews()
        {
            handler = new Handler(Looper.MainLooper);
            onboardingSurfaceView = FindViewById<SurfaceView>(Resource.Id.togglMan);
            continueWithGoogleButton = FindViewById(Resource.Id.continueWithGoogleButton);
            continueWithEmailButton = FindViewById<Button>(Resource.Id.continueWithEmailButton);
            
            onboardingSurfaceView.Holder.AddCallback(this);
        }

        public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
        {
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.Release();
                mediaPlayer.Completion -= replayVideo;
            }

            mediaPlayer = MediaPlayer.Create(ApplicationContext, Resource.Raw.togglman);
            mediaPlayer.SetDisplay(holder);
            mediaPlayer.Start();
            mediaPlayer.Completion += replayVideo;
        }

        private void replayVideo(object sender, EventArgs args)
        {
            handler.PostDelayed(() => mediaPlayer?.Start(), animationReplayDelay);
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
        }

        protected override void OnPause()
        {
            base.OnPause();
            mediaPlayer?.Release();
            mediaPlayer = null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            mediaPlayer?.Release();
            mediaPlayer = null;
        }
    }
}
