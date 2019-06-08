using Akkamart.Home.Server.Domain;
using Akkamart.Home.Shared;
using Akkatecture.Akka;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akkamart.Home.Server.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ActorRefProvider<HomeActor> _HomeActor;        
        public async Task<IActionResult> ActionName()
        {
            // TODO: Your code here
            await Task.Yield();
            return View();
        }
        
       
       public HomeController(ActorRefProvider<HomeActor> homeActor)
       {
           _HomeActor = homeActor;
           
       }
        
       
    }
}
