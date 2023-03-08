using System;
using Application.Service.Application.Handlers;
using FluentValidation;

namespace Application.Service.Application.Validation
{
    public class UpdateApplicationRequestValidator : AbstractValidator<UpdateApplicationRequest>
    {
        public UpdateApplicationRequestValidator()
        {
            RuleFor(x => x.ApplicationId).NotNull().NotEmpty();
            //RuleFor(x => x.Business).NotNull();
            //RuleFor(x => x.Business.Name).NotEmpty().MinimumLength(3);
        }
    }
}

