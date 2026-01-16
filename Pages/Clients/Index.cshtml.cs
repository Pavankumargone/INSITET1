using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace REPORTS.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClintns { get; set; } = new();

        public void OnGet()
        {
            string connectionString =
      "Data Source=10.1.2.113\\SQLEXPRESS;Initial Catalog=PROEMIS_S022;User Id=sa;Password=!nbtc#2020@;Encrypt=True;TrustServerCertificate=True";

            using SqlConnection connection = new(connectionString);
            connection.Open();

            string sql = "SELECT RegionID, RegionCode, Region, CountryCode, Manager FROM dbo.Z1001_Region";

            using SqlCommand command = new(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListClintns.Add(new ClientInfo
                {
                    RegionID = reader["RegionID"]?.ToString(),
                    RegionCode = reader["RegionCode"]?.ToString(),
                    Region = reader["Region"]?.ToString(),
                    CountryCode = reader["CountryCode"]?.ToString(),
                    Manager = reader["Manager"]?.ToString()
                });
            }
        }

    }

    public class ClientInfo
    {
        public string RegionID { get; set; }
        public string RegionCode { get; set; }
        public string Region { get; set; }
        public string CountryCode { get; set; }
        public string Manager { get; set; }
    }
}
