using Microsoft.Data.SqlClient;

namespace ConnectedAdoNet
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=IETDb;Integrated Security=True";

            // SELECT
            using SqlConnection selectConnection = new SqlConnection(connectionString);
            string selectQuery = "SELECT * FROM Emp";
            SqlCommand selectCommand = new SqlCommand(selectQuery, selectConnection);

            selectConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            Console.WriteLine("=== SELECT RESULTS ===");
            while (reader.Read())
            {
                int employeeId = Convert.ToInt32(reader["Id"]);
                string? employeeName = reader["Name"].ToString();
                string? employeeAddress = reader["Address"].ToString();
                Console.WriteLine($"Id:{employeeId}, Name:{employeeName}, Address:{employeeAddress}");
            }
            selectConnection.Close();

            // INSERT
            using SqlConnection insertConnection = new SqlConnection(connectionString);
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            string insertQuery = "INSERT INTO Emp (Name, Address) VALUES (@Name, @Address)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, insertConnection);
            insertCommand.Parameters.AddWithValue("@Name", name);
            insertCommand.Parameters.AddWithValue("@Address", address);

            insertConnection.Open();
            int rowsInserted = insertCommand.ExecuteNonQuery();
            Console.WriteLine(rowsInserted > 0 ? "Record inserted successfully!" : "Insert failed");
            insertConnection.Close();

            // UPDATE
            using SqlConnection updateConnection = new SqlConnection(connectionString);
            Console.WriteLine("Enter Id for Emp to be updated:");
            int updateId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new Name:");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter new Address:");
            string newAddress = Console.ReadLine();

            string updateQuery = "UPDATE Emp SET Name=@Name, Address=@Address WHERE Id=@Id";
            SqlCommand updateCommand = new SqlCommand(updateQuery, updateConnection);
            updateCommand.Parameters.AddWithValue("@Name", newName);
            updateCommand.Parameters.AddWithValue("@Address", newAddress);
            updateCommand.Parameters.AddWithValue("@Id", updateId);

            updateConnection.Open();
            int rowsUpdated = updateCommand.ExecuteNonQuery();
            Console.WriteLine(rowsUpdated > 0 ? "Record updated successfully!" : "Update failed");
            updateConnection.Close();

            // DELETE
            using SqlConnection deleteConnection = new SqlConnection(connectionString);
            Console.WriteLine("Enter Id for Emp to be deleted:");
            int deleteId = Convert.ToInt32(Console.ReadLine());

            string deleteQuery = "DELETE FROM Emp WHERE Id=@Id";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, deleteConnection);
            deleteCommand.Parameters.AddWithValue("@Id", deleteId);

            deleteConnection.Open();
            int rowsDeleted = deleteCommand.ExecuteNonQuery();
            Console.WriteLine(rowsDeleted > 0 ? "Record deleted successfully!" : "Delete failed");
            deleteConnection.Close();
        }
    }
}
