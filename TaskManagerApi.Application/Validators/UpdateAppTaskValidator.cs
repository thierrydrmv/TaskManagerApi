using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Application.DTOs;

namespace TaskManagerApi.Application.Validators
{
    public class UpdateAppTaskValidator : AbstractValidator<UpdateAppTaskDto>
    {
        public UpdateAppTaskValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("The task Id is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required.")
                .MaximumLength(100)
                .WithMessage("The title must have a maximum of 100 characters.");
        }
    }
}
