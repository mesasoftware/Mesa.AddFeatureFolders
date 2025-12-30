namespace Mesa.AddFeatureFolders.WebApplication.Features.Foo.SubFoo
{
    using Microsoft.AspNetCore.Mvc;

    [Route ( "Foo/SubFoo/[controller]" )]
    public class SubFooController : Controller
    {
        [HttpGet]
        public IActionResult SubFoo ( )
        {
            return this.View ( );
        }
    }
}