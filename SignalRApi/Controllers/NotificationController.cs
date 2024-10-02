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

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();
			return Ok(values);
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
			Notification notification = new Notification() 
			{ 
				Description=createnotificationdto.Description,
				Type=createnotificationdto.Type,
				Icon=createnotificationdto.Icon,
				Status=false,
				Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
			
			};
			_notificationService.TAdd(notification);
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
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updatenotificationdto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updatenotificationdto.NotificationID,
				Icon = updatenotificationdto.Icon,
				Description = updatenotificationdto.Description,
				Type = updatenotificationdto.Type,
				Status = updatenotificationdto.Status,
				Date = updatenotificationdto.Date
			};
			_notificationService.TUpdate(notification);
			return Ok("başarılı bir sekilde güncellendı");

		}
	}
}