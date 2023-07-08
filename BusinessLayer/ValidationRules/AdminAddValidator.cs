﻿using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AdminAddValidator : AbstractValidator<Admin>
    {
        public AdminAddValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı alanı boş geçilemez.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Kullanıcı Adı alanı en fazla 20 karakterden oluşmalıdır.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Şifre alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre alanı en fazla 20 karakterden oluşmalıdır.");


            RuleFor(x => x.AdminRoles).NotEmpty().WithMessage("Rol alanı boş geçilemez.");
            RuleFor(x => x.AdminRoles).MinimumLength(3).WithMessage("Rol alanı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.AdminRoles).MaximumLength(5).WithMessage("Rol alanı en fazla 5 karakterden oluşmalıdır.");
        }
    }
}
