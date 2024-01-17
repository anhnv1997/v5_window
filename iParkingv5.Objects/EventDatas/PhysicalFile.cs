using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.EventDatas
{
    public class PhysicalFile
    {
        public int Id { get; }
        public string FileKey { get; set; } = "/images/placeholder/kztek.jpg";
        public string Description { get; set; } = "Not found";
        public bool Deleted { get; set; }
        public DateTime CreatedUtc { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public Guid? UpdatedBy { get; set; }

        public ICollection<EventPhysicalFileMap> EventPhysicalFileMaps { get; set; }

        public PhysicalFile(string fileKey, string description)
        {
            FileKey = fileKey;
            Description = description;
        }
    }
}