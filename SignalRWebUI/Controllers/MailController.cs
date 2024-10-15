using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(CreateMailDto createmailDto)
		{
			MimeMessage mimemessage = new MimeMessage();

			MailboxAddress mailboxaddressFrom = new MailboxAddress("signalr rezervasyon", "shirinzeinalirezaei@gmail.com");
			mimemessage.From.Add(mailboxaddressFrom);

			MailboxAddress mailboxaddressTo = new MailboxAddress("User", createmailDto.ReceiverMail);
			mimemessage.To.Add(mailboxaddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = createmailDto.Body;
			mimemessage.Body=bodyBuilder.ToMessageBody();

			mimemessage.Subject=createmailDto.Subject;

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587,false);
			client.Authenticate("shirinzeinalirezaei@gmail.com", "qden jzdz gkns hmfv");

			client.Send(mimemessage);
			client.Disconnect(true);

			return RedirectToAction("Index", "Category");
		}
	}
}
