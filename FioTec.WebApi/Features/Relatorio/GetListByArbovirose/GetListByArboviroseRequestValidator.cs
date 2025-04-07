using FluentValidation;

namespace FioTec.WebApi.Features.Relatorio.GetListByArbovirose
{
    public class GetListByArboviroseRequestValidator : AbstractValidator<string>
    {
        public GetListByArboviroseRequestValidator()
        {

            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A arbovirose não pode ser vazio.");
        }
    }
}
