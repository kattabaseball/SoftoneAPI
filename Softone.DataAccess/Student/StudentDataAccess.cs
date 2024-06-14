using Microsoft.Extensions.Configuration;
using Softone.Core.Student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softone.DataAccess.Student
{
    public class StudentDataAccess : IStudentDataAccess
    {
        protected string Softone_DBSTRING;
        IConfiguration _configuration;
        public StudentDataAccess(IConfiguration configuration)
        {
            Softone_DBSTRING = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
        }

        public string AddStudent(string spType, AddStudent addStudent)
        {
            String status = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(Softone_DBSTRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("StudentCRUD", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SpTypeParameter = command.Parameters.Add("@SPType", SqlDbType.VarChar, 100);
                        SpTypeParameter.Value = spType;

                        // Adding stored procedure parameters
                        SqlParameter FirstNameParameter = command.Parameters.Add("@FirstName", SqlDbType.VarChar, 500);
                        FirstNameParameter.Value = addStudent.firstname;

                        // Adding stored procedure parameters
                        SqlParameter LastNameParameter = command.Parameters.Add("@LastName", SqlDbType.VarChar, 500);
                        LastNameParameter.Value = addStudent.lastname;

                        // Adding stored procedure parameters
                        SqlParameter MobileParameter = command.Parameters.Add("@MObile", SqlDbType.VarChar, 50);
                        MobileParameter.Value = addStudent.mobile;

                        // Adding stored procedure parameters
                        SqlParameter EmailParameter = command.Parameters.Add("@Email", SqlDbType.VarChar, 500);
                        EmailParameter.Value = addStudent.email;

                        // Adding stored procedure parameters
                        SqlParameter NICParameter = command.Parameters.Add("@NIC", SqlDbType.VarChar, 50);
                        NICParameter.Value = addStudent.nic;


                        // Adding stored procedure parameters
                        SqlParameter DobParameter = command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                        DobParameter.Value = addStudent.dateofbirth;

                        // Adding stored procedure parameters
                        SqlParameter AddressParameter = command.Parameters.Add("@Address", SqlDbType.VarChar, 500);
                        AddressParameter.Value = addStudent.address;

                        // Adding stored procedure parameters
                        SqlParameter ImageURLParameter = command.Parameters.Add("@ImageUrl", SqlDbType.VarChar);
                        ImageURLParameter.Value = addStudent.imageurl;


                        // Add an output parameter to capture the result
                        SqlParameter resultParameter = command.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 100);
                        resultParameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        // Retrieve the result from the output parameter
                        status = Convert.ToString(resultParameter.Value);

                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("AddStudent api failed at StudentDataAccess Layer : " + ex.Message);
            }

            return status;
        }

        public List<StudentDetails> GetStudentDetails()
        {
            List<StudentDetails> studentList = new List<StudentDetails>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Softone_DBSTRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetAllStudentDetails", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        var result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var student = new StudentDetails
                            {
                                Id = Convert.ToInt32(result["Id"]),
                                FirstName = result["FirstName"].ToString(),
                                LastName = result["LastName"].ToString(),
                                Mobile = result["Mobile"].ToString(),
                                Email = result["Email"].ToString(),
                                NIC = result["NIC"].ToString(),
                                DateOfBirth = Convert.ToDateTime(result["DateOfBirth"]),
                                Address = result["Address"].ToString(),
                                ImageUrl = result["ImageUrl"].ToString(),
                                IsDisable = Convert.ToBoolean(result["IsDisable"])

                            };

                            studentList.Add(student);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetStudentDetails api failed at StudentDataAccess Layer : " + ex.Message);
            }

            return studentList;
        }

        public string RemoveStudent(string spType, int id)
        {
            String status = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(Softone_DBSTRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("StudentCRUD", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter spTypeParameter = command.Parameters.Add("@SPType", SqlDbType.VarChar, 100);
                        spTypeParameter.Value = spType;

                        SqlParameter IdParameter = command.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = id;

                        // Add an output parameter to capture the result
                        SqlParameter resultParameter = command.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 100);
                        resultParameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        // Retrieve the result from the output parameter
                        status = Convert.ToString(resultParameter.Value);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RemoveStudent api failed at StudentDataAccess Layer : " + ex.Message);
            }

            return status;
        }

        public string UpdateStudent(string spType, StudentDetails student)
        {
            String status = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(Softone_DBSTRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("StudentCRUD", connection) { CommandType = CommandType.StoredProcedure })
                    {
                        // Adding stored procedure parameters
                        SqlParameter SpTypeParameter = command.Parameters.Add("@SPType", SqlDbType.VarChar, 100);
                        SpTypeParameter.Value = spType;

                        // Adding stored procedure parameters
                        SqlParameter IdParameter = command.Parameters.Add("@Id", SqlDbType.Int);
                        IdParameter.Value = student.Id;

                        // Adding stored procedure parameters
                        SqlParameter FirstNameParameter = command.Parameters.Add("@FirstName", SqlDbType.VarChar, 500);
                        FirstNameParameter.Value = student.FirstName;

                        // Adding stored procedure parameters
                        SqlParameter LastNameParameter = command.Parameters.Add("@LastName", SqlDbType.VarChar, 500);
                        LastNameParameter.Value = student.LastName;

                        // Adding stored procedure parameters
                        SqlParameter MobileParameter = command.Parameters.Add("@Mobile", SqlDbType.VarChar, 50);
                        MobileParameter.Value = student.Mobile;

                        // Adding stored procedure parameters
                        SqlParameter EmailParameter = command.Parameters.Add("@Email", SqlDbType.VarChar, 500);
                        EmailParameter.Value = student.Email;

                        // Adding stored procedure parameters
                        SqlParameter NICParameter = command.Parameters.Add("@NIC", SqlDbType.VarChar, 50);
                        NICParameter.Value = student.NIC;


                        // Adding stored procedure parameters
                        SqlParameter DobParameter = command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                        DobParameter.Value = student.DateOfBirth;
                            
                        // Adding stored procedure parameters
                        SqlParameter AddressParameter = command.Parameters.Add("@Address", SqlDbType.VarChar, 500);
                        AddressParameter.Value = student.Address;

                        // Adding stored procedure parameters
                        SqlParameter ImageURLParameter = command.Parameters.Add("@ImageUrl", SqlDbType.VarChar);
                        ImageURLParameter.Value = student.ImageUrl;


                        // Add an output parameter to capture the result
                        SqlParameter resultParameter = command.Parameters.Add("@ResultMessage", SqlDbType.NVarChar, 100);
                        resultParameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        // Retrieve the result from the output parameter
                        status = Convert.ToString(resultParameter.Value);

                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("AddStudent api failed at StudentDataAccess Layer : " + ex.Message);
            }

            return status;
        }
    }
}
