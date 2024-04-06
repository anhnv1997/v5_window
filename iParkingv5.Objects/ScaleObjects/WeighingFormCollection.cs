using System;
using System.Collections;
using System.Linq;

namespace iParkingv5.Objects.ScaleObjects
{
    public class WeighingFormCollection : CollectionBase
    {
        #region Properties
        public static object lockObj = new object();

        #endregion
        //GET
        public WeighingForm this[int index] => (WeighingForm)Convert.ChangeType(InnerList[index], typeof(WeighingForm))!;

        public WeighingForm? GetObjectById(string id)
        {
            lock (lockObj)
            {
                return InnerList.OfType<WeighingForm>().FirstOrDefault(generalObject => generalObject.Id == id);
            }
        }

        // Add
        public void Add(WeighingForm data)
        {
            lock (lockObj)
            {
                InnerList.Add(data);
            }
        }

        // Remove
        public void Remove(WeighingForm data)
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
                WeighingForm? foundObject = InnerList.OfType<WeighingForm>().FirstOrDefault(generalObject => generalObject.Id == id);
                if (foundObject != null)
                {
                    InnerList.Remove(foundObject);
                }
            }
        }
    }
}