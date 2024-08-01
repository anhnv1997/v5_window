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
        public async Task<EventInData> PostCheckInAsync(
            string _laneId, string _plateNumber, Identity? identity, Dictionary<EmParkingImageType, List<List<byte>>> imageKeys, bool isForce = false, RegisteredVehicle? registeredVehicle = null, string _note = "")
        {
            if (identity == null)
            {
                return await PostCheckInByPlateAsync(_laneId, _plateNumber, identity, imageKeys, isForce, registeredVehicle, _note);
            }
            else
            {
                return await PostCheckInByIdentityAsync(_laneId, _plateNumber, identity, imageKeys, isForce, registeredVehicle, _note);
            }
        }

        public async Task<EventInData> PostCheckInByIdentityAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                         Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isForce = false,
                                                                         RegisteredVehicle? registeredVehicle = null, string _note = "")
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "event-in";
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
                    EventInData addEventInResponse = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Item1);
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;

            //if (!string.IsNullOrEmpty(response.Item1))
            //{
            //    LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.System, specailName: "LPR_EDIT_IN", mo_ta_them: "EventId: " + eventId +
            //                                                                                                                     "\r\nOld Plate: " + oldPlate +
            //                                                                                                                     " => New Plate: " + newPlate);
            //    return true;
            //}
            //return false;

            //server = server.StandardlizeServerName();

            //var options = new RestClientOptions(server)
            //{
            //    MaxTimeout = 10000,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/event-in", Method.Post);
            //request.AddHeader("Authorization", "Bearer " + token);
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("laneId", _laneId);
            //request.AddParameter("identityCode", identity.Code);
            //request.AddParameter("identityType", "0");
            //request.AddParameter("plateNumber", _plateNumber);
            //request.AddParameter("force", isForce);

            //int i = 0;
            //foreach (KeyValuePair<EmParkingImageType, List<byte>> kvp in imageDatas)
            //{
            //    if (kvp.Value.Count > 0)
            //    {
            //        //request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
            //        request.AddParameter($"images[{i}].Type", (int)kvp.Key);
            //        i++;
            //    }
            //}
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: request.Parameters);
            //RestResponse response = await client.ExecuteAsync(request);
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: response.Content, obj: response.StatusCode);
            //if (!string.IsNullOrEmpty(response.Content))
            //{
            //    try
            //    {
            //        EventInData addEventInResponse = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Content);
            //        return addEventInResponse;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return null;
        }
        public async Task<EventInData> PostCheckInByPlateAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                      Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isForce = false,
                                                                      RegisteredVehicle? registeredVehicle = null,
                                                                      string _note = "")
        {

            server = server.StandardlizeServerName();
            string apiUrl = server + "event-in";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = _plateNumber,
                identityType = identity.Type,
                plateNumber = _plateNumber,
                imageTypes = new List<int>(),
                force = isForce
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
                    EventInData addEventInResponse = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Item1);
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;

            //server = server.StandardlizeServerName();

            //var options = new RestClientOptions(server)
            //{
            //    MaxTimeout = 10000,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/event-in", Method.Post);
            //request.AddHeader("Authorization", "Bearer " + token);
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("laneId", _laneId);
            //request.AddParameter("identityCode", _plateNumber);
            //request.AddParameter("identityType", 4);
            //request.AddParameter("plateNumber", _plateNumber);
            //request.AddParameter("force", isForce);

            //int i = 0;
            //foreach (KeyValuePair<EmParkingImageType, List<byte>> kvp in imageDatas)
            //{
            //    if (kvp.Value.Count > 0)
            //    {
            //        //request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
            //        request.AddParameter($"images[{i}].Type", (int)kvp.Key);
            //    }
            //    i++;
            //}
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: request.Parameters);
            //RestResponse response = await client.ExecuteAsync(request);
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: response.Content, obj: response.StatusCode);
            //if (!string.IsNullOrEmpty(response.Content))
            //{
            //    try
            //    {
            //        EventInData addEventInResponse = NewtonSoftHelper<EventInData>.GetBaseResponse(response.Content);
            //        return addEventInResponse;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return null;
        }
        #endregion

        #region EVENT-OUT
        public async Task<AddEventOutResponse> PostCheckOutAsync(string _laneId, string _plateNumber, Identity? identitiy,
                                                                 Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isForce)
        {
            if (identitiy == null)
            {
                return await PostCheckOutByPlateAsync(_laneId, _plateNumber, identitiy, imageDatas, isForce);
            }
            else
            {
                return await PostCheckOutByIdentityAsync(_laneId, _plateNumber, identitiy, imageDatas, isForce);
            }
        }
        public async Task<AddEventOutResponse> PostCheckOutByIdentityAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                           Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isForce = false)
        {

            server = server.StandardlizeServerName();
            string apiUrl = server + "event-out";
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
                    AddEventOutResponse addEventInResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Item1);
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;



            //server = server.StandardlizeServerName();

            //var options = new RestClientOptions(server)
            //{
            //    MaxTimeout = 10000,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/event-out", Method.Post);
            //request.AddHeader("Authorization", "Bearer " + token);
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("laneId", _laneId);
            //request.AddParameter("identityCode", identity.Code);
            //request.AddParameter("identityType", identity.Type);
            //request.AddParameter("plateNumber", _plateNumber);
            //request.AddParameter("force", isForce);

            //int i = 0;
            //foreach (KeyValuePair<EmParkingImageType, List<byte>> kvp in imageDatas)
            //{
            //    if (kvp.Value.Count > 0)
            //    {
            //        //request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
            //        request.AddParameter($"images[{i}].Type", (int)kvp.Key);
            //        i++;
            //    }
            //}
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: request.Parameters);
            //RestResponse response = await client.ExecuteAsync(request);
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: response.Content, obj: response.StatusCode);
            //if (!string.IsNullOrEmpty(response.Content))
            //{
            //    try
            //    {
            //        AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Content);
            //        return addEventOutResponse;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return null;
        }
        public async Task<AddEventOutResponse> PostCheckOutByPlateAsync(string _laneId, string _plateNumber, Identity? identity,
                                                                        Dictionary<EmParkingImageType, List<List<byte>>> imageDatas, bool isForce = false, RegisteredVehicle? registeredVehicle = null)
        {
            server = server.StandardlizeServerName();
            string apiUrl = server + "event-out";
            //Gửi API
            Dictionary<string, string> headers = new Dictionary<string, string>()
             {
                 { "Authorization","Bearer " + token  }
             };
            var data = new
            {
                laneId = _laneId,
                identityCode = _plateNumber,
                identityType = identity.Type,
                plateNumber = _plateNumber,
                imageTypes = new List<int>(),
                force = isForce
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
                    AddEventOutResponse addEventInResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Item1);
                    return addEventInResponse;
                }
                catch (Exception)
                {
                }
            }
            return null;

            //server = server.StandardlizeServerName();

            //var options = new RestClientOptions(server)
            //{
            //    MaxTimeout = 10000,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/event-out", Method.Post);
            //request.AddHeader("Authorization", "Bearer " + token);
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("laneId", _laneId);
            //request.AddParameter("identityCode", _plateNumber);
            //request.AddParameter("identityType", 4);
            //request.AddParameter("plateNumber", _plateNumber);
            //request.AddParameter("force", isForce);

            //int i = 0;
            //foreach (KeyValuePair<EmParkingImageType, List<byte>> kvp in imageDatas)
            //{
            //    if (kvp.Value.Count > 0)
            //    {
            //        request.AddParameter($"images[{i}].Type", (int)kvp.Key);
            //        i++;
            //    }
            //}
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: request.Parameters);
            //RestResponse response = await client.ExecuteAsync(request);
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: response.Content, obj: response.StatusCode);
            //if (!string.IsNullOrEmpty(response.Content))
            //{
            //    try
            //    {
            //        AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Content);
            //        return addEventOutResponse;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return null;
        }

        public async Task<bool> UpdateEventOutPlate(string eventId, string newPlate, string oldPlate)
        {
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
        public async Task<bool> CommitOutAsync(AddEventOutResponse eventOut)
        {
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
                //AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Item1);
                //return addEventOutResponse;
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

            //server = server.StandardlizeServerName();


            //var options = new RestClientOptions(server)
            //{
            //    MaxTimeout = 10000,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/abnormal-event", Method.Post);
            //request.AddHeader("Authorization", "Bearer " + token);
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("laneId", _laneId);
            //request.AddParameter("identityCode", identityCode);
            //request.AddParameter("identityType", 0);
            //request.AddParameter("Code", abnormalCode);
            //request.AddParameter("PlateNumber", plate);
            //request.AddParameter("Description", description);

            //int i = 0;
            //foreach (KeyValuePair<EmParkingImageType, List<byte>> kvp in imageDatas)
            //{
            //    if (kvp.Value.Count > 0)
            //    {
            //        //request.AddFile($"images[{i}].File", kvp.Value.ToArray(), "x.jpg");
            //        request.AddParameter($"images[{i}].Type", (int)kvp.Key);
            //        i++;
            //    }
            //}
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: request.Parameters);
            //RestResponse response = await client.ExecuteAsync(request);
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: response.Content, obj: response.StatusCode);
            //if (!string.IsNullOrEmpty(response.Content))
            //{
            //    try
            //    {
            //        AbnormalEvent kzBaseResponse = NewtonSoftHelper<AbnormalEvent>.GetBaseResponse(response.Content);
            //        return kzBaseResponse != null;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return false;
        }
        #endregion

        public async Task<bool> SaveEventImage(string bucketName, string objKey, EmParkingImageType objType, List<byte> imageData)
        {
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
            //LogHelper.Log(LogHelper.EmLogType.INFOR, LogHelper.EmObjectLogType.Api, mo_ta_them: response.Content, obj: response.StatusCode);
            //if (!string.IsNullOrEmpty(response.Content))
            //{
            //    try
            //    {
            //        AddEventOutResponse addEventOutResponse = NewtonSoftHelper<AddEventOutResponse>.GetBaseResponse(response.Content);
            //        return addEventOutResponse;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //return null;
        }

        public async Task<string> GetImageUrl(string bucketName, string objKey)
        {
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
        public async Task<string> GetFeeCalculate(string dateTimeIn, string dateTimeOut, string identityGroupID)
        {
            server = server.StandardlizeServerName();
            string apiUrl = $"{server}charge/calculate";

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                { "Authorization","Bearer " + token  }
            };
            var data = new
            {
                dateTimeIn = dateTimeIn,
                dateTimeOut = dateTimeOut,
                identityGroupId = identityGroupID,
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
