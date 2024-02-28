using iParkingv5.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParkingv5_CustomerRegister.Databases
{
    public class tblFingerCustomer
    {
        public const string tblName = "tblFingerCustomer";
        public const string tblColId = "Id";
        public const string tblColFingerId = "FingerId";
        public const string tblColCustomerId = "CustomerId";
        public const string tblColFingerCustomerCode = "FingerCustomerCode";

        public static async Task<Tuple<List<string>, string>> GetRegisterFingersByCustomerId(string customerId)
        {
            string fingerCustomerCode = string.Empty;
            List<string> data = new List<string>();
            string cmd = $@"SELECT {tblColFingerId}, {tblColFingerCustomerCode} FROM {tblName} WHERE {tblColCustomerId} = '{customerId}'";
            DataTable? dtData = null;
            await Task.Run(() =>
            {
                dtData = StaticPool.mdb.FillData(cmd);
            });
            if (dtData == null) return Tuple.Create<List<string>, string>(new List<string>(), string.Empty);
            if (dtData.Rows.Count == 0) return Tuple.Create<List<string>, string>(new List<string>(), string.Empty);
            
            fingerCustomerCode = dtData.Rows[0][tblColFingerCustomerCode].ToString() ?? "";
            foreach (DataRow row in dtData.Rows)
            {
                string fingerId = row[tblColFingerId].ToString() ?? "";
                data.Add(fingerId);
            }
            return Tuple.Create<List<string>, string>(data, fingerCustomerCode);
        }

        public static string GetFingerCustomeCode(string customerId, out bool valid)
        {
            valid = false;
            string cmd = $@"SELECT TOP 1 {tblColFingerCustomerCode} FROM {tblName}
                            WHERE {tblColCustomerId} = '{customerId}'";
            DataTable dtData = StaticPool.mdb.FillData(cmd);
            if (dtData == null) return customerId + "-Finger";
            if (dtData.Rows.Count == 0) return Guid.NewGuid().ToString() + "-Finger";
            valid = true;
            return dtData.Rows[0][tblColFingerCustomerCode].ToString() ?? Guid.NewGuid().ToString() + "-Finger";
        }

        public static bool Insert(string customerId, string fingerId, string fingerCustomerCode)
        {
            string insertCmd = $@"INSERT INTO {tblName}({tblColCustomerId}, {tblColFingerId}, {tblColFingerCustomerCode})
                                  VALUES ('{customerId}', '{fingerId}', '{fingerCustomerCode}')";
            return StaticPool.mdb.ExecuteCommand(insertCmd);
        }
        public static bool DeleteByCustomerId(string customerId)
        {
            string deleteCmd = $@"DELETE {tblName} WHERE {tblColCustomerId} = '{customerId}'";
            return StaticPool.mdb.ExecuteCommand(deleteCmd);
        }
        public static bool DeleteByFingerId(ushort fingerId)
        {
            string deleteCmd = $@"Delete {tblName} WHERE {tblColFingerId}  = {fingerId}";
            return StaticPool.mdb.ExecuteCommand(deleteCmd);
        }
    }
}
