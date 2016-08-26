namespace PrioBar.BarUi
{
    using BlizzardApi.Global;
    using BlizzardApi.WidgetEnums;
    using BlizzardApi.WidgetInterfaces;

    public class BarButton
    {
        private const string ButtonNamePrefix = "PrioBarButton";
        private static int buttonIndex = 0;
        private readonly IButton button;

        public BarButton(IFrame parent)
        {
            this.button = (IButton)Global.FrameProvider.CreateFrame(FrameType.Button, ButtonNamePrefix + buttonIndex, parent);
            this.button.Hide();
            buttonIndex++;
        }

        public void SetSize(double size)
        {
            this.button.SetWidth(size);
            this.button.SetHeight(size);
        }

        public void SetOffset(double xOff, double yOff)
        {
            this.button.SetPoint(FramePoint.TOPLEFT, xOff, yOff);
        }

        public void SetIcon(string icon)
        {
            if (string.IsNullOrEmpty(icon))
            {
                this.button.Hide();
                return;
            }

            this.button.SetNormalTexture(icon);
            this.button.Show();
        }
    }
}