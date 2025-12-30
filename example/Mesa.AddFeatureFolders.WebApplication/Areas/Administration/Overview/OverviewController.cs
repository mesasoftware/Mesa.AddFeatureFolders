namespace Mesa.AddFeatureFolders.WebApplication.Areas.Administration.Overview
{
    using Microsoft.AspNetCore.Mvc;

    [Area ( "Administration" )]
    public class OverviewController : Controller
    {
        [HttpGet]
        public IActionResult Index ( )
        {
            return this.View ( );
        }
    }
}