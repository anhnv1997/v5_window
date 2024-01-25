using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;

namespace iParkingv5.Objects.Databases
{
    public class Mdb
    {
        private int _timeout;

        // MS SQL SERVER
        private readonly string _sqlServerName = @"DCTHANH\SQLEXPRESS";
        private readonly string _sqlDatabaseName = "";
        private readonly string _sqlAuthentication = "Windows Authentication";
        private readonly string _sqlUserName = "sa";
        private readonly string _sqlPassword = "123456";

        // MS ACCESS
        private readonly string _mdbFilePath = "";
        private readonly string _mdbPassword = "17032008";

        private SqlConnection _sqlConnection;
        private OleDbConnection _mdbConnection;

        private readonly bool _isMdb;

        public Mdb(string sqlServername, string sqlDatabaseName, string sqlAuthentication, string sqlUsername,
            string sqlPassword, string mdbFilepath, string mdbPassword, bool isMdb, SqlConnection sqlConnection,
            OleDbConnection mdbConnection)
        {
            // MS SQL SERVER
            _sqlServerName = sqlServername;
            _sqlDatabaseName = sqlDatabaseName;
            _sqlAuthentication = sqlAuthentication;
            _sqlUserName = sqlUsername;
            _sqlPassword = sqlPassword;

            // MS ACCESS
            _mdbFilePath = mdbFilepath;
            _mdbPassword = mdbPassword;

            _isMdb = isMdb;
            _sqlConnection = sqlConnection;
            _mdbConnection = mdbConnection;
        }

        // MS SQL SERVER
        public Mdb(string sqlServername, string sqlDatabaseName, string sqlAuthentication, string sqlUsername, string sqlPassword)
        {
            _sqlServerName = sqlServername;
            _sqlDatabaseName = sqlDatabaseName;
            _sqlAuthentication = sqlAuthentication;
            _sqlUserName = sqlUsername;
            _sqlPassword = sqlPassword;
            _isMdb = false;
        }

        // MS ACCESS
        public Mdb(string mdbFilepath, string mdbPassword, SqlConnection sqlConnection, OleDbConnection mdbConnection)
        {
            _mdbFilePath = mdbFilepath;
            _mdbPassword = mdbPassword;
            _sqlConnection = sqlConnection;
            _mdbConnection = mdbConnection;

            _isMdb = true;
        }

        private bool OpenMdb()
        {
            if (!_isMdb)
            {
            reconnect:
                try
                {
                    _timeout = _timeout + 1;
                    var strConn = "";
                    if (_sqlAuthentication == "Windows Authentication")
                    {
                        strConn = "Data Source=" + _sqlServerName + ";" +
                                  "Initial Catalog=" + _sqlDatabaseName + ";" +
                                  "Integrated Security=true;Pooling=False" +
                                  ";MultipleActiveResultSets=True";

                    }
                    else
                    {
                        strConn = "server=" + _sqlServerName + ";database=" + _sqlDatabaseName + ";uid=" + _sqlUserName + ";pwd=" + _sqlPassword + ";MultipleActiveResultSets=True";
                    }
                    // Thuc thi chuoi ket noi
                    _sqlConnection = new SqlConnection(strConn);
                    // Mo ket noi
                    _sqlConnection.Open();
                    if (_sqlConnection.State == ConnectionState.Open)
                        return true;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    if (_timeout < 2)
                        goto reconnect;
                }
            }
            else
            {
                try
                {
                    _mdbConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + _mdbFilePath + "';Persist Security Info=false;Jet OLEDB:Database Password=" + _mdbPassword);
                    _mdbConnection.Open();
                    if (_mdbConnection.State == ConnectionState.Open)
                        return true;
                }
                catch (Exception ex)
                {
                }
            }
            return false;
        }

        // Dong ket noi den co so du lieu
        public void CloseMdb()
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Open)
                    _sqlConnection.Close();
                if (_mdbConnection.State == ConnectionState.Open)
                    _mdbConnection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        // Execute Command
        public bool ExecuteCommand(string commandString)
        {
            if (!_isMdb)
            {
                if (State())
                {
                    try
                    {
                        var sqlCommand = new SqlCommand(commandString, _sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (OpenMdb())
                {
                    try
                    {
                        var sqlCommand = new SqlCommand(commandString, _sqlConnection);
                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                if (StateMDB())
                {
                    try
                    {
                        var cmd = new OleDbCommand(commandString, _mdbConnection);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (OpenMdb())
                {
                    try
                    {
                        var cmd = new OleDbCommand(commandString, _mdbConnection);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return false;
        }

        // Excute command
        public bool ExecuteCommand(string commandString, string parameters, byte[] values)
        {
            if (!_isMdb)
            {
                if (State())
                {
                    var sqlCommand = new SqlCommand(commandString, _sqlConnection);
                    sqlCommand.Parameters.Add(parameters, SqlDbType.Image);
                    if (values != null)
                        sqlCommand.Parameters[parameters].Value = values;
                    else
                        sqlCommand.Parameters[parameters].Value = DBNull.Value;
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (OpenMdb())
                {
                    var sqlCommand = new SqlCommand(commandString, _sqlConnection);
                    sqlCommand.Parameters.Add(parameters, SqlDbType.Image);
                    if (values != null)
                        sqlCommand.Parameters[parameters].Value = values;
                    else
                        sqlCommand.Parameters[parameters].Value = DBNull.Value;
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                if (StateMDB())
                {
                    var cmd = new OleDbCommand(commandString, _mdbConnection);
                    cmd.Parameters.Add(parameters, OleDbType.Binary);
                    if (values != null)
                        cmd.Parameters[parameters].Value = values;
                    else
                        cmd.Parameters[parameters].Value = DBNull.Value;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (OpenMdb())
                {
                    OleDbCommand cmd = new OleDbCommand(commandString, _mdbConnection);
                    cmd.Parameters.Add(parameters, OleDbType.Binary);
                    if (values != null)
                        cmd.Parameters[parameters].Value = values;
                    else
                        cmd.Parameters[parameters].Value = DBNull.Value;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return false;
        }

        // Lay du lieu tu bang hoac thu tuc
        public DataTable FillData(string commandString)
        {
            if (!_isMdb)
            {
                if (State())
                {
                    try
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(commandString, _sqlConnection);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        dataAdapter.Dispose();
                        //sqlconn.Close();
                        return dataSet.Tables[0];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (OpenMdb())
                {
                    try
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(commandString, _sqlConnection);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        dataAdapter.Dispose();
                        //sqlconn.Close();
                        return dataSet.Tables[0];
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                if (StateMDB())
                {
                    try
                    {
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(commandString, _mdbConnection);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        dataAdapter.Dispose();
                        //mdbconn.Close();
                        return dataSet.Tables[0];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else if (OpenMdb())
                {
                    try
                    {
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(commandString, _mdbConnection);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);
                        dataAdapter.Dispose();
                        //mdbconn.Close();
                        return dataSet.Tables[0];
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return null;
        }

        //Kiem tra trang thai ket noi SQLServer
        public bool State()
        {
            try
            {
                if (_sqlConnection != null)
                {
                    if (_sqlConnection.State == ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //Kiem tra trang thai ket noi cua MSACCESS
        public bool StateMDB()
        {
            try
            {
                if (_mdbConnection != null)
                {
                    return _mdbConnection.State == ConnectionState.Open;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
