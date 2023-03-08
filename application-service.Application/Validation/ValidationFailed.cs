using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Application.Service.Application.Validation
{
    public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
    {
        public ValidationFailed(ValidationFailure error) : this(new[] { error })
        {
        }
    }
}

