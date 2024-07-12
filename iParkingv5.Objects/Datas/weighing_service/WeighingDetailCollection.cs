using System;
using System.Collections;
using System.Linq;

namespace iParkingv5.Objects.Datas.weighing_service
{
    public class WeighingDetailCollection : CollectionBase
    {
        #region Properties
        public static object lockObj = new object();

        #endregion
        //GET
        public WeighingDetail this[int index] => (WeighingDetail)Convert.ChangeType(InnerList[index], typeof(WeighingDetail))!;

        public WeighingDetail GetObjectById(string trafficId)
        {
            lock (lockObj)
            {
                return InnerList.OfType<WeighingDetail>().FirstOrDefault(generalObject => generalObject.Traffic_id == trafficId);
            }
        }

        // Add
        public void Add(WeighingDetail data)
        {
            lock (lockObj)
            {
                InnerList.Add(data);
            }
        }

        // Remove
        public void Remove(WeighingDetail data)
        {
            lock (lockObj)
            {
                InnerList.Remove(data);
            }
        }

        public void RemoveById(string trafficId)
        {
            lock (lockObj)
            {
                WeighingDetail foundObject = InnerList.OfType<WeighingDetail>().FirstOrDefault(generalObject => generalObject.Traffic_id == trafficId);
                if (foundObject != null)
                {
                    InnerList.Remove(foundObject);
                }
            }
        }
    }
}