using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("CategoryName can not be empty");
            RuleFor(x => x.CategoryName).MaximumLength(10).WithMessage("Enter up to 10 character");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Enter at least 10 characters");
        }

    }

    
}
