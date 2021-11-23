using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Application.Property.Commands
{
    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
