using System.Net.Http;
using System.Threading.Tasks;
using Akkamart.Shared.Metadata;
using Microsoft.AspNetCore.Components;

namespace Akkamart.Home.Client.Shared {
    public class NavigationBase : ComponentBase {
        
         [Inject]
        public HttpClient Http{get; set;}
        
        protected NavigationState navigationState = new NavigationState ();
        protected override async Task OnInitAsync () {

            navigationState = await Http.GetJsonAsync<NavigationState> ("api/home/GetTopNavigation");

        }

    }
}