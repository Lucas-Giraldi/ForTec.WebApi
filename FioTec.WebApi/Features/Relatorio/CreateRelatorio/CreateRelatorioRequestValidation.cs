using FluentValidation;
using System.Text.RegularExpressions;

namespace FioTec.WebApi.Features.Relatorio.CreateRelatorio
{
    public class CreateRelatorioRequestValidation : AbstractValidator<CreateRelatorioRequest>
    {
        public CreateRelatorioRequestValidation()
        {
            RuleFor(x => x.Solicitante.Name)
                .NotEmpty().WithMessage("O nome do solicitante é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.");

            RuleFor(x => x.Solicitante.Cpf)
                .NotEmpty().WithMessage("O CPF do solicitante é obrigatório.")
                .Must(SerCpfValido).WithMessage("O CPF informado é inválido.");

            RuleFor(x => x.CodigoIbge)
                .NotEmpty().WithMessage("Codigo Ibge é obrigatória.");
        }

        private bool SerCpfValido(string cpf)
        {
            return Regex.IsMatch(cpf, @"^\d{11}$");
        }
    }
}
