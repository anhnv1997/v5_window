using ALSE.Objects;
using iParkingv5.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSE
{
    public class tblController
    {
        public const string tblName = "tblController";
        public const string tbl_col_id = "id";
        public const string tbl_col_name = "name";
        public const string tbl_col_code = "code";
        public const string tbl_col_description = "description";
        public const string tbl_col_comport = "comport";
        public const string tbl_col_baudrate = "baudrate";
        public const string tbl_col_type = "type";
        public const string tbl_col_communication = "communication";

        public static async Task<ControllerCollection> GetControllerCollection()
        {
            ControllerCollection controllerCollection = new ControllerCollection();

            string cmd = $"SELECT * from {tblName} order by len({tbl_col_name}), {tbl_col_name}";
            DataTable? dtData = null;
            await Task.Run(() =>
            {
                dtData = StaticPool.mdb!.FillData(cmd);
            });

            if (dtData != null)
            {
                foreach (DataRow item in dtData.Rows)
                {
                    string id = item[tbl_col_id].ToString() ?? "";
                    string name = item[tbl_col_name].ToString() ?? "";
                    string code = item[tbl_col_code].ToString() ?? "";
                    string description = item[tbl_col_description].ToString() ?? "";
                    string comport = item[tbl_col_comport].ToString() ?? "0";
                    string strBaudrate = item[tbl_col_baudrate].ToString() ?? "0";
                    string str_type = item[tbl_col_type].ToString() ?? "";
                    string str_communication = item[tbl_col_communication].ToString() ?? "";

                    Controller controller = new Controller(id, name, code, description, comport, int.Parse(strBaudrate), int.Parse(str_type), int.Parse(str_communication));
                    controllerCollection.Add(controller);
                }
            }
            return controllerCollection;
        }
        public static async Task<string> InsertController(Controller controller)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{tbl_col_id}] varchar(50))
                                  Insert into {tblName}(
                                    {tbl_col_name}, {tbl_col_code}, {tbl_col_description}, {tbl_col_comport},
                                    {tbl_col_baudrate}, {tbl_col_type}, {tbl_col_communication}
                                  )
                                  OUTPUT inserted.{tbl_col_id} 
                                  Into @generated_keys
                                  values(
                                    N'{controller.name}', N'{controller.code}', '{controller.description}', '{controller.comport}',
                                      {controller.baudrate}, {controller.type}, {controller.communication})
                                  Select * from @generated_keys";
            DataTable? dtData = null;
            await Task.Run(() =>
            {
                dtData = StaticPool.mdb!.FillData(insertCMD);
            });
            if (dtData == null) return string.Empty;
            if (dtData.Rows.Count == 0) return string.Empty;
            return dtData.Rows[0][tbl_col_id].ToString() ?? "";
        }
        public static bool ModifyController(Controller controller)
        {
            string modifyCMD = $@"update {tblName} 
                                  set {tbl_col_name} = N'{controller.name}',
                                      {tbl_col_code} = N'{controller.code}',
                                      {tbl_col_description} = N'{controller.description}',
                                      {tbl_col_comport} = '{controller.comport}',
                                      {tbl_col_baudrate} = {controller.baudrate},
                                      {tbl_col_type} = {controller.type},
                                      {tbl_col_communication} = {controller.communication}
                                  Where {tbl_col_id} = '{controller.id}'";
            if (!StaticPool.mdb!.ExecuteCommand(modifyCMD))
            {
                if (!StaticPool.mdb.ExecuteCommand(modifyCMD))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool DeleteControllerById(string id)
        {
            string modifyCMD = $@"Delete {tblName} 
                                  Where {tbl_col_id} = '{id}'";
            if (!StaticPool.mdb!.ExecuteCommand(modifyCMD))
            {
                if (!StaticPool.mdb.ExecuteCommand(modifyCMD))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
