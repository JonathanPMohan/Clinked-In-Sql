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
        // Setting Connection string //
        const string ConnectionString = "Server = localhost; Database = ClinkedIn; Trusted_Connection = True;";
        // Add user //
        public Users AddUser(string name, DateTime releaseDate, int age, bool isPrisoner)
        {
            // setting the Variable to using the SQL connection //
            using (var connection = new SqlConnection(ConnectionString))
            {   
                // Opening the connection //
                connection.Open();
                // Setting the Insert User Command To a Variable to create command //
                var insertUserCommand = connection.CreateCommand();
                // Setting User Command Command Text //
                insertUserCommand.CommandText = $@"Insert into users 
                                                    (name, releaseDate, age, isPrisoner)
                                                    Output inserted.*
                                                    Values
                                                (@name, @releaseDate, @age, @isPrisoner)";
                // user command parameters adding Value of "example" //
                insertUserCommand.Parameters.AddWithValue("name", name);
                insertUserCommand.Parameters.AddWithValue("releasedate", releaseDate);
                insertUserCommand.Parameters.AddWithValue("age", age);
                insertUserCommand.Parameters.AddWithValue("isPrisoner", isPrisoner);

                // Setting reader to a variable, execute reader //
                var reader = insertUserCommand.ExecuteReader();
                // If statement for inserted paramaters //
                if (reader.Read())
                {
                    var insertedName = reader["name"].ToString();
                    var insertedReleaseDate = (DateTime)reader["releaseDate"];
                    var insertedAge = (int)reader["age"];
                    var insertedIsPrisoner = (bool)reader["isPrisoner"];

                    // Variable for Inserted ID for Added new user //
                    var insertedId = (int)reader["Id"];
                    // NewUser variable for inserted parameters for add //
                    var newUser = new Users(insertedName, insertedReleaseDate, insertedIsPrisoner, insertedAge) { Id = insertedId };
                    // Returning the new user just added //
                    return newUser;
                }
            }
            // Exception for when no user is found //
            throw new Exception("No user found");
        }

        // How to create a SQL connection //
        // Get all users //
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

        
        // Update User //
        public bool UpdateUser(int id, string name, DateTime releaseDate, int age, bool isPrisoner)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var updateUserCommand = connection.CreateCommand();

                updateUserCommand.Parameters.AddWithValue("@Id", id);

                updateUserCommand.CommandText = $@"Update users 
                                                    Set 
                                                        name = @name,
                                                        releaseDate = @releaseDate,
                                                        age = @age,
                                                        isPrisoner = @isPrisoner
                                                Where Id = @Id";

                updateUserCommand.Parameters.AddWithValue("name", name);
                updateUserCommand.Parameters.AddWithValue("releasedate", releaseDate);
                updateUserCommand.Parameters.AddWithValue("age", age);
                updateUserCommand.Parameters.AddWithValue("isPrisoner", isPrisoner);

                var numberOfRowsUpdated = updateUserCommand.ExecuteNonQuery();

                connection.Close();

                if (numberOfRowsUpdated > 0)
                { return true; }
                return false;

            }

        }

        // Delete User //

        public void DeleteUser(int userId)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var deleteUserCommand = connection.CreateCommand();
            deleteUserCommand.Parameters.AddWithValue("UId", userId);
            deleteUserCommand.CommandText = @"Delete
                                                From Users
                                                Where Id = @UId";

            deleteUserCommand.ExecuteNonQuery();

            connection.Close();
        }



    }
}