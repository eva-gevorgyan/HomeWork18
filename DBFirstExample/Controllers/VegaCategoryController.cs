using DBFirstExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;

namespace DBFirstExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegaCategoryController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public VegaCategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public string GetVegaCategory()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("VegaVestaNewCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM VegaCategory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<VegaCategory> vegaVestaList = new List<VegaCategory>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VegaCategory vegaCategory = new VegaCategory();
                    vegaCategory.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
                    vegaCategory.VegaObject = Convert.ToString(dt.Rows[i]["VegaObject"]);
                    vegaCategory.VegaKitchen = Convert.ToBoolean(dt.Rows[i]["VegaKitchen"]);
                    vegaCategory.VegaDevice = Convert.ToBoolean(dt.Rows[i]["VegaDevice"]);
                    vegaCategory.VegaFurniture = Convert.ToBoolean(dt.Rows[i]["VegaFurniture"]);
                    vegaVestaList.Add(vegaCategory);
                }
            }
            return JsonConvert.SerializeObject(vegaVestaList);
        }
    }
}
