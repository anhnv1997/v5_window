using System;

namespace iParkingv5.Objects.EventDatas
{
    public class EventPhysicalFileMap
    {
        public int Id { get; set; }
        public Guid? EventInId { get; set; }
        public Guid? EventOutId { get; set; }
        public Guid? AbnormalEventId { get; set; }
        public int PhysicalFileId { get; set; }
        public int DisplayIndex { get; set; } = -1;

        public EventPhysicalFileMap(int physicalFileId, Guid? eventInId = null, Guid? eventOutId = null,
            Guid? abnormalEventId = null)
        {
            PhysicalFileId = physicalFileId;
            EventInId = eventInId;
            EventOutId = eventOutId;
            AbnormalEventId = abnormalEventId;
        }
    }
}

