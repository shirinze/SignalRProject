using AutoMapper;
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
		private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpGet]
		public IActionResult MessageList()
		{
			var value = _messageService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMessageDto>>(value));
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createmessagedto)
		{
			createmessagedto.Status = false;
			createmessagedto.MessageSendDate = DateTime.Now;
			var value = _mapper.Map<Message>(createmessagedto);
			_messageService.TAdd(value);
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
			updatemessagedto.Status = false;
			var value=_mapper.Map<Message>(updatemessagedto);
			_messageService.TUpdate(value);
			return Ok("basarili bir sekilde guncellnedi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(_mapper.Map<GetMessageDto>(value));
		}
	}
}
