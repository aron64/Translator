using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TranslatorWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhraseController : ControllerBase
    {

        private readonly ILogger<PhraseController> _logger;

        public PhraseController(ILogger<PhraseController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<Phrase> PostAsync(Phrase p)
        {
            string query = String.Format("SELECT Hungarian From dictionary where English=@phrase;", p.English);
            SqlCommand cmd = new SqlCommand(query, Program.sqlConnection);
            cmd.Parameters.AddWithValue("@phrase",p.English);
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            //only reading once, so multi row result would be ignored.
            if (!dr.Read())
            {
                dr.Close();
                return new Phrase();
            }
            else
            {
                string res = dr.GetValue(0).ToString();
                dr.Close();
                return new Phrase{Hungarian = res};
            }
        }
    }
}
