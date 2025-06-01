using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicioSanatorio
{
    public class Paciente
    {
        public string DNI { get; set; }
        public string NombreApellido { get; set; }
        public string Telefono { get; set; }
        public string ObraSocial { get; set; }
        public decimal Cobertura { get; set; }
        public List<RegistroIntervencion> Intervenciones { get; set; } = new();

        public Paciente(string dni, string nombreApellido, string telefono, string obraSocial, decimal cobertura)
        {
            DNI = dni;
            NombreApellido = nombreApellido;
            Telefono = telefono;
            ObraSocial = obraSocial ?? "-";
            Cobertura = cobertura;
        }
    }

    public class RegistroIntervencion
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public Intervencion Intervencion { get; set; }
        public Doctor Medico { get; set; }
        public string EstadoPago { get; set; }
        public Paciente Paciente { get; set; }

        public RegistroIntervencion(int id, DateTime fecha, Intervencion intervencion, Doctor medico, Paciente paciente, string estadoPago)
        {
            ID = id;
            Fecha = fecha;
            Intervencion = intervencion;
            Medico = medico;
            Paciente = paciente;
            EstadoPago = estadoPago;
        }

        public decimal CalcularImporte()
        {
            var total = Intervencion.ObtenerCostoTotal();
            return total - total * (Paciente.Cobertura / 100m);
        }

        public void MostrarLineaReporte()
        {
            Console.WriteLine($"{ID} | {Fecha.ToShortDateString()} | {Intervencion.Descripcion} | {Paciente.NombreApellido} | {Medico.NombreApellido} ({Medico.Matricula}) | {Paciente.ObraSocial} | ${CalcularImporte():0.00}");
        }
    }
}
