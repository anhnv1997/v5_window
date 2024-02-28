namespace iPakrkingv5.Controls.Controls.Buttons
{
    public interface IDesignControl
    {
        void InitControl(EventHandler? OnClickEvent);
        void EnableWaitMode();
        void Reset();
    }
}
