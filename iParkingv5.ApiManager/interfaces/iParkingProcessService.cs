using iParkingv5.Objects.Datas;
using System.Collections.Generic;
using static iParkingv5.Objects.Enums.ParkingImageType;
using System.Threading.Tasks;
using iParkingv5.Objects.Datas.parking_service;
using iParkingv5.Objects.EventDatas;
using System;

namespace iParkingv5.ApiManager.interfaces
{
    public interface iParkingProcessService
    {
        Task<Tuple<EventInData, BaseErrorData>> PostCheckInAsync(
    string _laneId, string _plateNumber, Identity identity, List<EmParkingImageType> validImageTypes,
    bool isForce = false, RegisteredVehicle registeredVehicle = null, string note = "");
        Task<bool> UpdateEventInPlateAsync(string eventId, string newPlate, string oldPlate);


        Task<bool> UpdateEventOutPlate(string eventId, string newPlate, string oldPlate);
        Task<Tuple<EventOutData, BaseErrorData>> PostCheckOutAsync(string _laneId, string _plateNumber, Identity identitiy, List<EmParkingImageType> validImageTypes, bool isForce);
        Task<bool> CommitOutAsync(EventOutData eventOut);
        Task<bool> CancelCheckOut(string eventOutId);

        Task<AbnormalEvent> CreateAlarmAsync(string identityCode, string laneId, string plate, AbnormalCode abnormalCode,
                                   Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isLaneIn, string _identityGroupId, string customerId,
                                   string registerVehicleId, string description);

        Task<string> GetFeeCalculate(string dateTimeIn, string dateTimeOut, string identityGroupID);
        Task<bool> UpdateBSXNote(string newNote, string eventId, bool isEventIn);
        Task<bool> SaveEventImage(string bucketName, string objKey, EmParkingImageType objType, List<byte> imageData);
        Task<string> GetImageUrl(string bucketName, string objKey);

    }
}
