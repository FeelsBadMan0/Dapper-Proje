using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class VisitorLoginValidator : AbstractValidator<Visitor>
    {
        public VisitorLoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş bırakılamaz.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı Adı alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı Adı alanı en fazla 20 karakter olmalıdır.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifre alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Şifre alanı en fazla 100 karakter olmalıdır.");
        }
    }
}
