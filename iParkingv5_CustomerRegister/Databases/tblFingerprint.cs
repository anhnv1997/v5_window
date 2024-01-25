using iParkingv5.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister.Databases
{
    public class tblFingerprint
    {
        public const string tblName = "tblFingerprint";
        public const string tblColId = "Id";
        public const string tblColFingerId = "FingerId";
        public const string tblColFingerData = "FingerData";
        public const string tblColDescription = "Description";

        public static bool InsertFinger(ushort fingerId, string fingerData)
        {
            string insertCmd = $@"INSERT INTO {tblName}({tblColFingerId},{tblColFingerData})
                                  VALUES('{fingerId}', '{fingerData}')";
            return StaticPool.mdb.ExecuteCommand(insertCmd);
        }
        public static bool UpdateFinger(ushort fingerId, string fingerData)
        {
            string insertCmd = $@"UPDATE {tblName} SET {tblColFingerData} = '{fingerData}'
                                  WHERE {tblColFingerId} = '{fingerId}'";
            return StaticPool.mdb.ExecuteCommand(insertCmd);
        }

        public static async Task<List<Tuple<string, string>>> GetFingerDatas(List<string> fingerIds)
        {
            List<Tuple<string, string>> data = new List<Tuple<string, string>>();
            List<string> temps = new List<string>();
            foreach (string fingerId in fingerIds)
            {
                temps.Add("'" + fingerId + "'");
            }
            string condition = string.Join(",", temps);
            condition = "(" + condition + ")";
            string cmd = $@"SELECT * FROM {tblName} WHERE {tblColFingerId} IN {condition} ORDER BY {tblColFingerId} ASC";
            DataTable? dtdata = null;
            await Task.Run(() =>
            {
                dtdata = StaticPool.mdb.FillData(cmd);
            });
            if (dtdata == null) return new List<Tuple<string, string>>();
            foreach (DataRow row in dtdata.Rows)
            {
                string fingerId = row[tblColFingerId].ToString() ?? string.Empty;
                string fingerData = row[tblColFingerData].ToString() ?? string.Empty;
                data.Add(Tuple.Create<string, string>(fingerId, fingerData));
            }
            return data;
        }
    }
}
