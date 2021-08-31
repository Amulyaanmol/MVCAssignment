using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAssignment.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MVCAssignment.Controllers
{
    public class ProjectEmployeeMappingController : Controller
    {
        // GET: ProjectEmployeeMapping
        public ActionResult Index()
        {
            List<ProjectEmployeeMapping> pm = new List<ProjectEmployeeMapping>();
            string mainconn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(mainconn);
            string sqlquery = "SELECT Employee.EmpId, ProjectEmployeeMapping.ProId FROM Employee INNER JOIN ProjectEmployeeMapping ON Employee.EmpId=ProjectEmployeeMapping.EmpId";
            SqlCommand sqlcom = new SqlCommand(sqlquery,sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sqlcon.Open();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ProjectEmployeeMapping pem = new ProjectEmployeeMapping();
                pem.ProId = Convert.ToInt32(dr["ProId"].ToString());
                pem.EmpId = Convert.ToInt32(dr["EmpId"].ToString());
                pm.Add(pem); 
            }
            return View(pm);
        }

    }
}
