using CamadaDeNegócios.Dtos;
using FluentValidation;

namespace ApiExpIFoodTNF.Notifications;

public class EmpresaValidation : AbstractValidator<EmpresaDto>
{
    public EmpresaValidation()
    {
        RuleFor(x => x.Nome)
            .MinimumLength(3)
            .WithMessage("O Nome deve ter entre 3 e 40 caracteres!")
            .MaximumLength(40)
            .WithMessage("O Nome deve ter entre 3 e 40 caracteres!");
    }
}
