using iParkingv5.Objects;
using iParkingv5_CustomerRegister.Objects;
using iParkingv6.Objects.Datas;
using Kztek.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister.Databases
{
    public class tblFingerControlUnit
    {
        public const string tblName = "tblFingerControlUnit";
        public const string tblColId = "Id";
        public const string tblColFingerId = "FingerId";
        public const string tblColControlUnitId = "ControlUnitId";
        public const string tblColControlUnitUserId = "ControlUnitUserId";
        public const string tblColCustomerId = "CustomerId";
        public const string tblColFingerIndex = "FingerIndex";

        public static int GetControlUnitUserId(string customerId, string controlUnitId, out bool valid)
        {
            valid = false;
            string cmd = $@"SELECT TOP 1 {tblColControlUnitUserId} FROM {tblName}
                            WHERE {tblColCustomerId} = '{customerId}' AND {tblColControlUnitId} = '{controlUnitId}'";
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.SQL, cmd);
            DataTable dtData = StaticPool.mdb.FillData(cmd) ?? new DataTable();
            if (dtData.Rows.Count > 0)
            {
                valid = true;
                return int.Parse(dtData.Rows[0][tblColControlUnitUserId].ToString());
            }
            else
            {
                string selectCMD = $@"SELECT TOP 1 {tblColControlUnitUserId} FROM {tblName}
                                       WHERE {tblColControlUnitId} = '{controlUnitId}'
                                      ORDER BY {tblColControlUnitUserId} DESC";
                LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.SQL, selectCMD);
                DataTable dtUserId = StaticPool.mdb.FillData(selectCMD) ?? new DataTable();
                if (dtUserId.Rows.Count == 0) return 1;
                return int.Parse(dtUserId.Rows[0][tblColControlUnitUserId].ToString() ?? "") + 1;
            }
        }
        public static bool Insert(string controlUnitId, int controlUnitUserId, string customerId)
        {
            Delete(customerId, controlUnitId);
            string insertCMD = $@"INSERT INTO {tblName}({tblColControlUnitId}, {tblColControlUnitUserId}, {tblColCustomerId})
                                  VALUES('{controlUnitId}', '{controlUnitUserId}', '{customerId}')";
            return StaticPool.mdb.ExecuteCommand(insertCMD);
        }

        public static bool Delete(string customerId, string controlUnitId)
        {
            string deleteCmd = $"DELETE {tblName} WHERE {tblColCustomerId} = '{customerId}' AND {tblColControlUnitId} = '{controlUnitId}'";
            return StaticPool.mdb.ExecuteCommand(deleteCmd);
        }

        public static string GetCustomerId(string controlUnitId, string userId)
        {
            string selectCmd = $@"SELECT TOP 1 {tblColCustomerId} FROM {tblName}
                                  WHERE {tblColControlUnitId} = '{controlUnitId}' AND {tblColControlUnitUserId} = '{userId}'";
            LogHelper.Log(LogHelper.EmLogType.WARN, LogHelper.EmObjectLogType.SQL, selectCmd);
            DataTable dtData = StaticPool.mdb.FillData(selectCmd) ?? new DataTable();
            if (dtData.Rows.Count > 0)
            {
                return dtData.Rows[0][tblColCustomerId].ToString() ?? string.Empty;
            }
            return string.Empty;
        }
    }
}
