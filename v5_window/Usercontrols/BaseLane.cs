using iParkingv5.Objects.Events;
using iParkingv6.Objects.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_window.Usercontrols
{
    public static class BaseLane
    {
        static int waitSwipeCardTime = 5000;
        public static bool CheckNewCardEvent(this iLane iLane, Lane lane, CardEventArgs ce,
                                             out ControllerInLane? controllerInLane, out int thoiGianCho)
        {
            thoiGianCho = 0;
            DateTime eventTime = DateTime.Now;
            bool isValidControllerIdAndReader = IsValidControllerAndReader(lane, ce, out controllerInLane);
            if (!isValidControllerIdAndReader) return false;

            List<CardEventArgs> deleteEvents = GCColectLastEventDatas(iLane, ce, eventTime);
            deleteEvents.Clear();

            foreach (CardEventArgs oldEvent in iLane.lastCardEventDatas)
            {
                if (ce.IsInWaitingTime(oldEvent, waitSwipeCardTime, out thoiGianCho))
                {
                    return false;
                }
            }
            iLane.lastCardEventDatas.Add(ce);
            return true;
        }

        private static bool IsValidControllerAndReader(Lane lane, CardEventArgs ce, out ControllerInLane? controllerInLane)
        {
            controllerInLane = null;
            bool isValidControllerIdAndReader = false;
            foreach (ControllerInLane _controllerInLane in lane.controlUnits)
            {
                if (_controllerInLane.controlUnitId.ToLower() != ce.DeviceId.ToLower())
                {
                    continue;
                }

                //Danh sách đăng ký có không có reader của sự kiện ==> Bỏ qua
                if (!_controllerInLane.readers.Contains(ce.ReaderIndex.ToString()))
                {
                    continue;
                }
                isValidControllerIdAndReader = true;
                controllerInLane = _controllerInLane;
            }

            return isValidControllerIdAndReader;
        }
        private static List<CardEventArgs> GCColectLastEventDatas(iLane iLane, CardEventArgs ce, DateTime eventTime)
        {
            List<CardEventArgs> deleteEvents = new List<CardEventArgs>();
            foreach (var item in iLane.lastCardEventDatas)
            {
                bool isSameCard = false;
                foreach (string card in ce.AllCardFormats)
                {
                    if (item.AllCardFormats.Contains(card))
                    {
                        deleteEvents.Add(item);
                        isSameCard = true;
                        break;
                    }
                }
                if (!isSameCard)
                {
                    if ((eventTime - item.EventTime).TotalSeconds > 5000)
                    {
                        deleteEvents.Add(item);
                    }
                }
            }

            foreach (var item in deleteEvents)
            {
                iLane.lastCardEventDatas.Remove(item);
            }

            return deleteEvents;
        }

    }
}
