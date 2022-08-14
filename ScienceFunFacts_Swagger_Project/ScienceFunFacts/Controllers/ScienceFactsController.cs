using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScienceFunFactsV1.Models;
using ScienceFunFactsV1.ScienceFacts;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScienceFunFactsV1.Controllers
{
    [Route("api/[controller]")]
    public class SwaggerUIExampleController : Controller
    {
        private static readonly IEnumerable<ScienceFact> Facts = new ScienceFact[]
        {
            new ScienceFact("Fact1", "Some fact info", new string[] {"a link to somewhere", "another link"}),
            new ScienceFact("Fact2", "Some more fact info", new string[] {"a link to somewhere", "another link"}),
            new ScienceFact("Fact3", "Some other fact info", new string[] {"a link to somewhere", "another link"}),
            new ScienceFact("Fact4", "Some... uh... more fact info", new string[] {"a link to somewhere", "another link"})
        };

        /// <summary>
        /// Get all the science facts in the database!
        /// </summary>
        /// <returns>The science facts</returns>
        [HttpGet]
        [Route("/get/facts")]
        [SwaggerOperation("GetOperation")]
        [SwaggerResponse(200,Type =typeof(string),Description ="Get operation")]
        [SwaggerResponse(500, Type = typeof(string), Description = "Internal Server Error")]
        [SwaggerResponse(404, Type = typeof(string), Description = "Method Not Found")]
        public IEnumerable<ScienceFact> GetAllScienceFacts()
        {
            return Facts;
        }

        /// <summary>
        /// Gets a random science fact. Contains the title, the fact, and links to sources.
        /// </summary>
        /// <returns>A single science fact data.</returns>
        [HttpGet]
        [Route("/get/randomfact")]
        [SwaggerOperation("GetOperation")]
        [SwaggerResponse(200,Type =typeof(string),Description ="Get operation")]
        [SwaggerResponse(500, Type = typeof(string), Description = "Internal Server Error")]
        [SwaggerResponse(404, Type = typeof(string), Description = "Method Not Found")]
        public ScienceFact GetRandomScienceFact()
        {
            Random random = new Random();
            int index = random.Next(Facts.Count());
            return Facts.ElementAt(index);
        }
    }
}
