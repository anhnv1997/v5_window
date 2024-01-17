using iParkingv5.Lpr.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5.LprDetecter.LprDetecters
{
    public class AmericalLpr : ILpr
    {
        public event Events.Events.OnLprDetectComplete? onLprDetectCompleteEvent;

        public bool CreateLpr(LprConfig lprConfig)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateLprAsync()
        {
            throw new NotImplementedException();
        }

        public string GetPlateNumber(Image? originalImage, bool isCar, Rectangle? detectRegion, out Image? lprImage)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<string, Image?>> GetPlateNumberAsync(Image? originalImage, bool isCar, Rectangle? detectRegion)
        {
            throw new NotImplementedException();
        }
    }
}
