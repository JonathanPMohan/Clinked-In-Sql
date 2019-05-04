using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInSql.Models;
using ClinkedInSql.Data;
using System.Data.SqlClient;

namespace ClinkedInSql.Data
{
    public class InterestRepository
    {
        // Setting the trusted connection string to a variable //
        const string ConnectionString = "Server = localhost; Database = ClinkedIn; Trusted_Connection = True;";

        // Add Interest //
        public Interest AddInterest(string name)
        {
            // using statement for the Sql Connection //
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Opening connection //
                connection.Open();
                // setting the insert interest command to a variable and executing //
                var insertInterestCommand = connection.CreateCommand();
                // Setting the Command Text to insert the interest into the database //
                insertInterestCommand.CommandText = $@"Insert into interests (name)
                                                     Output inserted.*
                                                     Values(@name)";
                // Setting the insertInterest command parameters to add the value of Name //
                insertInterestCommand.Parameters.AddWithValue("name", name);

                // Setting the reader to a variable to execute after insert Interest Command //
                var reader = insertInterestCommand.ExecuteReader();

                if (reader.Read())
                {
                    // setting the inserted name value to be read as a string //
                    var insertedName = reader["name"].ToString();
                    
                    // setting the inserted int (ID) to be read as an Int //
                    var insertedId = (int)reader["Id"];
                    
                    // Setting the new interest with the inserted name & inserted ID //
                    var newInterest = new Interest(insertedName) { Id = insertedId };
                    
                    // returning the new interest //
                    return newInterest;
                }
            }
            // Exception for when you can't find the interest //
            throw new Exception("Can't Find An Interest");
        }

        // Get All Interests //
        public List<Interest> GetAll()
        {
            // setting interests variable to = new list of interests //
            var interests = new List<Interest>();
            // Setting the Sql connection from connection string variable at top of scope //
            var connection = new SqlConnection(ConnectionString);
            // Opeing connection //
            connection.Open();
            // Setting the get all interests command to a varaible and executing //
            var getAllInterestsCommand = connection.CreateCommand();
            // setting the command text to select name & id from interests //
            getAllInterestsCommand.CommandText = @"select name , id
                                                 from interests";
            // Setting the reader to a variable and to execute the get all interests command //
            var reader = getAllInterestsCommand.ExecuteReader();
            // while loop for reader to find the variable id & name //
            while (reader.Read())
            {
                // setting the int (ID) to a variable to be read by reader
                var id = (int)reader["Id"];

                // setting the name to a variable to be read by reader as string //
                var name = reader["Name"].ToString();

                // setting interest to a varaible by using the name and id variable //
                var interest = new Interest(name) { Id = id };

                // adding interest to interests varaible from above //
                interests.Add(interest);
            }
            // closing connection //
            connection.Close();
            // returning all interests //
            return interests;
        }


        // Delete Interest //
        public void DeleteInterest(int interestId)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var deleteInterestCommand = connection.CreateCommand();
            deleteInterestCommand.Parameters.AddWithValue("Id", interestId);
            deleteInterestCommand.CommandText = @"Delete
                                                From Interests
                                                Where Id = @Id";

            deleteInterestCommand.ExecuteNonQuery();

            connection.Close();
        }


        // Update Interest //
        public bool UpdateInterest(int id, string name)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var updateInterestCommand = connection.CreateCommand();

                updateInterestCommand.Parameters.AddWithValue("@Id", id);

                updateInterestCommand.CommandText = $@"Update interests
                                                    Set name = @name
                                                    Where Id = @Id";

                updateInterestCommand.Parameters.AddWithValue("name", name);

                var numberOfRowsUpdated = updateInterestCommand.ExecuteNonQuery();

                connection.Close();

                if (numberOfRowsUpdated > 0)
                { return true; }
                return false;
            }
        }
    }
}