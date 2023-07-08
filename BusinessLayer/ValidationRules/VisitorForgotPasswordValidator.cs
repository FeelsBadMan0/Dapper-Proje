using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class VisitorForgotPasswordValidator : AbstractValidator<Visitor>
    {
        public VisitorForgotPasswordValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz.");
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("Mail alanı en az 10 karakter olmalıdır.");
            RuleFor(x => x.Mail).MaximumLength(40).WithMessage("Mail alanı en fazla 40 karakter olmalıdır.");
        }
    }
}
