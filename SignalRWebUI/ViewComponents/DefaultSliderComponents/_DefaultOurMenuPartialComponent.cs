using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
	public class _DefaultOurMenuPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
