using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return new Phrase
            {
                Hungarian = "szia"
            };
        }
    }
}
