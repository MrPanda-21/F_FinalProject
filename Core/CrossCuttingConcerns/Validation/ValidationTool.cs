using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);//doğrulanacak olanı al
            var result = validator.Validate(context);//doğrula
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);//error yolla api
            }
        }
    }
}
