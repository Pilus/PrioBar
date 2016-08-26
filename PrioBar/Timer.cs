namespace PrioBar
{
    using System;

    using BlizzardApi.Global;
    using BlizzardApi.WidgetEnums;
    using BlizzardApi.WidgetInterfaces;

    public class Timer
    {
        private readonly double callbackFrequency;

        private readonly Action callbackAction;

        private double lastCallTime;

        public Timer(double callbackFrequency, Action callbackAction)
        {
            this.callbackFrequency = callbackFrequency;
            this.callbackAction = callbackAction;
            this.lastCallTime = 0;
            var frame = (IFrame)Global.FrameProvider.CreateFrame(FrameType.Frame);
            frame.SetScript(FrameHandler.OnUpdate, this.OnUpdate);
        }

        private void OnUpdate(IUIObject self)
        {
            var time = Lua.Core.time();
            if ((this.lastCallTime + this.callbackFrequency) < time)
            {
                this.lastCallTime = time;
                this.callbackAction();
            }
        }
    }
}