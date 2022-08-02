using Microsoft.Extensions.Logging;
using RhoShamBoAPI.Model;
using System.Data.SqlClient;

namespace RhoShamBoAPI.Data


    //This set of resources is for our Data
{
    public class SQLRepository : InterfaceRepository
    {
        //Fields

        //Creating a place in the SQLRepository class to HOLD the connectionstring
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;//I'm not that sure what he did here when installing

        //Constructor
              public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        //Method

        //Task - returning many players, we're not sure what form the group of many is (Array, List..), 
        //They all agree to the contract that they are enumerable objects - IEnumerable, and it'll have to tell me what it contains
        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            List<Player> result = new(); //Player List

            using SqlConnection connection = new SqlConnection(_connectionString); //Right click, find and install.
            await connection.OpenAsync();

            string cmdText = "SELECT Id, Name, City, Email FROM RhoShamBo.Player;";
            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
           
            //this is technically a for each loop - for each line in table, without having to know how many lines there are.
            while (await reader.ReadAsync()) 
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string city = reader.GetString(2); 
                string email = reader.GetString(3);

                Player tmpPlayer = new Player(id, name, city, email);
                result.Add(tmpPlayer);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllPlayersAsync, returned {0} results", result.Count); //{however many #}, this takes input from result.Count

            return result;
        }

        //public void Insert(string name, string country)
        //{
        //   string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //   using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)"))
        //        {
        //            cmd.Parameters.AddWithValue("@Name", name);
        //            cmd.Parameters.AddWithValue("@Country", country);
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //} REFERENCE CODE
        /*
         * Sample Json
         * {
         * "Fieldname": "FieldValue", "Fieldname2" : "FieldValue2", "FieldName3": "FieldValue3" 
         * }
         */
        public  async Task<Player> InsertPlayerAsync( string name, string city, string email)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string cmdText = "INSERT INTO RhoShamBo.Player(Name, City, Email) VALUES (@Name, @City, @Email)";

           using (SqlCommand cmd = new(cmdText, connection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
               
            }

            await connection.CloseAsync();

           return new Player(name, city, email);    
        }


        // Tourneys Method

        public async Task<IEnumerable<Tourney>> GetAllTourneysAsync()
        {
            List<Tourney> result = new(); //Tourney List

            using SqlConnection connection = new SqlConnection(_connectionString); //Right click, find and install.
            await connection.OpenAsync();

            string cmdText = "SELECT Id, PlayerCount, Winner FROM RhoShamBo.Tourney;";
            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                int playerCount = reader.GetInt32(1);
                string winner = reader.GetString(2);

                Tourney tmpTourney = new Tourney(id, playerCount, winner);
                result.Add(tmpTourney);
            }
            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllTourneysAsync, returned {0} results", result.Count);
            return result;
        }


    }
}