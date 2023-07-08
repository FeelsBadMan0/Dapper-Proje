using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class VisitorAddValidation : AbstractValidator<Visitor>
    {
        public VisitorAddValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş bırakılamaz.");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı Adı alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı Adı alanı en fazla 20 karakter olmalıdır.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz.");
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("Mail alanı en az 10 karakter olmalıdır.");
            RuleFor(x => x.Mail).MaximumLength(40).WithMessage("Mail alanı en fazla 40 karakter olmalıdır.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifre alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Şifre alanı en fazla 100 karakter olmalıdır.");



            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Parolalar uyuşmuyor.");
        }
    }
}
