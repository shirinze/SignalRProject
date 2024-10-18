using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();
			return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			var values = _notificationService.TNotificationCountByStatusFalse();
			return Ok(values);
		}
		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			var value = _notificationService.TGetAllNotificationByFalse();
			return Ok(value);

		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createnotificationdto)
		{
			createnotificationdto.Status = false;
			var value = _mapper.Map<Notification>(createnotificationdto);
			_notificationService.TAdd(value);
			return Ok("eklem işlemi başariyla yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok("başarılı bir sekilde silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(_mapper.Map<GetNotificationDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updatenotificationdto)
		{
			var value = _mapper.Map<Notification>(updatenotificationdto);
			_notificationService.TUpdate(value);
			return Ok("başarılı bir sekilde güncellendı");

		}
		[HttpGet("NotificationStatusChangetoTrue/{id}")]
		public IActionResult NotificationStatusChangetoTrue(int id)
		{
			_notificationService.TNotificationStatusChangetoTrue(id);
			return Ok("güncellendı");
		}
		[HttpGet("NotificationStatusChangetoFalse/{id}")]
		public IActionResult NotificationStatusChangetoFalse(int id)
		{
			_notificationService.TNotificationStatusChangetoFalse(id);
			return Ok("güncellendı");
		}
	}
}