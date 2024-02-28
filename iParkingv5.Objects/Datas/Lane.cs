using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class LaneAdvanceSettings
    {
        public string Id { get; set; }
        public List<CameraInLane> CameraList { get; set; }
        public List<ControllerInLane> ControllerList { get; set; }
    }

    public class CameraInLane
    {
        public string cameraId { get; set; }
        public int cameraPurpose { get; set; }
        public int sideIndex { get; set; }
        public int displayIndex { get; set; }
    }

    public class ControllerInLane
    {
        public string controlUnitId { get; set; }
        public int[] readers { get; set; }
        public int[] inputs { get; set; }
        public int[] barriers { get; set; }
        public int[] alarms { get; set; }
    }

    public class Lane
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string computerId { get; set; }
        public int type { get; set; }
        public string reverseLaneId { get; set; }
        public bool loop { get; set; }
        public bool autoPrintInvoice { get; set; }
        public bool displayLed { get; set; }
        public bool freeForPriority { get; set; }
        public bool enabled { get; set; }
        public bool deleted { get; set; }
        public string createdUtc { get; set; }
        public string createdBy { get; set; }
        public object updatedUtc { get; set; }
        public object updatedBy { get; set; }
        public object computer { get; set; }
        public CameraInLane[] cameras { get; set; }
        public ControllerInLane[] controlUnits { get; set; }
        public object[] identityGroupLaneMaps { get; set; }
        public object[] eventIns { get; set; }
        public object[] eventOuts { get; set; }
        public object[] eventOutDays { get; set; }
    }
}
