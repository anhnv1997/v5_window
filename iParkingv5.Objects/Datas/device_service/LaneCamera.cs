using iParkingv5.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Datas.Device_service
{
    public class LaneCamera
    {

        #region fields
        private string cameraid = string.Empty;
        private string laneid = string.Empty;
        private LaneDirectionType.EmLaneDirection laneDirection = LaneDirectionType.EmLaneDirection.IN;
        private CameraPurposeType.EmCameraPurposeType cameraPurpose = CameraPurposeType.EmCameraPurposeType.MainOverView;
        private string id = string.Empty;
        private bool isDeleted = false;
        private DateTime? deleteDate = null;
        #endregion

        #region Properties
        public string Id { get => id; set => id = value; }

        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }

        public DateTime? DeleteDate { get => deleteDate; set => deleteDate = value; }

        public string CameraId { get => cameraid; set => cameraid = value; }

        public string LaneId { get => laneid; set => laneid = value; }

        public LaneDirectionType.EmLaneDirection LaneDirection { get => laneDirection; set => laneDirection = value; }

        public CameraPurposeType.EmCameraPurposeType CameraPurpose { get => cameraPurpose; set => cameraPurpose = value; }
        #endregion
    }
}
