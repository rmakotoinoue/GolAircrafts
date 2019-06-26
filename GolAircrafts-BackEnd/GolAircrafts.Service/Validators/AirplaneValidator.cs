using FluentValidation;
using System;
using GolAirCrafts.Domain.Entities;

namespace GolAirCrafts.Service.Validators
{
    public class AirplaneValidator : AbstractValidator<Airplane>
    {
        public AirplaneValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Erro ao localizar objeto.");
                });
        }
    }
}
