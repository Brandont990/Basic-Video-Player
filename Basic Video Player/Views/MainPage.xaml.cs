using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Basic_Video_Player.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void FileExplorer_Click(object sender, RoutedEventArgs e)
        {
            await SetLocalMedia();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private async System.Threading.Tasks.Task SetLocalMedia()
        {
            Windows.Storage.Pickers.FileOpenPicker openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".m4a");
           // AddHandler for Pro down below
            //openPicker.FileTypeFilter.Add(".mkv");
            //openPicker.FileTypeFilter.Add(".avi");
            //openPicker.FileTypeFilter.Add(".dv");
            //openPicker.FileTypeFilter.Add(".avchd");


            Windows.Storage.StorageFile file = await openPicker.PickSingleFileAsync();

            //media is a mediaPlayerElement defined in XAML
            if (file != null)
            {
                mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);

                mediaPlayer.MediaPlayer.Play();
            }
        }

        private void SettingPage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage));
        }
    }
}
