using CamadaDeNegócios.Dtos;
using FluentValidation;

namespace ApiExpIFoodTNF.Notifications;

public class ExpProdIFoodValidation : AbstractValidator<ExpProdIFoodDto>
{
    public ExpProdIFoodValidation()
    {
        RuleFor(x => x.IdLojaIFood)
            .NotEmpty()
            .WithMessage("O campo deve não pode ser vazio")
            .GreaterThan(0)
            .WithMessage("O Id da Loja deve ser maior que zero e inteiro!");
    }
}
