using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTec.Domain.Entities
{
    public class RelatorioEntity
    {
        public int Id { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public string Arbovirose { get; set; }

        public int SemanaInicio { get; set; }

        public int SemanaFim { get; set; }

        public int CodigoIbge { get; set; }

        public string Municipio { get; set; }

        public Guid SolicitanteId { get; set; }

        public SolicitanteEntity Solicitante { get; set; }
    }
}
