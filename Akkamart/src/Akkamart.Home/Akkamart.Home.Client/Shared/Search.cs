using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace Akkamart.Home.Client.Shared
{
    public class Search : ComponentBase
    {
    
    [Inject]
    protected IUriHelper UriHelper { get; set; }
 
    [Inject]
    protected HttpClient Http { get; set; }
 
    public override void OnInit()
    {
        
    }
    protected overide void OnAfterRender()
    {

    }
    
}
}