using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv6.ApiManager.KzParkingv3Apis
{
    public class KzApiUrlManagement
    {
        public static string BaseRoute => "api";

        #region AuthorizedRelated
        public static string PostLoginRoute => "user/login";
        #endregion End AuthorizedRelated

        #region Card Related
        //--CardGroup
        public static string GetCardGroupByListRoute => "tblCardGroup/byList";
        public static string GetAllCardGroupRoute => "tblCardGroup";
        public static string GetCardGroupByIdRoute => "tblCardGroup/byId";

        //--Card
        public static string GetCardByIdRoute => "tblCard/byId";
        public static string GetCardByPlateRoute => "tblCard/byPlate";
        public static string GetCardByPagingRoute => "tblCard/byPaging";
        public static string GetCardByCardNumberRoute => "tblCard/byCardNumber";
        #endregion End Card Related

        #region System Config Related
        //--PC
        public static string GetPCByIpAddressRoute(string key) => "Computer/byIPAddress/" + key;
        public static string GetPCByIdRoute(string key) => "Computer/byid/" + key;

        //--Controller
        public static string GetControllerByIdRoute(string key) => "controlunit/byid/"+key;
        public static string GetControllerByComputerIdRoute(string key) => "controlunit/bycomputerid/" + key;

        //--Camera
        public static string GetCameraByIdRoute(string key) => $"camera/byid/{key}";
        public static string GetCameraByComputerIdRoute(string key) => "camera/bycomputerid/" +key;

        //--Lane
        public static string GetLaneByIdRoute(string key) => "lane/byid/" + key;
        public static string GetLaneByComputerIdRoute(string key) => "lane/bycomputerid/" + key;

        //--Gate
        public static string GetGateByListRoute => "gate/allactive/";
        public static string GetGateByIdRoute(string key) => "gate/byid/" + key;

        //--Led
        public static string GetLedByIdRoute(string key) => "parkingled/byId/" + key;
        public static string GetLedByComputerIdRoute(string key) => "parkingled/bycomputerid/" + key;
        #endregion End System Config Related

        #region Event Related
        //--Card Event
        public static string PostParkingVehiclesPagingRoute => "tblCardEvent/ParkingVehiclesPaging";
        public static string GetCardEventByPagingInOutRoute => "tblcardevent/byPagingInOut";
        public static string GetCardEventByIdRoute => "tblCardEvent/byId";
        public static string PostNewCardEventByIdRoute => "tblCardEvent";
        public static string DeleteOneCardEventByIdRoute => "tblCardEvent";
        public static string GetParkingVehicleByCardNumberRoute => "tblCardEvent/parkingVehiceByCardNumber";
        public static string GetParkingVehicleByPlateNumberRoute => "tblCardEvent/parkingVehiceByPlateNumber";
        public static string PostParkingFeeRoute => "blCardEvent/parkingFee";
        //--Parking Event
        public static string PutGoneOutEventCardGroupIdRoute => "parkingevent/Update/GoneOutEventCardGroupId";
        public static string PostCheckInRoute => "parkingevent/checkin";
        public static string PostCheckOutRoute => "parkingevent/checkout";
        #endregion End Event Related

        #region Other
        //--Fee
        public static string GetFeeByIdRoute => "tblFee/byId";
        public static string GetFeeByListRoute => "tblFee/byList";
        public static string PostNewFeeByIdRoute => "tblFee";
        public static string PutOneFeeByIdRoute => "tblFee";
        public static string DeleteOneFeeByIdRoute => "tblFee";

        //--User
        public static string GetUserByIdRoute => "temp/User/byId";
        public static string GetUserByUsernameRoute => "temp/User/byUserName";
        public static string PostNewUserByIdRoute => "temp/User";
        public static string PutUserById => "temp/User";

        //--License
        public static string GetLicenseRoute => "License/getlicense";
        #endregion End Other

        #region Vehicle Group
        public static string GetVehicleGroupByIdRoute => "tblVehicleGroup/byId";
        public static string GetVehicleGroupByListRoute => "tblVehicleGroup/byList";
        public static string PostNewVehicleGroupByIdRoute => "tblVehicleGroup";
        public static string PutVehicleGroupByIdRoute => "tblVehicleGroup";
        public static string DeleteOneVehicleGroupByIdRoute => "tblVehicleGroup";
        #endregion End Vehicle Group

        #region Customer Related
        //--Customer
        public static string GetCustomerByIdRoute => "tblCustomer/byId";
        public static string GetCustomerByPagingRoute => "tblCustomer/byPaging";
        public static string GetCustomerByCodeRoute => "tblCustomer/byCode";
        public static string GetCustomerByPlateRoute => "tblCustomer/byPlate";
        public static string PostNewCustomerById => "tblCustomer";
        public static string PutCustomerById => "tblCustomer";
        public static string DeleteCustomerById => "tblCustomer";

        //--CustomerGroup
        public static string GetCustomerGroupByIdRoute => "tblCustomerGroup/byId";
        public static string PostCustomerGroupByIdRoute => "tblCustomerGroup";
        public static string PutCustomerGroupByIdRoute => "tblCustomerGroup";
        public static string DeleteCustomerGroupByIdRoute => "tblCustomerGroup";
        #endregion End Customer Related

        #region Alarm
        public static string GetAlarmByPagingRoute => "tblAlarm/byPaging";
        public static string GetAlarmByIdRoute => "tblAlarm/byId";
        public static string PostAlarmByIdRoute => "tblAlarm";
        public static string PitAlarmByIdRoute => "tblAlarm";
        public static string DeleteAlarmByIdRoute => "tblAlarm";
        #endregion End Alarm

        #region Black List
        public static string GetBlackListRoute => "tblBlackList";
        #endregion End Black List
    }
}
