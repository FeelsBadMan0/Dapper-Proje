using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class VisitorUpdateValidator : AbstractValidator<Visitor>
    {
        public VisitorUpdateValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifre alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre alanı en fazla 20 karakter olmalıdır.");



            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Parolalar uyuşmuyor.");
        }
    }
}
