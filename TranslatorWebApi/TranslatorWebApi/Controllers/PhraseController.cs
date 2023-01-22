using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using http=System.Web.Http;

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

        [HttpGet]
        public Phrase Get()
        {
            string testPhrase = "Account Holder Name";
            string query = String.Format("SELECT Hungarian From dictionary where English='{0}';", testPhrase);
            SqlCommand cmd = new SqlCommand(query, Program.sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                dr.Close();
                return new Phrase();
            }
            else
            {
                //does not consider multiple results
                string res = dr.GetValue(0).ToString();
                dr.Close();
                return new Phrase
                {
                    Hungarian = res
                };
            }
        }
    }
}
