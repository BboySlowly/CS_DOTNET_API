using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            // MySQL
            //string query = @"SELECT * FROM employeedb.`dbo.employee`";
            //DataTable table = new DataTable();
            //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            //using (var cmd = new MySqlCommand(query, con))
            //using (var da = new MySqlDataAdapter(cmd))
            //{
            //    cmd.CommandType = CommandType.Text;
            //    da.Fill(table);
            //}

            // SQL
            string query = @"select EmployeeId, EmployeeName, Department, convert(varchar(10),DateOfJoining,120) as DateOfJoining, PhotoFileName from dbo.Employee";
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

        public string Post(Employee emp)
        {
            try
            {
                // MySQL
                //string query = @"INSERT INTO `employeedb`.`dbo.employee`
                //                    (`EmployeeName`,`Department`,`DateOfJoining`,`PhotoFileName`)
                //                    VALUES('" + emp.EmployeeName + @"',
                //                           '" + emp.Department + @"',
                //                           '" + emp.DateOfJoining + @"',
                //                           '" + emp.PhotoFileName + @"')";
                //DataTable table = new DataTable();
                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                //using (var cmd = new MySqlCommand(query, con))
                //using (var da = new MySqlDataAdapter(cmd))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    da.Fill(table);
                //}

                // SQL
                string query = @"insert into dbo.Employee
                            (EmployeeName,Department,DateOfJoining,PhotoFileName)
                            values(
                            '" + emp.EmployeeName + @"',
                            '" + emp.Department + @"',
                            '" + emp.DateOfJoining + @"',
                            '" + emp.PhotoFileName + @"'
                            )";
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

        public string Put(Employee emp)
        {
            try
            {
                // MySQL
                //string query = @"UPDATE `employeedb`.`dbo.employee` SET
                //                        `EmployeeName` = '" + emp.EmployeeName + @"',
                //                        `Department` = '" + emp.Department + @"',
                //                        `DateOfJoining` = '" + emp.DateOfJoining + @"',
                //                        `PhotoFileName` = '" + emp.PhotoFileName + @"'
                //                        WHERE(`EmployeeId` = '" + emp.EmployeeId + @"')";
                //DataTable table = new DataTable();
                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                //using (var cmd = new MySqlCommand(query, con))
                //using (var da = new MySqlDataAdapter(cmd))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    da.Fill(table);
                //}

                // SQL
                string query = @"update dbo.Employee set
                            EmployeeName = '" + emp.EmployeeName + @"',
                            Department = '" + emp.Department + @"',
                            DateOfJoining = '" + emp.DateOfJoining + @"',
                            PhotoFileName = '" + emp.PhotoFileName + @"'
                            where EmployeeId = " + emp.EmployeeId + @"";
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
                //string query = @"DELETE FROM employeedb.`dbo.employee` WHERE EmployeeId=" + id + @"";
                //DataTable table = new DataTable();
                //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                //using (var cmd = new MySqlCommand(query, con))
                //using (var da = new MySqlDataAdapter(cmd))
                //{
                //    cmd.CommandType = CommandType.Text;
                //    da.Fill(table);
                //}

                // SQL
                string query = @"delete from dbo.Employee where EmployeeId = " + id + @"";
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

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            // MySQL
            //string query = @"SELECT DepartmentName FROM employeedb.`dbo.department`";
            //DataTable table = new DataTable();
            //using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            //using (var cmd = new MySqlCommand(query, con))
            //using (var da = new MySqlDataAdapter(cmd))
            //{
            //    cmd.CommandType = CommandType.Text;
            //    da.Fill(table);
            //}

            // SQL
            string query = @"select DepartmentId, DepartmentName from dbo.Department";
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

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }
    }
}
