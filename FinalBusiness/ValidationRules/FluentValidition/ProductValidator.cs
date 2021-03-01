using FinalEntities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FinalBusiness.ValidationRules.FluentValidition
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);//p nin adı en az 2 harf olmalı
            RuleFor(p => p.UnitPrice).NotEmpty();//boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0);//büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//koşullu durum
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A ile başlamalı");//kendi kuralımız, with message mesaj düzenleme ve eklleme için kullanılır normalde 19 dil destekli dir kendisinin ki...
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");//c# içindeki şeyler istediğimizi yazabiliriz.
        }
    }//ctrl+k+d düzenleştirme
}
