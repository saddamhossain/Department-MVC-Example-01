using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcExample005.Models
{
    public class DepartmentContainer
    {
        string connectionString = @"Server=BITM-401-PC21\SQLEXPRESS; Database = DepartmentDb; Integrated Security = true";
        public IList<Department> GetAllDepartments()
        {
            IList<Department> departments = new List<Department>();

            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("SELECT * FROM tbl_Department", aConnection);
            SqlDataReader reader = aCommand.ExecuteReader();

            while (reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Code = reader[1].ToString();
                aDepartment.Name = reader[2].ToString();
                departments.Add(aDepartment);
            }

            aConnection.Close();
            return departments;
         

        }

        public IList<Department> GetAllDept()
        {
            IList<Department> departments = new List<Department>();
          
            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("SELECT * FROM tbl_Department", aConnection);
            SqlDataReader reader = aCommand.ExecuteReader();

            while (reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Name = reader[1].ToString();
                aDepartment.Code = reader[2].ToString();
                departments.Add(aDepartment);
            }

            aConnection.Close();
            return departments;
        }

        public void Save(Department aDepartment)
        {
           
            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("INSERT INTO tbl_Department values ('" + aDepartment.Name + "','" + aDepartment.Code + "')", aConnection);
            aCommand.ExecuteNonQuery();
            aConnection.Close();
        }
    }
}