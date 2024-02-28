using ALSE.Objects;
using System.Collections;

namespace ALSE
{
    public delegate void OnItemAddEventHandler(object sender);
    public delegate void OnItemDeleteEventHandler(object sender);
    public delegate void OnItemUpdateEventHandler(object sender);


    public class ControllerCollection : CollectionBase
    {
        public event OnItemAddEventHandler? OnItemAdd;
        public event OnItemDeleteEventHandler? OnItemDelete;
        public event OnItemUpdateEventHandler? OnItemUpdate;
        public bool IsEmpty { get => InnerList == null || InnerList.Count == 0; }
        public ControllerCollection(List<Controller> controllers)
        {
            foreach (Controller item in controllers)
            {
                InnerList.Add(item);
            }
        }
        public ControllerCollection() : this(new List<Controller>())
        {

        }

        //GET
        public Controller this[int index] => (Controller)Convert.ChangeType(InnerList[index], typeof(Controller))!;
        public Controller? GetObjectById(string id)
        {
            return InnerList.OfType<Controller>().FirstOrDefault(generalObject => generalObject.id == id);
        }

        //ADD
        public void Add(Controller controller)
        {
            controller.PollingStart();
            InnerList.Add(controller);
            OnItemAdd?.Invoke(controller);
        }

        //DELETE
        public void Remove(Controller controller)
        {
            InnerList.Remove(controller);
            OnItemDelete?.Invoke(controller);
        }
        public void RemoveById(string id)
        {
            Controller? foundObject = InnerList.OfType<Controller>().FirstOrDefault(controller => controller.id == id);
            if (foundObject != null)
            {
                foundObject.PollingStop();
                InnerList.Remove(foundObject);
                OnItemDelete?.Invoke(foundObject);
                return;
            }
        }

        //UPDATE
        public void Update(Controller newController)
        {
            Controller? foundObject = InnerList.OfType<Controller>().FirstOrDefault(controller => controller.id == newController.id);
            if (foundObject != null)
            {
                foundObject.name = newController.name;
                foundObject.code = newController.code;
                foundObject.description = newController.description;
                foundObject.comport = newController.comport;
                foundObject.baudrate = newController.baudrate;
                foundObject.type = newController.type;
                foundObject.communication = newController.communication;
                OnItemUpdate?.Invoke(foundObject);
                return;
            }
        }
    }
}
