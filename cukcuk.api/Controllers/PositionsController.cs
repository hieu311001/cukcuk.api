using cukcuk.api.Entities;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace cukcuk.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPositions()
        {
            try
            {
                string connectionString = "Server=3.0.89.182;Port=3306;Database=WDT.2022.VMHIEU;Uid=dev;Pwd=12345678";
                var mySqlConnection = new MySqlConnection(connectionString);

                string getAllPositionsCommand = "SELECT * FROM positions";

                var positions = mySqlConnection.Query<Position>(getAllPositionsCommand);

                if (positions != null)
                {
                    return StatusCode(StatusCodes.Status200OK, positions);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }
    }
}
