using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName can not be empty");
            RuleFor(x => x.UnitsOnOrder).NotEmpty().WithMessage("UnitOnOrder can not be empty");
            RuleFor(t => t.UnitPrice).ExclusiveBetween(0, 1000);
        }

           
    }
}
