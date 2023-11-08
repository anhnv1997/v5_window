using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace iParkingv6.Objects.Datas
{
    public class MenuFunction
    {
        public string Id { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string MenuType { get; set; }
        public string ActionName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string ParentId { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public int? OrderNumber { get; set; }
        public string Breadcrumb { get; set; }
        public int? Dept { get; set; }
        public bool isSystem { get; set; } = false;
        public string MenuGroupListId { get; set; } = "";
    }
}
