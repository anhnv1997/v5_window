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
        public string CameraID { get; set; }
        public int CameraPurpose { get; set; } = 0;
        public int SideIndex { get; set; } = 0;
        public int DisplayIndex { get; set; } = 0;
    }

    public class ControllerInLane
    {
        private int[] readers;
        private int[] inputs;
        private int[] barriers;
        private int[] alarms;
        public string ControllerId { get; set; }
        public string ControllerName { get; set; }
        public int[] Readers { get => readers; set => readers = value ?? Array.Empty<int>(); }
        public int[] Inputs { get => inputs; set => inputs = value ?? Array.Empty<int>(); }
        public int[] Barriers { get => barriers; set => barriers = value ?? Array.Empty<int>(); }
        public int[] Alarms { get => alarms; set => alarms = value ?? Array.Empty<int>(); }
    }
    public class Lane
    {
        public string Id { get; set; }
        public string LaneCode { get; set; }
        public string LaneName { get; set; }
        public string ComputerId { get; set; }
        public int? LaneType { get; set; }
        public bool IsLoop { get; set; }
        public int CheckPlateLevelIn { get; set; }
        public int CheckPlateLevelOut { get; set; }
        public bool IsPrint { get; set; }
        public List<CameraInLane> CameraList { get; set; }
        public List<ControllerInLane> ControllerList { get; set; }
        public bool Inactive { get; set; }
        public bool IsLed { get; set; }
        public bool IsFree { get; set; }
    }

}
