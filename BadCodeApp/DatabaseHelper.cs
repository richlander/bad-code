using System;
using System.Data.SqlClient;

namespace BadCodeApp
{
    public class DatabaseHelper
    {
        // ERROR: Missing semicolon (FIXED for more errors)
        private string connectionString = "Server=localhost;Database=test";
        
        // WARNING: Field never used
        private int unusedPort = 1433;
        
        public void ConnectToDatabase()
        {
            // ERROR: Variable used before declaration
            Console.WriteLine(connection);
            SqlConnection connection = new SqlConnection(connectionString);
            
            // ERROR: Calling method that doesn't exist
            connection.OpenAsync();
            
            // WARNING: Variable assigned but not used
            var command = new SqlCommand("SELECT * FROM Users");
            
            // ERROR: Missing closing brace (FIXED)
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connected");
            }
        }
        
        // ERROR: Return type mismatch
        public int GetConnectionString()
        {
            return connectionString;
        }
    }
}
