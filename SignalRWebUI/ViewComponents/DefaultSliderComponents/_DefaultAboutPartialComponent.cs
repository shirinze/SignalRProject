using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
    public class _DefaultAboutPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
