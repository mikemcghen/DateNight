using DateNightSelector.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DateNightSelector.DAO
{
    public class DatesSqlDAO : IDatesDAO
    {
        private readonly string connectionString;
        public DatesSqlDAO(string connString)
        {
            connectionString = connString;
        }
        public Dates GetRandomDate()
        {
            Dates dates = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM dates where Completed = 0 ORDER BY NEWID();", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        dates = CreateDatesFromReader(reader);
                    }
                }
            }
            catch (Exception)
            {
            }
            return dates;
        }
        public IList<Dates> GetAllDates()
        { 
            IList<Dates> dates = new List<Dates>();
        
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Dates ORDER BY Date_Id", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dates date = CreateDatesFromReader(reader);
                    dates.Add(date);
                }
            }
            return dates;
        }
        public Dates DateById(int dateId)
        {
            Dates dates = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Dates WHERE Date_Id = @dateId", conn);
                    cmd.Parameters.AddWithValue("@dateId", dateId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                      dates = CreateDatesFromReader(reader);
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return dates;
        }
        public void AddDate(Dates dates)
        {
            try
            {            
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into dates(Name, Description, Location, Link, Added_By) values(@Name, @Description, @Location, @Link, @AddedBy);", conn);
                    cmd.Parameters.AddWithValue("@Name", dates.Name);
                    cmd.Parameters.AddWithValue("@Description", dates.Description);
                    cmd.Parameters.AddWithValue("@Location", dates.Location);
                    cmd.Parameters.AddWithValue("@Link", dates.Link);
                    cmd.Parameters.AddWithValue("@AddedBy", dates.AddedBy);
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception)
            {
            }
        }
        public void UpdateCompleteDate(int dateId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update dates set Completed = 1 where Date_Id = @dateId", conn);
                    cmd.Parameters.AddWithValue("@dateId", dateId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private Dates CreateDatesFromReader(SqlDataReader reader)
        {
            Dates dates = new Dates();
            dates.Name = Convert.ToString(reader["Name"]);
            dates.Description = Convert.ToString(reader["Description"]);
            dates.Location = Convert.ToString(reader["Location"]);
            dates.Link = Convert.ToString(reader["Link"]);
            dates.Completed = Convert.ToBoolean(reader["Completed"]);
            dates.AddedBy = Convert.ToString(reader["Added_By"]);
            dates.DateId = Convert.ToInt32(reader["Date_Id"]);
            return dates;
        }
    }
}
