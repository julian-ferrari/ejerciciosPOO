using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioSanatorio
{
    public abstract class Intervencion
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Especialidad { get; set; }
        public decimal Arancel { get; set; }

        protected Intervencion(string codigo, string descripcion, string especialidad, decimal arancel)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Especialidad = especialidad;
            Arancel = arancel;
        }

        public abstract decimal ObtenerCostoTotal();
    }

    public class IntervencionComun : Intervencion
    {
        public IntervencionComun(string codigo, string descripcion, string especialidad, decimal arancel)
            : base(codigo, descripcion, especialidad, arancel) { }

        public override decimal ObtenerCostoTotal() => Arancel;
    }

    public class IntervencionAltaComplejidad : Intervencion
    {
        public IntervencionAltaComplejidad(string codigo, string descripcion, string especialidad, decimal arancel)
            : base(codigo, descripcion, especialidad, arancel) { }

        public override decimal ObtenerCostoTotal() => Arancel * 1.3m;
    }
}
