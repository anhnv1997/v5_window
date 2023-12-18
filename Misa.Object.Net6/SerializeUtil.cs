using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Misa.Object
{
    /// <summary>
    /// Lớp xử lý các hành động chuyển dữ liệu Object vs String
    /// </summary>
    public class SerializeUtil
    {
        /// <summary>
        /// Fix format date sử dụng local
        /// </summary>
        private const DateTimeZoneHandling mscDateTimeZoneHandling = DateTimeZoneHandling.Local;

        /// <summary>
        /// Chuyển đối tượng thành json
        /// </summary>
        public static string SerializeObject(object data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = mscDateTimeZoneHandling
            };
            return JsonConvert.SerializeObject(data, settings);
        }

        /// <summary>
        /// Chuyển đối tượng thành json
        /// </summary>
        public static T DeserializeObject<T>(string data)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                DateTimeZoneHandling = mscDateTimeZoneHandling
            };
            return JsonConvert.DeserializeObject<T>(data, setting);
        }

        /// <summary>
        /// Chuyển đối tượng thành json
        /// </summary>
        public static object DeserializeObject(string data, Type objectType)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                DateTimeZoneHandling = mscDateTimeZoneHandling
            };
            return JsonConvert.DeserializeObject(data, objectType, setting);
        }

        /// <summary>
        /// Sử dụng DataContractSerializer để chuyển dữ liệu thành string
        /// </summary>
        /// <param name="data">dữ liệu</param>
        public static string SerializeToXMLString(object data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(data.GetType());
                serializer.WriteObject(ms, data);
                ms.Position = 0;
                using (StreamReader streamReader = new StreamReader(ms))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Sử dụng DataContractSerializer để chuyển string về dữ liệu
        /// </summary>
        /// <param name="type">kiểu dữ liệu</param>
        /// <param name="data">string data</param>
        public static object DeserializeFromXMLString(Type type, string data)
        {
            string strXMLDeclaration = "<?xml version=\"1.0\" encoding=\"utf-16LE\"?>";
            if (!data.StartsWith(strXMLDeclaration))
            {
                data = strXMLDeclaration + data;
            }

            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(data)))
            {
                DataContractSerializer serializer = new DataContractSerializer(type);
                return serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Sử dụng DataContractSerializer để chuyển string về dữ liệu
        /// </summary>
        /// <typeparam name="T">kiểu dữ liệu</typeparam>
        /// <param name="data">string data</param>
        public static T DeserializeFromoXMLString<T>(string data)
        {
            return (T)DeserializeFromXMLString(typeof(T), data);
        }

        /// <summary>
        /// Parse chuỗi dữ liệu là mảng guid truyền lên từ client thành chuỗi đầu vào sql để xử lý cắt thành bảng
        /// </summary>
        /// <param name="value">mảng guid đã stringify</param>
        /// <param name="ch">ký tự ngăn cách, mặc định là ;</param>
        /// <returns>chuỗi đầu vào sql để cắt thành bảng</returns>
        public static string ParseListToSqlString<T>(string value, string ch = ";")
        {
            List<T> values = SerializeUtil.DeserializeObject<List<T>>(value);
            return string.Format("{0}{1}{0}", ch, string.Join(ch, values));
        }

        /// <summary>
        /// parse chuỗi tham số truyền lên từ client thành dictionary
        /// </summary>
        /// <param name="parameter">chuỗi json tham số</param>
        /// <returns>Kết quả tự động xử lý case các value phù hợp về Date, Guid</returns>
        public static Dictionary<string, object> ParseClientParam(string parameter)
        {
            //Xử lý tham số báo cáo truyền lên thành dic
            Dictionary<string, object> dicTemp = SerializeUtil.DeserializeObject<Dictionary<string, object>>(parameter),
                result = new Dictionary<string, object>();

            //Xử lý tham số Guid
            object value;
            foreach (string key in dicTemp.Keys)
            {
                value = dicTemp[key];

                if (value != null)
                {
                    if (value is IList lstData)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < lstData.Count; i++)
                        {
                            if (i > 0)
                            {
                                sb.Append(";");
                            }

                            sb.Append(lstData[i].ToString());
                        }

                        value = sb.ToString();
                    }
                    else if (dicTemp[key] is string)
                    {
                        value = ParseClientParamValue((string)dicTemp[key]);
                    }
                }

                result.Add(key, value);
            }

            return result;
        }

        /// <summary>
        /// Chuyển string dữ liệu về đúng kiểu gần nhất
        /// Sử dụng để convert tham số báo cáo về đúng kiểu
        /// </summary>
        /// <param name="value">string dữ liệu truyền từ client</param>
        private static object ParseClientParamValue(string value)
        {
            if (Guid.TryParse(value, out Guid gValue))
            {
                return gValue;
            }

            return value;
        }
    }
}