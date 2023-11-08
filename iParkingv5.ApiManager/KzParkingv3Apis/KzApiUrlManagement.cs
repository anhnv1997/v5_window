using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public class KzApiUrlManagement
    {
        public const string BaseRoute = "api";

        #region AuthorizedRelated
        public const string PostLoginRoute = "login";
        public string GetPerrmissionById(string userId) => "login/UserPermissions/" + userId;
        #endregion End AuthorizedRelated

        #region Card Related

        #endregion End Card Related

        #region System Config Related
        //--PC
        public const string GetPCByListRoute = "tblPC/byList";
        public const string GetPCByIdRoute = "tblPC/byId";

        //--Controller
        public const string GetControllerByListRoute = "tblController/byList";
        public const string GetControllerByIdRoute = "tblController/byId";

        //--Camera
        public const string GetCameraByListRoute = "tblCamera/byList";
        public const string GetCameraByIdRoute = "tblCamera/byId";

        //--Lane
        public const string GetLaneByListRoute = "tblLane/byList";
        public const string GetLaneByIdRoute = "tblLane/byId";

        //--Gate
        public const string GetGateByListRoute = "tblGate/byList";
        public const string GetGateByIdRoute = "tblGate/byId";

        //--Led
        public const string GetLedByListRoute = "tblLED/byList";
        public const string GetLedByIdRoute = "tblLED/byId";

        //--System Config
        public const string GetSystemConfigRoute = "tblSystemConfig";
        public const string GetServerTimeRoute = "Server/time";
        #endregion End System Config Related

        #region Event Related
        //--Card Event
        public const string PostParkingVehiclesPagingRoute = "tblCardEvent/ParkingVehiclesPaging";
        public const string GetCardEventByPagingInOutRoute = "tblcardevent/byPagingInOut";
        public const string GetCardEventByIdRoute = "tblCardEvent/byId";
        public const string PostNewCardEventByIdRoute = "tblCardEvent";
        public const string DeleteOneCardEventByIdRoute = "tblCardEvent";
        public const string GetParkingVehicleByCardNumberRoute = "tblCardEvent/parkingVehiceByCardNumber";
        public const string GetParkingVehicleByPlateNumberRoute = "tblCardEvent/parkingVehiceByPlateNumber";
        public const string PostParkingFeeRoute = "blCardEvent/parkingFee";
        //--Parking Event
        public const string PutGoneOutEventCardGroupIdRoute = "parkingevent/Update/GoneOutEventCardGroupId";
        public const string PostCheckInRoute = "parkingevent/checkin";
        public const string PostCheckOutRoute = "parkingevent/checkout";
        #endregion End Event Related

        #region Other
        //--Fee
        public const string GetFeeByIdRoute = "tblFee/byId";
        public const string GetFeeByListRoute = "tblFee/byList";
        public const string PostNewFeeByIdRoute = "tblFee";
        public const string PutOneFeeByIdRoute = "tblFee";
        public const string DeleteOneFeeByIdRoute = "tblFee";

        //--User
        public const string GetUserByIdRoute = "temp/User/byId";
        public const string GetUserByUsernameRoute = "temp/User/byUserName";
        public const string PostNewUserByIdRoute = "temp/User";
        public const string PutUserById = "temp/User";

        //--License
        public const string GetLicenseRoute = "License/getlicense";
        #endregion End Other

        #region Vehicle Group
        public const string GetVehicleGroupByIdRoute = "tblVehicleGroup/byId";
        public const string GetVehicleGroupByListRoute = "tblVehicleGroup/byList";
        public const string PostNewVehicleGroupByIdRoute = "tblVehicleGroup";
        public const string PutVehicleGroupByIdRoute = "tblVehicleGroup";
        public const string DeleteOneVehicleGroupByIdRoute = "tblVehicleGroup";
        #endregion End Vehicle Group

        #region Customer Related
        //--Customer
        public const string GetCustomerByIdRoute = "tblCustomer/byId";
        public const string GetCustomerByPagingRoute = "tblCustomer/byPaging";
        public const string GetCustomerByCodeRoute = "tblCustomer/byCode";
        public const string GetCustomerByPlateRoute = "tblCustomer/byPlate";
        public const string PostNewCustomerById = "tblCustomer";
        public const string PutCustomerById = "tblCustomer";
        public const string DeleteCustomerById = "tblCustomer";

        //--CustomerGroup
        public const string GetCustomerGroupByIdRoute = "tblCustomerGroup/byId";
        public const string PostCustomerGroupByIdRoute = "tblCustomerGroup";
        public const string PutCustomerGroupByIdRoute = "tblCustomerGroup";
        public const string DeleteCustomerGroupByIdRoute = "tblCustomerGroup";
        #endregion End Customer Related

        #region Alarm
        public const string GetAlarmByPagingRoute = "tblAlarm/byPaging";
        public const string GetAlarmByIdRoute = "tblAlarm/byId";
        public const string PostAlarmByIdRoute = "tblAlarm";
        public const string PitAlarmByIdRoute = "tblAlarm";
        public const string DeleteAlarmByIdRoute = "tblAlarm";
        #endregion End Alarm

        #region Black List
        public const string GetBlackListRoute = "tblBlackList";
        #endregion End Black List
    }
}
