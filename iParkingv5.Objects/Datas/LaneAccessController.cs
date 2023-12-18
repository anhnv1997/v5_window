using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iParkingv5.Objects.Datas
{
    public class LaneAccessController
    {
        private string id;
        private string controller_ID;
        private string lane_ID;
        private string readerIndex = String.Empty;
        private string inputIndex = String.Empty;
        private string barrieIndex = String.Empty;

        public string Id { get => id; set => id = value; }
        public string ControllerId { get => controller_ID; set => controller_ID = value; }
        public string LaneId { get => lane_ID; set => lane_ID = value; }
        public string ReaderIndex { get => readerIndex; set => readerIndex = value; }
        public string InputIndex { get => inputIndex; set => inputIndex = value; }
        public string BarrieIndex { get => barrieIndex; set => barrieIndex = value; }
    }

    public class LaneAccessControllerCollecion : CollectionBase
    {
        public enum EventType
        {
            CardEvent,
            InputEvent,
            Other,
        }

        public enum OutputType
        {
            Barrier,
            Alarm,
            Other,
        }

        public LaneAccessControllerCollecion()
        {

        }
        public bool IsEmpty { get => this.InnerList == null || this.InnerList.Count == 0; }

        public LaneAccessControllerCollecion(List<LaneAccessController> laneCameras)
        {
            if (laneCameras == null)
            {
                return;
            }

            InnerList.AddRange(laneCameras);
        }

        public void Add(LaneAccessController obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.Add(obj);
        }

        public string[] GetAccessControllersId()
        {
            if (this.InnerList == null)
            {
                return null;
            }
            return InnerList.Cast<LaneAccessController>().Select(x => x.ControllerId)?.ToArray();
        }


        public LaneAccessControllerCollecion CollecitonByLaneId(string laneId)
        {
            if (this.InnerList == null)
            {
                return null;
            }
            return new LaneAccessControllerCollecion(InnerList.Cast<LaneAccessController>().Where(x => x.LaneId == laneId)?.ToList());
        }


        /// <summary>
        /// Kiểm tra xem làn này có đăng ký sự kiện thẻ, nút nhấn,.. ở trên bđk này ko
        /// </summary>
        /// <param name="controllerID"></param>
        /// <param name="index"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        public bool SubcriberValidate(string laneId, string controllerID, EventType eventType, int index)
        {
            return InnerList.Cast<LaneAccessController>().Any(x => x.LaneId == laneId && x.ControllerId == controllerID &&
            ((!String.IsNullOrEmpty(x.InputIndex) && eventType == EventType.InputEvent && x.InputIndex.Contains(index.ToString())) ||
            (!String.IsNullOrEmpty(x.ReaderIndex) && eventType == EventType.CardEvent && x.ReaderIndex.Contains(index.ToString()))
            ));
        }


        /// <summary>
        /// Lấy ra id các làn đăng ký lấy sự kiện của input này
        /// </summary>
        /// <param name="controllerId">id bộ điều khiển</param>
        /// <param name="inputIndex">index input</param>
        /// <returns></returns>
        public string[] GetLanesIdByInputIndex(string controllerId, int inputIndex)
        {
            return InnerList.Cast<LaneAccessController>().Where(x => x.ControllerId == controllerId &&
                        !String.IsNullOrEmpty(x.InputIndex) &&
                       x.InputIndex.Contains(inputIndex.ToString())).Select(y => y.LaneId)?.ToArray();
        }

        /// <summary>
        /// Lấy ra id các làn đăng ký lấy sự kiện thẻ của bộ điều khiển này
        /// </summary>
        /// <param name="controllerId">id bộ điều khiển</param>
        /// <param name="readerIndex">index đầu đọc</param>
        /// <returns></returns>
        public string[] GetLanesIdByReaderIndex(string controllerId, int readerIndex)
        {
            return InnerList.Cast<LaneAccessController>().Where(x => x.ControllerId == controllerId &&
                        !String.IsNullOrEmpty(x.InputIndex) &&
                       x.InputIndex.Contains(readerIndex.ToString())).Select(y => y.LaneId)?.ToArray();
        }


        /// <summary>
        /// Lấy đầu ra cần mở của các bộ điều khiển mà làn đó đăng ký
        /// </summary>
        /// <param name="laneId">id làn</param>
        /// <param name="outputType">loại đầu ra (barrier, alarm)</param>
        /// <returns></returns>
        public Dictionary<string, int[]> GetOutputByLane(string laneId = "", OutputType outputType = OutputType.Barrier)
        {
            var data = new Dictionary<string, int[]>();
            var controllers = InnerList.Cast<LaneAccessController>().Where(x => (String.IsNullOrEmpty(laneId) || x.LaneId == laneId));
            if (controllers != null && controllers.Count() > 0)
            {
                foreach (var item in controllers)
                {
                    var outputs = (outputType == OutputType.Barrier ? item.BarrieIndex : item.BarrieIndex).Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (outputs != null)
                    {
                        var intOutputs = new int[outputs.Length];
                        for (int i = 0; i < outputs.Length; i++)
                        {
                            intOutputs[i] = int.Parse(outputs[i]);
                        }
                        data.Add(item.ControllerId, intOutputs);
                    }
                }
                return data;
            }
            return null;
        }
    }
}