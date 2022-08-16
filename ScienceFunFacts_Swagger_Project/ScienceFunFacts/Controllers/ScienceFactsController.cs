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
    public class ScienceFactsController : Controller
    {
        private static readonly IEnumerable<ScienceFact> Facts = new ScienceFact[]
        {
            new ScienceFact("Space is BIG!", "Did you know the universe is at least 250 larger than the observable universe?", new string[] { "https://www.space.com/24073-how-big-is-the-universe.html", "https://nineplanets.org/questions/how-big-is-the-universe/"}),
            new ScienceFact("2 is the only even prime number!", "Test it for yourself. 2 is divisible only by itself and one, all other even numbers are divisible by two.", new string[] { "https://byjus.com/questions/why-is-2-the-only-even-prime-number/"}),
            new ScienceFact("The biggest robot as of April 2022 is 28 feet tall!", "It is so big, you have to take off its head to get it out of the warehouse.", new string[] {"https://supercarblondie.com/tech/worlds-biggest-robot-28-feet-tall-shoots-sponge-balls-87mph/"}),
            new ScienceFact("An octopus has 9 brains!", "The majority of an octopuses neurons are spread out across its tentacles! As though they have 8 for each arm.", new string[] {"https://a-z-animals.com/blog/how-many-brains-does-an-octopus-have/"})
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
