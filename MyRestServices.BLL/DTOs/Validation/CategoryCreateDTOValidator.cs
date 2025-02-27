﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MyRestServices.BLL.DTOs.Validation
{
    public class CategoryCreateDTOValidator: AbstractValidator<CategoryCreateDTO>
    {

            public CategoryCreateDTOValidator()
            {
                RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name harus diisi");
                RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Category Name maksimal 50 karakter");
            }
        
    }
}
