using iParkingv5.ApiManager.interfaces;
using iParkingv5.Objects.Datas;
using iParkingv6.ApiManager;
using Kztek.Tool;
using Kztek.Tools;
using RestSharp;
using System;
using System.Collections.Generic;
using static iParkingv5.Objects.Enums.ParkingImageType;
using System.Threading.Tasks;
using iParkingv5.Objects.EventDatas;
using static iParkingv5.ApiManager.KzParkingv5Apis.KzParkingv5BaseApi;
using iParkingv5.Objects.Datas.parking_service;
using Microsoft.Extensions.Logging;

namespace iParkingv5.ApiManager.KzParkingv5Apis.services
{
    public class KzParkingv5ProcessService : iParkingProcessService
    {
        #region EVENT-IN
        public async Task<bool> UpdateEventInPlateAsync(string eventId, string newPlate, string oldPlate)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Update Event In Plate",
                         ("Id: " + eventId, "Old: " + oldPlate, "New: " + newPlate));
            server = server.StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/" + eventId;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "plateNumber",
                value = newPlate
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, RestSharp.Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_IN", mo_ta_them: "EventId: " + eventId +
                                                                                                                                 "\r\nOld Plate: " + oldPlate +
                                                                                                                                 " => New Plate: " + newPlate);
                return true;
            }
            return false;
        }
        public async Task<Tuple<EventInData, BaseErrorData>> PostCheckInAsync(
            string _laneId, string _plateNumber, Identity? identity, List<EmParkingImageType> validImageTypes, bool isForce = false, RegisteredVehicle? registeredVehicle = null, string _note = "")
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Start Check In", _laneId);
            if (identity == null)
            {
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Check In By Identity", (_laneId, identity));
                return await PostCheckInByPlateAsync(_laneId, _plateNumber, identity, validImageTypes, isForce, registeredVehicle, _note);
            }
            else
            {
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Check In By Plate", (_laneId, _plateNumber));
                return await PostCheckInByIdentityAsync(_laneId, _plateNumber, identity, validImageTypes, isForce, registeredVehicle, _note);
            }
        }

        public async Task<Tuple<EventInData, BaseErrorData>> PostCheckInByIdentityAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                         List<EmParkingImageType> validImageTypes, bool isForce = false,
                                                                         RegisteredVehicle? registeredVehicle = null, string _note = "")
        {
            server = server.StandardlizeServerName();
            string apiUrl = $"{server}event-in";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = identity.Code,
                identityType = identity.Type,
                plateNumber = _plateNumber,
                imageTypes = new List<int>(),
                force = isForce
            };

            foreach (var item in validImageTypes)
            {
                data.imageTypes.Add((int)item);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            string content = response.Item1;
            string errorMessage = response.Item2;
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            try
            {
                BaseErrorData errorData = null;
                EventInData eventInData = null;
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    errorData = NewtonSoftHelper<BaseErrorData>.GetBaseResponse(response.Item1);
                }
                else
                {
                    eventInData = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Item1);
                }
                return Tuple.Create<EventInData, BaseErrorData>(eventInData, errorData);
            }
            catch (Exception)
            {
            }

            return null;
        }
        public async Task<Tuple<EventInData, BaseErrorData>> PostCheckInByPlateAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                      List<EmParkingImageType> validImageTypes, bool isForce = false,
                                                                      RegisteredVehicle? registeredVehicle = null, string _note = "")
        {

            server = server.StandardlizeServerName();
            string apiUrl = $"{server}event-in";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = _plateNumber,
                identityType = IdentityType.PlateNumber,
                plateNumber = _plateNumber,
                imageTypes = new List<int>(),
                force = isForce
            };

            foreach (var item in validImageTypes)
            {
                data.imageTypes.Add((int)item);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            string content = response.Item1;
            string errorMessage = response.Item2;
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }

            try
            {
                BaseErrorData errorData = null;
                EventInData eventInData = null;
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    errorData = NewtonSoftHelper<BaseErrorData>.GetBaseResponse(response.Item1);
                }
                else
                {
                    eventInData = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Item1);
                }
                return Tuple.Create<EventInData, BaseErrorData>(eventInData, errorData);
            }
            catch (Exception)
            {
            }

            return null;
        }
        #endregion

        #region EVENT-OUT
        public async Task<Tuple<EventOutData, BaseErrorData>> PostCheckOutAsync(string _laneId, string _plateNumber, Identity? identitiy,
                                                                  List<EmParkingImageType> validImageTypes, bool isForce)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Start Check Out", _laneId);
            if (identitiy == null)
            {
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Check Out By Identity", (_laneId, identitiy));
                return await PostCheckOutByPlateAsync(_laneId, _plateNumber, identitiy, validImageTypes, isForce);
            }
            else
            {
                LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Check Out By Plate", (_laneId, _plateNumber));
                return await PostCheckOutByIdentityAsync(_laneId, _plateNumber, identitiy, validImageTypes, isForce);
            }
        }
        public async Task<Tuple<EventOutData, BaseErrorData>> PostCheckOutByIdentityAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                          List<EmParkingImageType> validImageTypes, bool isForce = false)
        {
            server = server.StandardlizeServerName();
            string apiUrl = $"{server}event-out";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = identity.Code,
                identityType = identity.Type,
                plateNumber = _plateNumber,
                imageTypes = new List<int>(),
                force = isForce
            };

            foreach (var item in validImageTypes)
            {
                data.imageTypes.Add((int)item);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            string content = response.Item1;
            string errorMessage = response.Item2;
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }

            try
            {
                BaseErrorData errorData = null;
                EventOutData eventOutData = null;
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    errorData = NewtonSoftHelper<BaseErrorData>.GetBaseResponse(response.Item1);
                }
                else
                {
                    eventOutData = NewtonSoftHelper<EventOutData>.GetBaseResponse(response.Item1);
                }
                return Tuple.Create<EventOutData, BaseErrorData>(eventOutData, errorData);
            }
            catch (Exception)
            {
            }

            return null;
        }
        public async Task<Tuple<EventOutData, BaseErrorData>> PostCheckOutByPlateAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                        List<EmParkingImageType> validImageTypes, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            server = server.StandardlizeServerName();
            string apiUrl = $"{server}event-out";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = _plateNumber,
                identityType = IdentityType.PlateNumber,
                plateNumber = _plateNumber,
                imageTypes = new List<int>(),
                force = isForce
            };

            foreach (var item in validImageTypes)
            {
                data.imageTypes.Add((int)item);
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);
            string content = response.Item1;
            string errorMessage = response.Item2;
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }

            try
            {
                BaseErrorData errorData = null;
                EventOutData eventOutData = null;
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    errorData = NewtonSoftHelper<BaseErrorData>.GetBaseResponse(response.Item1);
                }
                else
                {
                    eventOutData = NewtonSoftHelper<EventOutData>.GetBaseResponse(response.Item1);
                }
                return Tuple.Create<EventOutData, BaseErrorData>(eventOutData, errorData);
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<bool> UpdateEventOutPlate(string eventId, string newPlate, string oldPlate)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Update Event In Plate",
                         ("Id: " + eventId, "Old: " + oldPlate, "New: " + newPlate));
            server = server.StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventId;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "plateNumber",
                value = newPlate
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, RestSharp.Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_OUT", mo_ta_them: "EventId: " + eventId +
                                                                                                                                    "\r\nOld Plate: " + oldPlate +
                                                                                                                                    " => New Plate: " + newPlate); return true;
            }
            return false;
        }
        public async Task<bool> CommitOutAsync(EventOutData eventOut)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Commit Out", eventOut);
            server = server.StandardlizeServerName();
            string apiUrl = server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventOut.Id;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "approve",
                value = true
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, RestSharp.Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return Convert.ToBoolean(response.Item1);
            }
            return false;
        }
        public async Task<bool> CancelCheckOut(string eventOutId)
        {
            return false;
        }
        #endregion

        #region ALARM
        public async Task<AbnormalEvent> CreateAlarmAsync(string identityCode, string _laneId, string plate, AbnormalCode abnormalCode,
                                                Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isLaneIn,
                                                string _identityGroupId, string customerId,
                                                string registerVehicleId, string description)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Create Alarm Event");
            server = server.StandardlizeServerName();
            string apiUrl = server + "abnormal-event";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = identityCode,
                identityType = 0,
                Code = abnormalCode,
                plateNumber = plate,
                imageTypes = new List<int>(),
                Description = description,
            };

            foreach (KeyValuePair<EmParkingImageType, List<List<byte>>> kvp in imageDatas)
            {
                if (kvp.Value.Count > 0)
                {
                    data.imageTypes.Add((int)kvp.Key);
                }
            }

            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null, timeOut, RestSharp.Method.Post);

            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    AbnormalEvent kzBaseResponse = NewtonSoftHelper<AbnormalEvent>.GetBaseResponse(response.Item1);
                    return kzBaseResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;
        }
        #endregion

        public async Task<bool> SaveEventImage(string bucketName, string objKey, EmParkingImageType objType, List<byte> imageData)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Save Event Image");
            server = server.StandardlizeServerName();

            var options = new RestClientOptions(server)
            {
                MaxTimeout = 10000,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/s3", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("bucket", bucketName);
            request.AddParameter("objectKey", objKey);
            request.AddParameter("objectType", 0);
            request.AddFile($"file", imageData.ToArray(), "x.jpg");
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: request.Parameters);
            RestResponse response = await client.ExecuteAsync(request);
            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }

        public async Task<string> GetImageUrl(string bucketName, string objKey)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Get Display Image Url");
            server = server.StandardlizeServerName();
            string apiUrl = $"{server}s3/presigned-url";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "bucket",bucketName  },
                { "objectKey",objKey  },
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, null, headers, parameters,
                                                                  timeOut, Method.Get);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<string>(response.Item1.ToString());
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return "";
        }
        public async Task<string> GetFeeCalculate(string dateTimeIn, string dateTimeOut, string feeId)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Get Fee Calculate");
            server = server.StandardlizeServerName();
            string apiUrl = $"{server}charge-rate/compute";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                startTimeUtc = dateTimeIn,
                endTimeUtc = dateTimeOut,
                id = feeId,
            };
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, data, headers, null,
                                                                  timeOut, Method.Post);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                try
                {
                    return response.Item1.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return "";
        }
        public async Task<bool> UpdateBSXNote(string newNote, string eventId, bool isEventIn)
        {
            LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.System, "ParkingProcessService", "Update Note");
            server = server.StandardlizeServerName();
            string apiUrl = isEventIn ?
                server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventIn) + "/" + eventId :
                server + KzParkingv5ApiUrlManagement.PostObjectRoute(KzParkingv5ApiUrlManagement.EmParkingv5ObjectType.EventOut) + "/" + eventId
                ;
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var commitData = new List<CommitData>();
            commitData.Add(new CommitData()
            {
                op = "replace",
                path = "baseNote",
                value = newNote
            });
            var response = await BaseApiHelper.GeneralJsonAPIAsync(apiUrl, commitData, headers, null, timeOut, Method.Patch);
            if (!string.IsNullOrEmpty(response.Item1))
            {
                return true;
            }
            return false;
        }
    }
}
