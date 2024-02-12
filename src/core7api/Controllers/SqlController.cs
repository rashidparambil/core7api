using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace core7api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlController : ControllerBase
    {
        public IConfiguration _configuration;
        public SqlController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/<DashboardController>
        [HttpGet(Name = "GetAccounts")]
        public IEnumerable<accounts> Get()
        {
            var result = new List<accounts>();
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("coreDb")))
            {
                connection.Open();
                result = connection.Query<accounts>("SELECT * FROM accounts").ToList();
            }

            return result;
        }

 }
}
