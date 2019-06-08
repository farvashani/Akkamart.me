using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akkamart.Home.Server.Domain;
using Akkamart.Home.Shared;
using Akkamart.Home.Shared.Models;
using Akkatecture.Akka;
using Microsoft.AspNetCore.Mvc;


namespace Akkamart.Home.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRegisteryController : ControllerBase
    {
        private readonly ActorRefProvider<HomeActor> _HomeActor;        
        public ServiceRegisteryController(ActorRefProvider<HomeActor> homeActor)
        {
             _HomeActor = homeActor;
            
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] ServiceRegistery registery)
        {
            var cmd = new RegisterService(registery);
            _HomeActor.Tell(cmd);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}