using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iParkingv5.Objects.Datas.Devices
{
    internal class LaneCollection : CollectionBase
    {
        public LaneCollection()
        {

        }

        public Lane this[int index]
        {
            get { return (Lane)InnerList[index]; }
        }

        public bool IsEmpty { get => InnerList == null || InnerList.Count == 0; }

        public LaneCollection(List<Lane> obj)
        {
            if (obj == null)
            {
                return;
            }

            InnerList.AddRange(obj);
        }

        public void Add(Lane obj)
        {
            if (obj == null)
            {
                return;
            }
            InnerList.Add(obj);
        }

        public string[] GetLanesId()
        {
            return InnerList.Cast<Lane>().Select(x => x.id).ToArray();
        }
    }
}
