using iParkingv5.Lpr.Objects;
using System;
using System.Drawing;
using System.Threading.Tasks;
using static iParkingv5.LprDetecter.Events.Events;

namespace iParkingv5.LprDetecter.LprDetecters
{
    public interface ILpr
    {
        event OnLprDetectComplete? onLprDetectCompleteEvent;
        bool CreateLpr(LprConfig lprConfig);
        Task<bool> CreateLprAsync();
        string GetPlateNumber(Image? originalImage, bool isCar, Rectangle? detectRegion, out Image? lprImage);
        Task<Tuple<string, Image?>> GetPlateNumberAsync(Image? original, bool isCar, Rectangle? detectRegion);
    }
}
