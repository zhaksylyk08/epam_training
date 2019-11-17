using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp_AdoNet
{
    class StudentAttendance
    {
        public void CreateDatabase()
        {
            String connectionString = @"Server=localhost;Integrated security=SSPI;database=master";
            String queryString = "CREATE DATABASE StudentAttendanceDB";

            using (var connection = new SqlConnection(connectionString))
            {
                var myCommmand = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    myCommmand.ExecuteNonQuery();

                    Console.WriteLine("Database is created successfully");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void CreateTables()
        {
            using (var connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True")) 
            {
                connection.Open();

                var transaction = connection.BeginTransaction();

                using (var command = new SqlCommand())
                {
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandText = @"CREATE TABLES Students
                                            (ID int PRIMARY KEY NOT NULL,
                                             Name varchar(50) NOT NULL)";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Students table is created successfully");

                }

                using (var command = new SqlCommand())
                {
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandText = @"CREATE TABLES Lectures
                                            (ID int PRIMARY KEY NOT NULL,
                                             LectureDate date NOT NULL
                                             Topic text NOT NULL)";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Lectures table is created successfully");

                }

                using (var command = new SqlCommand())
                {
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandText = @"CREATE TABLES Attendance
                                            (ID int PRIMARY KEY NOT NULL,
                                             StudentID int FOREIGN KEY REFERENCES Students(ID),
                                             LectureID int FOREIGN KEY REFERENCES Lectures(ID)
                                             Mark int)";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Attendance table is created successfully");

                }
            }
        }
    }
}
