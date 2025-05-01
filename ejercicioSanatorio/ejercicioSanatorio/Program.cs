using System;
using System.Collections.Generic;

namespace ejercicioSanatorio
{
    class Medico
    {
        public string NombreApellido;
        public string Matricula;
        public string Especialidad;
        public bool Disponible;

        public Medico(string nombreApellido, string matricula, string especialidad, bool disponible)
        {
            NombreApellido = nombreApellido;
            Matricula = matricula;
            Especialidad = especialidad;
            Disponible = disponible;
        }
    }
    class Intervencion
    {
        public string Codigo;
        public string Descripcion;
        public string Especialidad;
        public decimal Arancel;
        public bool AltaComplejidad;

        public Intervencion(string codigo, string descripcion, string especialidad, decimal arancel, bool altaComplejidad)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Especialidad = especialidad;
            Arancel = arancel;
            AltaComplejidad = altaComplejidad;
        }

        public decimal ObtenerCostoTotal()
        {
            if (AltaComplejidad)
                return Arancel + (Arancel * 0.3m);
            else
                return Arancel;
        }
    }

    class Paciente
    {
        public string DNI;
        public string NombreApellido;
        public string Telefono;
        public string ObraSocial;
        public decimal Cobertura;
        public List<RegistroIntervencion> Intervenciones;

        public Paciente(string dni, string nombreApellido, string telefono, string obraSocial, decimal cobertura)
        {
            DNI = dni;
            NombreApellido = nombreApellido;
            Telefono = telefono;
            ObraSocial = obraSocial;
            Cobertura = cobertura;
            Intervenciones = new List<RegistroIntervencion>();
        }
    }

    class RegistroIntervencion
    {
        public int ID;
        public DateTime Fecha;
        public Intervencion Intervencion;
        public Medico Medico;
        public string EstadoPago;
        public Paciente Paciente;

        public RegistroIntervencion(int id, DateTime fecha, Intervencion intervencion, Medico medico, Paciente paciente, string estadoPago)
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
            decimal total = Intervencion.ObtenerCostoTotal();
            if (Paciente.ObraSocial != "-")
            {
                total -= total * Paciente.Cobertura;
            }
            return total;
        }

        public void MostrarLineaReporte()
        {
            Console.WriteLine(ID + " | " + Fecha.ToShortDateString() + " | " + Intervencion.Descripcion + " | " +
                Paciente.NombreApellido + " | " + Medico.NombreApellido + " (" + Medico.Matricula + ") | " +
                (Paciente.ObraSocial != "" ? Paciente.ObraSocial : "-") + " | $" + CalcularImporte());
        }
    }

    class Sanatorio
    {
        private List<Medico> medicos = new List<Medico>();
        private List<Intervencion> intervenciones = new List<Intervencion>();
        private List<Paciente> pacientes = new List<Paciente>();
        private int ultimoID = 1;

        public void AgregarMedico(Medico medico)
        {
            medicos.Add(medico);
        }

        public void AgregarIntervencion(Intervencion intervencion)
        {
            intervenciones.Add(intervencion);
        }

        public void AgregarPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
        }

        public Paciente BuscarPaciente(string dni)
        {
            foreach (Paciente p in pacientes)
            {
                if (p.DNI == dni) return p;
            }
            return null;
        }

        public void RegistrarIntervencion(string dniPaciente, string codigoIntervencion, string matriculaMedico, DateTime fecha, string estadoPago)
        {
            Paciente paciente = BuscarPaciente(dniPaciente);
            if (paciente == null)
            {
                paciente = new Paciente(dniPaciente, "Nuevo Paciente", "0000-0000", "-", 0);
                pacientes.Add(paciente);
            }

            Intervencion intervencion = intervenciones.Find(i => i.Codigo == codigoIntervencion);
            Medico medico = medicos.Find(m => m.Matricula == matriculaMedico);

            if (medico.Especialidad != intervencion.Especialidad)
            {
                Console.WriteLine("Error: La especialidad del médico no coincide con la intervención.");
                return;
            }

            RegistroIntervencion registro = new RegistroIntervencion(ultimoID++, fecha, intervencion, medico, paciente, estadoPago);
            paciente.Intervenciones.Add(registro);
        }

        public void MostrarReportePendientes()
        {
            Console.WriteLine("=== LIQUIDACIONES PENDIENTES ===");
            foreach (Paciente paciente in pacientes)
            {
                foreach (RegistroIntervencion ri in paciente.Intervenciones)
                {
                    if (ri.EstadoPago == "Pendiente")
                        ri.MostrarLineaReporte();
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Sanatorio sanatorio = new Sanatorio();

            sanatorio.AgregarMedico(new Medico("Dr. Pérez", "123", "Cardiología", true));
            sanatorio.AgregarMedico(new Medico("Dra. Ruiz", "456", "Traumatología", true));

            sanatorio.AgregarIntervencion(new Intervencion("INT001", "Bypass coronario", "Cardiología", 50000, false));
            sanatorio.AgregarIntervencion(new Intervencion("INT002", "Columna lumbar", "Traumatología", 80000, true));

            sanatorio.AgregarPaciente(new Paciente("11111111", "Carlos Gómez", "3412345678", "OSDE", 0.8m));
            sanatorio.AgregarPaciente(new Paciente("22222222", "Laura Díaz", "3498765432", "-", 0));

            sanatorio.RegistrarIntervencion("11111111", "INT001", "123", DateTime.Now, "Pendiente");
            sanatorio.RegistrarIntervencion("22222222", "INT002", "456", DateTime.Now, "Pendiente");

            sanatorio.MostrarReportePendientes();
        }
    }
}
