using System;
using System.Threading.Tasks;

using Basic_Video_Player.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace Basic_Video_Player.Services
{
    public static class FirstRunDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsFirstRun && !shown)
            {
                shown = true;
                FirstRunDialog dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
