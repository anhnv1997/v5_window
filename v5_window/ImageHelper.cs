using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window
{
    public static class ImageHelper
    {
        public static string CreateSaveFileName(DateTime dtime, bool isOutEvent, string plate, string laneId, string camera_Function, string description = "")
        {
            string picPath = string.Empty;
            if (isOutEvent)
            {
                picPath = $"OUT/{laneId}/{dtime.Year:0000}/{dtime.Month:00}/{dtime.Day:00}/{dtime.Hour:00}_{dtime.Minute:00}_{dtime.Second:00}_{dtime.Millisecond:00000}_{camera_Function}_{plate}_{description}.jpeg";
            }
            else
            {
                picPath = $"IN/{laneId}/{dtime.Year:0000}/{dtime.Month:00}/{dtime.Day:00}/{dtime.Hour:00}_{dtime.Minute:00}_{dtime.Second:00}_{dtime.Millisecond:00000}_{camera_Function}_{plate}_{description}.jpeg";
            }
            return picPath;
        }
        private static string CreateFileName(DateTime dtime, string picPath, Guid g)
        {
            string ip = picPath.Split('\\')[2];
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip, 100);
            if (reply == null || reply.Status != IPStatus.Success)
            {
                return string.Empty;
            }
            string path = picPath + $@"\{dtime.Year:0000}\{dtime.Month:00}\{dtime.Day:00}";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
            }
            string filename = dtime.Hour.ToString("00") + "h" + dtime.Minute.ToString("00") + "m" + dtime.Second.ToString("00") + "s_" + g.ToString();
            filename = path + @"\" + filename;
            return filename;
        }
    }
}
