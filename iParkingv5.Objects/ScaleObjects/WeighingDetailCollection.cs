using System;
using System.Collections;
using System.Linq;

namespace iParkingv5.Objects.ScaleObjects
{
    public class WeighingDetailCollection : CollectionBase
    {
        #region Properties
        public static object lockObj = new object();

        #endregion
        //GET
        public WeighingAction this[int index] => (WeighingAction)Convert.ChangeType(InnerList[index], typeof(WeighingAction))!;

        public WeighingAction? GetObjectById(string trafficId)
        {
            lock (lockObj)
            {
                return InnerList.OfType<WeighingAction>().FirstOrDefault(generalObject => generalObject.eventInId == trafficId);
            }
        }

        // Add
        public void Add(WeighingAction data)
        {
            lock (lockObj)
            {
                InnerList.Add(data);
            }
        }

        // Remove
        public void Remove(WeighingAction data)
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
                WeighingAction? foundObject = InnerList.OfType<WeighingAction>().FirstOrDefault(generalObject => generalObject.eventInId == trafficId);
                if (foundObject != null)
                {
                    InnerList.Remove(foundObject);
                }
            }
        }
    }
}