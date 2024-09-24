using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
	public class _DefaultOurMenuPartialComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpclientFactory;

        public _DefaultOurMenuPartialComponent(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

      
	}
}
