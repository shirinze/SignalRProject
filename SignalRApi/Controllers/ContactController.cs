using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactservice;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactservice, IMapper mapper)
        {
            _contactservice = contactservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createcontactdto)
        {
            _contactservice.TAdd(new Contact()
            {
                Location=createcontactdto.Location,
                Phone=createcontactdto.Phone,
                Mail=createcontactdto.Mail,
                FooterDescription=createcontactdto.FooterDescription

            });
            return Ok("basarili bir sekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactservice.TGetByID(id);
            _contactservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactservice.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updatecontactdto)
        {
            _contactservice.TUpdate(new Contact() 
            {
                ContactID=updatecontactdto.ContactID,
                Location=updatecontactdto.Location,
                Phone=updatecontactdto.Phone,
                Mail=updatecontactdto.Mail,
                FooterDescription=updatecontactdto.FooterDescription
            
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
