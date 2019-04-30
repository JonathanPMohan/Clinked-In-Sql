using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInSql.Models;
using ClinkedInSql.Data;
using System.Data.SqlClient;

namespace ClinkedInSql.Data
{
    public class UsersRepository
    {
     // TEST Test//
        // How to create a SQL connection //
        public List<Users> GetAll()
        {
            // setting users to a new list //
            var users = new List<Users>();
            // setting the connection to a variable //
            var connection = new SqlConnection("Server = localhost; Database = ClinkedIn; Trusted_Connection = True;");
            // open connection //
            connection.Open();
            // creating the get all users command //
            var getAllUsersCommand = connection.CreateCommand();
            // Writing the command to select All Users //
            getAllUsersCommand.CommandText = @"select*
                                             from users";
            // setting the data command from the API cloud by setting it to a variable //
            var reader = getAllUsersCommand.ExecuteReader();

            // while loop method returns a true or false //
            // add constructor to return users //
            while (reader.Read())
            {
  
                var name = reader["name"].ToString();
                var releaseDate = (DateTime)reader["releaseDate"];
                var isPrisoner = (bool)reader["isPrisoner"];
                var age = (int)reader["age"];

                var user = new Users(name, releaseDate, isPrisoner, age);

                users.Add(user);
            }

            // closing the connection //
            connection.Close();

            return users;
        }
    }
}