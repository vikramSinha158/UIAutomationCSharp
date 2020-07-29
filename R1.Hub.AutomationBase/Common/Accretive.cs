using Dapper;
using Microsoft.Extensions.Configuration;
using R1.Automation.Database.core.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace R1.Hub.AutomationBase.Common
{
    public class Accretive : DataAccess
    {
        string facilityCode, coreServer, coreDataBase, auth, userId, passWord, url, accretiveDb;
        readonly string queryValue = "SELECT Replace(Replace(serverpath, '[', ''), ']', '')  AS servername, databasename from locations where code = @facilitycode";
        private IDbConnection con;

        public IConfigurationRoot GetAppsetting
        {
            get
            {
                var config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();
                return config;
            }
        }

        /// <summary>
        /// This method is use return servername and database name according to facility wise by inputing coreserver, coredatabase 
        /// </summary>
        private List<DataAccess> GetTranServerDB(string facilityCode)
        {
            LoadAppSettingsJson();
            string connectionString = String.Empty;
            if (auth == "Window")
            {
                connectionString = "Data Source = " + coreServer + "; Initial Catalog = " + coreDataBase + "; Integrated Security = True";
            }
            else
            {
                connectionString = "Data Source = " + coreServer + "; Initial Catalog = " + coreDataBase + "; User ID = " + userId + " ; Password =" + passWord + "";
            }
            con = ConnectToDB(connectionString);     
            var parameters = new DynamicParameters();
            var facilitycode = facilityCode;
            parameters.Add("@facilitycode", facilitycode, DbType.String, ParameterDirection.Input, facilitycode.Length);
            List<DataAccess> listValue = con.Query<DataAccess>(queryValue, parameters, commandType: CommandType.Text).ToList();
            return listValue;
        }

        private void LoadAppSettingsJson()
        {
            if (GetAppsetting != null)
            {
                url = GetAppsetting["Connection:URL"].Trim();
                coreServer = GetAppsetting["Connection:UATCARESERVER"].Trim();
                coreDataBase = GetAppsetting["Connection:COREDB"].Trim();
                auth = GetAppsetting["Connection:Auth"].Trim();
                userId = GetAppsetting["Connection:UserID"].Trim();
                passWord = GetAppsetting["Connection:PWD"].Trim();
            }
        }
        /// <summary>
        /// This method returns the connection string using fetchTranServerDB method according to facility passing by @facility parameter</summary>
        public string GetTranConnectionString(string facilityColumn)
        {
            string connectionString = null;
            LoadAppSettingsJson();
            List<DataAccess> listValue = GetTranServerDB(facilityColumn);
            try
            {
                //List<DataAccess> listValue = GetTranServerDB(facilityColumn);
                if (listValue != null)
                {
                    ServerName = listValue[0].ServerName;
                    DatabaseName = listValue[0].DatabaseName;
                    if (auth == "Window")
                    {
                        connectionString = "Data Source = " + ServerName + "; Initial Catalog = " + DatabaseName + "; Integrated Security = True";
                    }
                    else
                    {
                        connectionString = "Data Source = " + ServerName + "; Initial Catalog = " + DatabaseName + "; User ID = " + userId + " ; Password =" + passWord + "";
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return connectionString;
        }
        /// <summary>This method returns the connection string for accretive or cross site registry database according to the facility parameter passed</summary>
        public string GetAccretiveCrossiteConnectionString(string facilityColumnName)
        {
            string connectionString = null;
            LoadAppSettingsJson();
            try
            {
                List<DataAccess> listValue = GetTranServerDB(facilityColumnName);
                if (listValue != null)
                {
                    ServerName = listValue[0].ServerName;
                    base.DatabaseName = listValue[0].DatabaseName;
                    ServerName = url.Contains("rcohub") ? ServerName + ".EXTAPP.LOCAL" : ServerName;
                    connectionString = auth.Equals("Window") ? "Data Source = " + ServerName + "; Initial Catalog = " + accretiveDb + "; Integrated Security = True" : "Data Source = " + ServerName + "; Initial Catalog = " + accretiveDb + "; User ID = " + userId + " ; Password =" + passWord + "";
                }
            }      
            catch (Exception)
            {
                return null; //return null in case of exception
            }
            return connectionString;
        }
    }
}
