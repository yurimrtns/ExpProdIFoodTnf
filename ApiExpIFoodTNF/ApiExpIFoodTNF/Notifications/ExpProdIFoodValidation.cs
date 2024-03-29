﻿using CamadaDeNegócios.Dtos;
using FluentValidation;

namespace ApiExpIFoodTNF.Notifications;

public class ExpProdIFoodValidation : AbstractValidator<ExpProdIFoodDto>
{
    public ExpProdIFoodValidation()
    {
        RuleFor(x => x.IdLojaIFood)
            .GreaterThan(0)
            .WithMessage("O número deve ser um inteiro maior que zero!");

        RuleFor(x => x.Ativo)
            .Length(1)
            .WithMessage("O campo deve conter 1 caractere!");
    }
}
