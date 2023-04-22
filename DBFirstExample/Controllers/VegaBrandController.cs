using Azure;
using DBFirstExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace DBFirstExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegaBrandController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VegaBrandController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public string GetVegaBrand()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("VegaVestaNewCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VegaBrand", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<VegaBrand> vegaVestaList = new List<VegaBrand>();
            //Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VegaBrand vegaVesta = new VegaBrand();
                    vegaVesta.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    vegaVesta.VegaBrandName = Convert.ToString(dt.Rows[i]["VegaBrandName"]);
                    vegaVestaList.Add(vegaVesta);
                }
            }
            //if (vegaVestaList.Count > 0)
            //    return JsonConvert.SerializeObject(vegaVestaList);
            //else
            //{
            //    response.StatusCode = 100;
            //    response.ErrorMessage = "Not found";
            //    return JsonConvert.SerializeObject(response);
            //}
            return JsonConvert.SerializeObject(vegaVestaList);
        }
    }
}
