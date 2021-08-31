using MVCAssignment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace MVCAssignment.Repository
{
    public class EmpRepo
    {
        
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private SqlDataAdapter da;
        private DataSet dt;
       //To Add Employee details    
       public bool AddEmployee(EmpModel model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Employees", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@mode", "AddEmp");
                com.Parameters.AddWithValue("@FirstName", model.FirstName);
                com.Parameters.AddWithValue("@LastName", model.LastName);
                com.Parameters.AddWithValue("@DOB", model.DOB);
                com.Parameters.AddWithValue("@Contact", model.Contact);
                com.Parameters.AddWithValue("@RoleId", model.RoleId);
                com.ExecuteNonQuery();
            }
        }
        //To view employee details with generic list     
        public List<EmpModel> GetAllEmployees()
        {
            
            List<EmpModel> EmpList = new List<EmpModel>();
            dt = new DataSet();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Employees", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@mode", "Show");
                da = new SqlDataAdapter(com);
                da.Fill(dt);
                //Bind EmpModel generic list using dataRow     
               if(dt.Tables.Count>0)
                {
                        for(int i=0;i<dt.Tables[0].Rows.Count;i++)
                        {
                        EmpModel obj = new EmpModel();
                        obj.EmpId = Convert.ToInt32(dt.Tables[0].Rows[i]["EmpId"]);
                        obj.FirstName = Convert.ToString(dt.Tables[0].Rows[i]["FirstName"]);
                        obj.LastName = Convert.ToString(dt.Tables[0].Rows[i]["LastName"]);
                        obj.DOB = Convert.ToDateTime(dt.Tables[0].Rows[i]["DOB"]);
                        obj.Contact = Convert.ToString(dt.Tables[0].Rows[i]["Contact"]);
                        obj.RoleId = Convert.ToInt32(dt.Tables[0].Rows[i]["RoleId"]);
                        EmpList.Add(obj);
                    }
                      
                }
            }
            return EmpList;
        }
        //To Update Employee by Id    
        public EmpModel EditbyId(int EmpId)
        {
            var model = new EmpModel();
           
            SqlCommand com = new SqlCommand("Employees", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mode", "ShowById");
            com.Parameters.AddWithValue("@EmpId", EmpId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                model.Add(
                    new EmpModel
                    {
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        DOB = Convert.ToDateTime(dr["DOB"]),
                        Contact = Convert.ToString(dr["Contact"]),
                        RoleId = Convert.ToInt32(dr["RoleId"]),
                    }
                    );
            }

            return model;
        }
        //To Update Employee details
        public bool UpdateEmployee(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Employees", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mode", "UpdateEmp");
            com.Parameters.AddWithValue("@Id", obj.EmpId);
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@DOB", obj.DOB);
            com.Parameters.AddWithValue("@Contact", obj.Contact);
            com.Parameters.AddWithValue("@RoleId", obj.RoleId);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("Employees", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mode", "DelEmp");
            com.Parameters.AddWithValue("@Id", Id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}