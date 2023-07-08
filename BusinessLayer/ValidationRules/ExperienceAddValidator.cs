using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceAddValidator : AbstractValidator<Experience>
    {
        public ExperienceAddValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Platform alanı boş geçilemez.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Platform alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Platform alanı en fazla 100 karakterden oluşmalıdır.");


            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Ünvan alanı boş geçilemez.");
            RuleFor(x => x.SubTitle).MinimumLength(3).WithMessage("Ünvan alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.SubTitle).MaximumLength(100).WithMessage("Ünvan alanı en fazla 100 karakterden oluşmalıdır.");


            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Açıklama alanı en az 20 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama alanı en fazla 1000 karakterden oluşmalıdır.");



            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");
            RuleFor(x => x.Date).MinimumLength(4).WithMessage("Tarih alanı en az 4 karakterden oluşmalıdır.");
            RuleFor(x => x.Date).MaximumLength(100).WithMessage("Tarih alanı en fazla 100 karakterden oluşmalıdır.");
        }
    }
}
