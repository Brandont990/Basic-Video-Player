using System;

namespace Basic_Video_Player.Services
{
    public class OnBackgroundEnteringEventArgs : EventArgs
    {
        public OnBackgroundEnteringEventArgs(SuspensionState suspensionState, Type target)
        {
            SuspensionState = suspensionState;
            Target = target;
        }

        public SuspensionState SuspensionState { get; set; }

        public Type Target { get; private set; }
    }
}
