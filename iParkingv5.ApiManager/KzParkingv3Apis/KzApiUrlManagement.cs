using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public static class KzApiUrlManagement
    {
        public static string BaseRoute => "api";
        #region -- USER -- OK
        public static string PostLoginRoute => "Auth/Login";
        public static string summaryRoute = "Event-Out/Summary";
        public static string CommitOutRoute = "Event-Out";
        #endregion

        public enum EmObjectType
        {
            Camera,
            Computer,
            ControlUnit,
            Customer,
            CustomerGroup,
            EventIn,
            EventOut,
            Gate,
            Identity,
            IdentityGroup,
            Lane,
            Led,
            RegisteredVehicle,
            VehicleType,
            AbnormalEvent
        }

        public static string GetDataByIdRoute(this EmObjectType emObjectType, string objectId)
        {
            switch (emObjectType)
            {
                case EmObjectType.EventIn:
                    return $"Event-In/{objectId}";

                case EmObjectType.VehicleType:
                    return $"Vehicle-Type/{objectId}";
                case EmObjectType.CustomerGroup:
                    return $"Customer-Group/{objectId}";
                case EmObjectType.IdentityGroup:
                    return $"Identity-Group/{objectId}";
                case EmObjectType.RegisteredVehicle:
                    return $"Registered-Vehicle/{objectId}";
                case EmObjectType.AbnormalEvent:
                    return $"Abnormal-Event/{objectId}";
                case EmObjectType.EventOut:
                    return $"Event-Out/{objectId}";
                default:
                    return $"{emObjectType}/{objectId}";
            }

        }
        public static string GetDataByParamsRoute(this EmObjectType emObjectType)
        {
            switch (emObjectType)
            {
                case EmObjectType.EventIn:
                    return $"Event-In";
                case EmObjectType.EventOut:
                    return $"Event-Out";
                case EmObjectType.VehicleType:
                    return $"Vehicle-Type";
                case EmObjectType.CustomerGroup:
                    return $"Customer-Group";
                case EmObjectType.IdentityGroup:
                    return $"Identity-Group";
                case EmObjectType.AbnormalEvent:
                    return $"Abnormal-Event/";
                case EmObjectType.RegisteredVehicle:
                    return $"Registered-Vehicle";
                default:
                    return $"{emObjectType}";
            }
        }

        public static string CreateRoute(this EmObjectType emObjectType)
        {
            switch (emObjectType)
            {
                case EmObjectType.EventIn:
                    return $"Event-In";
                case EmObjectType.EventOut:
                    return $"Event-Out/Check-Out";
                case EmObjectType.VehicleType:
                    return $"Vehicle-Type/";
                case EmObjectType.CustomerGroup:
                    return $"Customer-Group/";
                case EmObjectType.IdentityGroup:
                    return $"Identity-Group/";
                case EmObjectType.RegisteredVehicle:
                    return $"Registered-Vehicle/";
                case EmObjectType.AbnormalEvent:
                    return $"Abnormal-Event/";
                default:
                    return $"{emObjectType}";
            }
        }
        public static string UpdateRouteById(this EmObjectType emObjectType, string id)
        {
            switch (emObjectType)
            {
                case EmObjectType.EventIn:
                    return $"Event-In/{id}";
                case EmObjectType.EventOut:
                    return $"Event-Out/{id}";
                case EmObjectType.VehicleType:
                    return $"Vehicle-Type/{id}";
                case EmObjectType.CustomerGroup:
                    return $"Customer-Group/{id}";
                case EmObjectType.IdentityGroup:
                    return $"Identity-Group/{id}";
                case EmObjectType.RegisteredVehicle:
                    return $"Registered-Vehicle/{id}";
                case EmObjectType.AbnormalEvent:
                    return $"Abnormal-Event/{id}";
                default:
                    return $"{emObjectType}/{id}";
            }
        }
        public static string DeleteByIdRoute(this EmObjectType emObjectType, string objectId)
        {
            switch (emObjectType)
            {
                case EmObjectType.EventIn:
                    return $"Event-In/{objectId}";
                case EmObjectType.EventOut:
                    return $"Event-Out/{objectId}";
                case EmObjectType.VehicleType:
                    return $"Vehicle-Type/{objectId}";
                case EmObjectType.CustomerGroup:
                    return $"Customer-Group/{objectId}";
                case EmObjectType.IdentityGroup:
                    return $"Identity-Group/{objectId}";
                case EmObjectType.RegisteredVehicle:
                    return $"Registered-Vehicle/{objectId}";
                case EmObjectType.AbnormalEvent:
                    return $"Abnormal-Event/{objectId}";
                default:
                    return $"{emObjectType}/{objectId}";
            }
        }


        //#region -- CAMERA -- OK
        //public static string GetCameraByIdRoute(string cameraId) => $"camera/byid/{cameraId}";
        //public static string GetCameraByComputerIdRoute => $"camera";
        //public static string PostNewCameraRoute => "camera";
        //public static string PutCameraRoute => "camera";
        //public static string DeleteCameraByIdRoute(string cameraId) => $"camera/{cameraId}";
        //#endregion

        //#region -- LANE --OK
        //public static string GetLaneByIdRoute(string laneId) => $"lane/{laneId}";
        //public static string GetLaneByComputerIdRoute => $"lane";
        //public static string PostNewLaneRoute => "lane";
        //public static string PutLaneRoute => "lane";
        //public static string DeleteLaneByIdRoute(string laneId) => $"lane/{laneId}";

        //#endregion

        //#region -- PARKING LED -- OK
        //public static string GetLedByIdRoute(string ledId) => $"Led/{ledId}";
        //public static string GetLedByComputerIdRoute => $"Led";
        //public static string PostNewLedRoute => "Led";
        //public static string PutLedRoute => "Led";
        //public static string DeleteLedByIdRoute(string ledId) => $"Led/{ledId}";
        //#endregion

        //#region -- CONTROL UNIT -- OK
        //public static string GetControllerByIdRoute(string controlUnitId) => $"ControlUnit/byid/{controlUnitId}";
        //public static string GetControllerByComputerIdRoute => $"ControlUnit";
        //public static string PostNewControlUnitRoute => "ControlUnit";
        //public static string PutControlUnitRoute => "ControlUnit";
        //public static string DeleteControlUnitByIdRoute(string controlUnitId) => $"ControlUnit/{controlUnitId}";
        //#endregion

        //#region -- COMPUTER -- OK
        //public static string GetPCByIpAddressRoute => $"Computer";
        //public static string GetPCByIdRoute(string computerId) => $"Computer/{computerId}";
        //public static string PostNewComputerRoute => "computer";
        //public static string PutComputerRoute => "computer";
        //public static string DeleteComputerByIdRoute(string computerId) => $"computer/{computerId}";
        //#endregion

        //#region -- GATE -- OK
        //public static string GetGateByListRoute => "gate/allactive/";
        //public static string GetGateByIdRoute(string gateId) => $"gate/byid/{gateId}";
        //public static string PostNewGateRoute => "gate";
        //public static string PutGateRoute => "gate";
        //public static string DeleteGateByIdRoute(string gateId) => $"gate/{gateId}";
        //#endregion

        //#region -- VEHICLE TYPE -- OK
        //public static string GetVehicleTypeByIdRoute(string vehicleTypeId) => $"vehicletype/byid/{vehicleTypeId}";
        //public static string GetAllVehicleTypesRoute => $"vehicletype/allactive";
        //#endregion

        //#region -- IDENTITY -- OK
        //public static string GetIdentityByIdRoute(string id) => $"identity/byid/{id}";
        //public static string GetIdentityByCodeRoute(string code) => $"identity/bycode/{code}";
        //public static string GetAllIdentities => "identity/allActive";
        //public static string PostNewIdentityRoute => "Identity";
        //public static string PutIdentityRoute => "Identity";
        //public static string DeleteIdentityByIdRoute(string gateId) => $"Identity/{gateId}";

        //#endregion

        //#region -- IDENTITY GROUP

        //#endregion

        //#region -- EVENT IN
        //public static string PostNewCardEventByIdRoute => "EventIn";
        //public static string GetFileNamesRoute(List<int> fileIds)
        //{
        //    string baseRoute = "PhysicalFile?";
        //    foreach (var item in fileIds)
        //    {
        //        baseRoute += $"Ids={item}&";
        //    }
        //    return baseRoute;
        //}
        //public static string PutEventInPlateById(string id) => $"EventIn/{id}";
        //public static string GetEventIns => $"EventIn";
        //#endregion

        //#region -- EVENT OUT
        //public static string PostNewCardEventOutByIdRoute => "EventOut";
        //public static string PutEventOutPlateById(string id) => $"EventOut/{id}";
        //public static string GetEventOuts => $"EventOut";
        //#endregion

        //#region -- ABNORMAL 
        //#region Alarm
        //public static string GetAbnormalsRoute => "abnormal";
        //public static string PostAbnormalRoute => "abnormal";
        //public static string PutAbnomalByIdRoute => "abnormal";
        //#endregion End Alarm
        //#endregion

        //#region -- REGISTERED VEHICLE
        //public static string GetRegisterVehicleByIdRoute(string id) => $"RegisteredVehicle/byid/{id}";
        //public static string GetRegisterVehicleByPlateNumberRoute(string plateNumber) => $"RegisteredVehicle/byplatenumber/{plateNumber}";
        //public static string GetAllRegisterVehicles => "RegisteredVehicle/allactive";
        //public static string PostNewRegisteredVehicle => "RegisteredVehicle";
        //public static string PutRegisteredVehicleRoute => "RegisteredVehicle";
        //#endregion

        //#region -- CUSTOMER
        //public static string GetCustomerByIdRoute(string customerId) => $"customer/byId/{customerId}";
        //public static string GetCustomerByCodeRoute(string code) => $"customer/byCode/{code}";
        //public static string PostNewCustomerRoute => "customer";
        //public static string PutCustomerRoute => "customer";
        //public static string DeleteCustomerByIdRoute(string customerId) => $"customer/{customerId}";
        //#endregion

        //#region -- CUSTOMER GROUP
        //public static string GetCustomerGroupByIdRoute(string customerGroupId) => $"customergroup/byId/{customerGroupId}";
        //public static string GetAllCustomerGroupsRoute => $"customergroup/allactive";
        //public static string PostNewCustomerGroupRoute => "customergroup";
        //public static string PutCustomerGroupRoute => "customergroup";
        //public static string DeleteCustomerGroupRoute(string customerGroupId) => $"customergroup/{customerGroupId}";
        //#endregion
    }
}
