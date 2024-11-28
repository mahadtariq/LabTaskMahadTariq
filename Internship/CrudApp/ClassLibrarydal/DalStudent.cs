using System.Data;
using ModelClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ClassLibrarydal
{
    public class DalStudent
    {
        public static void SaveStudentInformation(ModelStudent ms)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SaveStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", ms.StudentId);
            cmd.Parameters.AddWithValue("@StudentName", ms.StudentName);
            cmd.Parameters.AddWithValue("@UniversityName", ms.UniversityName);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteStudentInformation(int StudentId)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteStudentNew", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateStudentInformation(ModelStudent ms)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentId", ms.StudentId);
            cmd.Parameters.AddWithValue("@StudentName", ms.StudentName);
            cmd.Parameters.AddWithValue("@UniversityName", ms.UniversityName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<ModelStudent> GetStudentInformation()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelStudent> listStudent = new List<ModelStudent>();
            while (reader.Read())
            {
                ModelStudent student = new ModelStudent();
                student.StudentId = Convert.ToInt32(reader["StudentId"]);
                student.StudentName = reader["StudentName"].ToString();
                student.UniversityName = reader["UniversityName"].ToString();
                listStudent.Add(student);

            }
            con.Close();
            return listStudent;


        }


    }

}


