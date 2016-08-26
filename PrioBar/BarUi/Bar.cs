namespace PrioBar.BarUi
{
    using System;

    using BlizzardApi.Global;
    using BlizzardApi.WidgetEnums;
    using BlizzardApi.WidgetInterfaces;

    using global::PrioBar.Priority;

    public class Bar
    {
        private const int MaxButtons = 6;

        private const double ButtonSize = 64;

        private const double ButtonSpacing = 6;

        private readonly IFrame bar;

        private readonly BarButton[] buttons = new BarButton[MaxButtons];

        public Bar(Func<IFrame, BarButton> barButtonFactory)
        {
            this.bar = (IFrame)Global.FrameProvider.CreateFrame(FrameType.Frame, "PrioBarBar", Global.Frames.UIParent);
            this.bar.SetHeight(ButtonSize);
            this.bar.SetWidth(ButtonSize*MaxButtons + ButtonSpacing*(MaxButtons-1));
            this.bar.SetPoint(FramePoint.BOTTOM, Global.Frames.UIParent, FramePoint.BOTTOM, 0, 300);

            for (var i = 0; i < MaxButtons; i++)
            {
                this.buttons[i] = barButtonFactory(this.bar);
                this.buttons[i].SetOffset((ButtonSize + ButtonSpacing) * i, 0);
            }
        }

        public void DisplayQueue(QueueObject[] queue)
        {
            for (var i = 0; i < MaxButtons; i++)
            {
                this.buttons[i].SetIcon(queue.Length > i ? queue[i].Icon : null);
            }
        }
    }
}