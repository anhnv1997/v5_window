using System;
using System.Collections;
using System.Linq;

namespace iParkingv5.Objects.ScaleObjects
{
    public class WeighingTypeCollection : CollectionBase
    {
        #region Properties
        public static object lockObj = new object();

        #endregion
        //GET
        public WeighingType this[int index] => (WeighingType)Convert.ChangeType(InnerList[index], typeof(WeighingType))!;

        public WeighingType? GetObjectById(string id)
        {
            lock (lockObj)
            {
                return InnerList.OfType<WeighingType>().FirstOrDefault(generalObject => generalObject.Id == id);
            }
        }

        // Add
        public void Add(WeighingType data)
        {
            lock (lockObj)
            {
                InnerList.Add(data);
            }
        }

        // Remove
        public void Remove(WeighingType data)
        {
            lock (lockObj)
            {
                InnerList.Remove(data);
            }
        }

        public void RemoveById(string id)
        {
            lock (lockObj)
            {
                WeighingType? foundObject = InnerList.OfType<WeighingType>().FirstOrDefault(generalObject => generalObject.Id == id);
                if (foundObject != null)
                {
                    InnerList.Remove(foundObject);
                }
            }
        }
    }
}