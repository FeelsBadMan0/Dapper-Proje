using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class VisitorAdminAddValidator : AbstractValidator<Visitor>
    {
        public VisitorAdminAddValidator()
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

            RuleFor(x => x.Roles).NotEmpty().WithMessage("Rol alanı boş bırakılamaz.");
            RuleFor(x => x.Roles).MinimumLength(3).WithMessage("Rol alanı en az 3 karakter olmalıdır.");
            RuleFor(x => x.Roles).MaximumLength(10).WithMessage("Rol alanı en fazla 10 karakter olmalıdır.");

        }
    }
}
