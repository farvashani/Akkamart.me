using Akkatecture.Akka;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Akkamart.Shared.Metadata;
using Akkamart.Server.Shared.Client;
using Akkamart.Server.Shared.Client.Commands;

namespace Akkamart.Home.Server.Controllers
{
    [Route("/home/api/[controller]")]
    public class HomeController : Controller
    {
        public HomeController(ActorRefProvider<Navigator> navs)
        {
            _NavigationActor = navs;
            
        }
        private readonly ActorRefProvider<Navigator> _NavigationActor;        

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTopNavigation()
        {
            var getNavigationState = new GetNavigationState();
            var navs = await _NavigationActor.Ask<NavigationState>(getNavigationState);
            return Ok(navs);
        }
        
       
    
       
    }
}
