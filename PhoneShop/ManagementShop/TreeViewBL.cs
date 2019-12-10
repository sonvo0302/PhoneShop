using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhoneShop.ManagermentShop
{
    public class TreeViewBL
    {
        public static DataTable GetData(String Query)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ConnectionDB.ExecuteCommand(Query, CommandType.Text); //calling the connectionfactory methode from DAL  
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}