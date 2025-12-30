namespace Mesa.AddFeatureFolders.WebApplication.Areas.Administration.Features.Test
{
    using Microsoft.AspNetCore.Mvc;

    [Area ( "Administration" )]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Index ( )
        {
            return this.View ( "Index" , typeof ( TestController ) );
        }
    }
}