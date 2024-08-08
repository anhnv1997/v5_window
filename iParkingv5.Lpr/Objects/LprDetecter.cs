
namespace iParkingv5.LprDetecter.Objects
{
    public class LprDetecter
    {
        public enum EmLprDetecter
        {
            KztekLpr,
            AmericalLpr,
        }

        public static string ToString(EmLprDetecter lprDetecter)
        {
            switch (lprDetecter)
            {
                case EmLprDetecter.KztekLpr:
                    return "Kztek Lpr";
                case EmLprDetecter.AmericalLpr:
                    return "Americal Lpr";
                default:
                    return string.Empty;
            }
        }
    }
}
