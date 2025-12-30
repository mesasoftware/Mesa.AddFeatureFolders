namespace Mesa.AddFeatureFolders.WebApplication.Areas.Administration.Features.Test.SubFolder
{
    using Microsoft.AspNetCore.Mvc;

    [Area ( "Administration" )]
    public class SubFolderController : Controller
    {
        [HttpGet]
        public IActionResult Index ( )
        {
            return this.View ( );
        }
    }
}