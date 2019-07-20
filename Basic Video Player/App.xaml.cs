using System;

using Basic_Video_Player.Core.Helpers;
using Basic_Video_Player.Services;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace Basic_Video_Player
{
    public sealed partial class App : Application
    {
        private readonly Lazy<ActivationService> _activationService;

        public App()
        {
            InitializeComponent();

            EnteredBackground += App_EnteredBackground;
            Resuming += App_Resuming;

            AppCenter.Start("fdd3ed19-e223-4298-9c4f-a2c2b420770e", typeof(Analytics), typeof(Crashes));

            // Deferred execution until used
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        private ActivationService ActivationService => _activationService.Value;

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        private async void App_EnteredBackground(object sender, EnteredBackgroundEventArgs e)
        {
            Windows.Foundation.Deferral deferral = e.GetDeferral();
            await Singleton<SuspendAndResumeService>.Instance.SaveStateAsync();
            deferral.Complete();
        }

        private void App_Resuming(object sender, object e)
        {
            Singleton<SuspendAndResumeService>.Instance.ResumeApp();
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.MainPage));
        }
    }
}
