namespace iPakrkingv5.Controls.Controls.Buttons
{
    public interface IDesignControl
    {
        void Init(EventHandler? OnClickEvent);
        void EnableWaitMode();
        void Reset();
    }
}
