namespace Mesa.AddFeatureFolders.WebApplication.Features.Shared.Components.MainMenu
{
    using Microsoft.AspNetCore.Mvc;

    public class MainMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke ( )
        {
            return this.View ( );
        }
    }
}