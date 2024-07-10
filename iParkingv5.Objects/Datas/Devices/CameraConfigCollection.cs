using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iParkingv5.Objects.Datas.Devices
{
    internal class CameraConfigCollection : CollectionBase
    {
        public CameraConfigCollection()
        {

        }
        public bool IsEmpty { get => InnerList == null || InnerList.Count == 0; }
        public CameraConfigCollection(List<Camera> obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.AddRange(obj);
        }
        public void Add(Camera obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.Add(obj);
        }
        public CameraConfigCollection GetByIds(params string[] obj)
        {
            var data = new CameraConfigCollection();
            foreach (Camera item in InnerList)
            {
                if (obj.Contains(item.Id))
                {
                    data.Add(item);
                }
            }
            return data;
        }
    }
}
