namespace Mesa.AddFeatureFolders.WebApplication.Features.Foo
{
    using Microsoft.AspNetCore.Mvc;

    [Route ( "Foo/[controller]" )]
    public class HomeController : Controller
    {
        public IActionResult Home ( )
        {
            return this.View ( );
        }

        [HttpPost]
        public IActionResult Search ( )
        {
            // do some stuff...
            return this.View ( "Home" );
            // this will also work
            // return Redirect("/Foo/Home");

            // TODO: posting to /Foo/Home or /Bar/Home with Content-Type: application/x-www-form-urlencoded always routes to the "Bar" feature controller            
            // return RedirectToAction("Home");
        }
    }
}
