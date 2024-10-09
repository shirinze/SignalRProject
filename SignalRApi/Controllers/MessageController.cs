using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}
		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_messageService.TGetListAll());
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createmessagedto)
		{
			Message message = new Message() 
			{ 
				NameSurename=createmessagedto.NameSurename,
				Mail=createmessagedto.Mail,
				Phone=createmessagedto.Phone,
				Subject=createmessagedto.Subject,
				MessageContent=createmessagedto.MessageContent,
				MessageSendDate=Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				Status=false
			};
			_messageService.TAdd(message);
			return Ok("basari bir sekilde eklendi");

		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value=_messageService.TGetByID(id);
			_messageService.TDelete(value);
			return Ok("basarili bir sekilde silindi");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updatemessagedto)
		{
			Message message = new Message() 
			{
				MessageID=updatemessagedto.MessageID,
				NameSurename = updatemessagedto.NameSurename,
				Mail = updatemessagedto.Mail,
				Phone = updatemessagedto.Phone,
				Subject = updatemessagedto.Subject,
				MessageContent = updatemessagedto.MessageContent,
				MessageSendDate = updatemessagedto.MessageSendDate,
				Status = false
			};
			_messageService.TUpdate(message);
			return Ok("basarili bir sekilde guncellnedi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(value);
		}
	}
}
