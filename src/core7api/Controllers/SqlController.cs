using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core7api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlController : ControllerBase
    {
        // GET: api/<DashboardController>
         [HttpGet(Name = "GetAccounts")]
        public IEnumerable<accounts> Get()
        {

            var result = new List<accounts>();

            using (var connection = new NpgsqlConnection("User ID=rashid;Password=.x#Yj6E7no@84;Host=34.134.16.113;Port=5432;Database=code360db;"))
            {
                connection.Open();
                result = connection.Query<accounts>("SELECT * FROM accounts").ToList();
            }

            return result;
        }

 }
}
