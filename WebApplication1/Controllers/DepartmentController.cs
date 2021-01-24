using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            // MySQL
            //string query = @"SELECT DepartmentId,DepartmentName FROM employeedb.`dbo.department`";
            //DataTable table = new DataTable();
            //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            //using (var cmd = new MySqlCommand(query, con))
            //using (var da = new MySqlDataAdapter(cmd))
            //{
            //    cmd.CommandType = CommandType.Text;
            //    da.Fill(table);
            //}

            string query = @"select DepartmentId,DepartmentName from dbo.Department";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {
                // MySQL
                //string query = @"INSERT INTO `employeedb`.`dbo.department` (`DepartmentName`) VALUES('" + dep.DepartmentName + @"')";
                //DataTable table = new DataTable();
                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                //using (var cmd = new MySqlCommand(query, con))
                //using (var da = new MySqlDataAdapter(cmd))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    da.Fill(table);
                //}

                // SQL
                string query = @"insert into dbo.Department values('" + dep.DepartmentName + @"')";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Add!!";
            }
        }

        public string Put(Department dep)
        {
            try
            {
                // MySQL
                //string query = @"UPDATE `employeedb`.`dbo.department` SET `DepartmentName` = '" + dep.DepartmentName + "' WHERE(`DepartmentId` = '" + dep.DepartmentId + @"')";
                //DataTable table = new DataTable();
                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                //using (var cmd = new MySqlCommand(query, con))
                //using (var da = new MySqlDataAdapter(cmd))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    da.Fill(table);
                //}

                // SQL
                string query = @"update dbo.Department set DepartmentName = '" + dep.DepartmentName + @"' where DepartmentId = " + dep.DepartmentId + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                // MySQL
                //string query = @"DELETE FROM employeedb.`dbo.department` WHERE DepartmentId=" + id + @"";
                //DataTable table = new DataTable();
                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                //using (var cmd = new MySqlCommand(query, con))
                //using (var da = new MySqlDataAdapter(cmd))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    da.Fill(table);
                //}

                // SQL
                string query = @"delete from dbo.Department where DepartmentId = " + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Add!!";
            }
        }
    }
}
