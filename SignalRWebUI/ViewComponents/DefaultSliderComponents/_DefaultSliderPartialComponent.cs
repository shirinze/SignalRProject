using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
    public class _DefaultSliderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
