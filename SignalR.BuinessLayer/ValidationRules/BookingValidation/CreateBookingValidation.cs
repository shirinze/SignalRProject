using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BuinessLayer.ValidationRules.BookingValidation
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Isim alani boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alani boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alani boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi alani boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alani boş geçilemez!");

            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Isim alani en fazla 50 karakter olmali");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açiklama alani en fazla 500 karakter olmali");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz!!!");
        }
    }
}
