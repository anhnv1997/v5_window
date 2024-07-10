using iParkingv5.Objects.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static iParkingv5.Objects.Enums.CameraPurposeType;

namespace iParkingv5.Objects.Datas.Device_service
{
    internal class LaneCameraCollection : CollectionBase
    {
        public LaneCameraCollection()
        {

        }

        public bool IsEmpty { get => InnerList == null || InnerList.Count == 0; }
        public LaneCameraCollection(List<LaneCamera> laneCameras)
        {
            if (laneCameras == null)
            {
                return;
            }

            InnerList.AddRange(laneCameras);
        }

        public void Add(LaneCamera obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.Add(obj);
        }
        public LaneCameraCollection GetByLaneId(string laneId)
        {
            var data = new LaneCameraCollection();
            foreach (var item in InnerList)
            {
                if (((LaneCamera)item).LaneId == laneId)
                {
                    data.Add((LaneCamera)item);
                }
            }
            return data;
        }

        public List<string> GetCamerasIdByDirection(LaneDirectionType.EmLaneDirection laneDirection)
        {
            var ids = new List<string>();

            foreach (LaneCamera item in InnerList)
            {
                if (item.LaneDirection == laneDirection)
                {
                    ids.Add(item.CameraId);
                }
            }

            return ids;
        }

        public string[] GetCameraIdByLaneId(string laneid)
        {
            return InnerList.Cast<LaneCamera>().Where(x => x.LaneId == laneid).Select(x => x.CameraId).ToArray();
        }

        public string[] GetCamerasId()
        {
            return InnerList.Cast<LaneCamera>().Select(x => x.CameraId).Distinct().ToArray();
        }

        public EmCameraPurposeType GetCameraPurposeByCameraId(string id)
        {
            foreach (LaneCamera item in InnerList)
            {
                if (item.CameraId == id)
                {
                    return item.CameraPurpose;
                }
            }
            return EmCameraPurposeType.SubOverView;
        }
    }
}
