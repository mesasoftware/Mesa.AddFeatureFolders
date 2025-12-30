namespace Mesa.AddFeatureFolders.WebApplication.Features.Home
{
    using Microsoft.AspNetCore.Mvc;

    [Route ( "" )]
    public class HomeController : Controller
    {
        public IActionResult Home ( )
        {
            return this.View ( );
        }

        [Route ( "[action]" )]
        public IActionResult Create ( )
        {
            return this.Content ( "Create" );
        }
    }
}
