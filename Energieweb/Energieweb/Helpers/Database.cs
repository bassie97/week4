using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Energieweb.Helpers
{
    public class Database
    {
        static string connectionstring = "constr"; // Dit moet eigenlijk ergens in een settingsfile die niet naar de gitrepo gepushed wordt.
        MySql.Data.MySqlClient.MySqlConnection connection;
        MySql.Data.MySqlClient.MySqlCommand command;
        MySql.Data.MySqlClient.MySqlDataReader datareader;       
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionstring].ToString();

        public Result ExecuteQuery(string query)
        {
            Open();
            this.command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
            this.datareader = command.ExecuteReader();
            ArrayList temp = new ArrayList();
            while (datareader.HasRows && datareader.Read())
            {
                ArrayList temp2 = new ArrayList();
                for(int i = 0; i < datareader.FieldCount; i++)
                {
                    temp2.Add(datareader[i]);
                }
                temp.Add(temp2);               
            }
            Result result = new Result();
            result.Succes = true;
            result.Dataset = temp;
            result.Message = "Query executed.";
            
            Close();
            return result;
        }

        private void Open()
        {
            this.connection = new MySql.Data.MySqlClient.MySqlConnection(this.connString);
            this.connection.Open();
        }

        private void Close()
        {
            this.connection.Close();
            this.datareader.Close();
        }
    }
}