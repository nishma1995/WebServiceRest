using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebServiceRest
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable GetAllEmployeesXML()
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand("EmployeeList", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                DataSet ds = new DataSet();
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    sda.Fill(ds, "Employee");
                }
                return ds.Tables[0];
            }
        }
    }
}
