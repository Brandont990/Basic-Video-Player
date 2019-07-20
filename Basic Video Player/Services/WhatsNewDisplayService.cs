using System;
using System.Threading.Tasks;

using Basic_Video_Player.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace Basic_Video_Player.Services
{
    // For instructions on testing this service see https://github.com/Microsoft/WindowsTemplateStudio/tree/master/docs/features/whats-new-prompt.md
    public static class WhatsNewDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsAppUpdated && !shown)
            {
                shown = true;
                WhatsNewDialog dialog = new WhatsNewDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
