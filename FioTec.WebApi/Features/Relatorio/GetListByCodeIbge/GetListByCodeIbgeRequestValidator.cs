using FluentValidation;

namespace FioTec.WebApi.Features.Relatorio.GetListByCodeIbge
{
    public class GetListByCodeIbgeRequestValidator : AbstractValidator<int>
    {
        public GetListByCodeIbgeRequestValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("O código IBGE não pode ser vazio.");
        }
    }
}
