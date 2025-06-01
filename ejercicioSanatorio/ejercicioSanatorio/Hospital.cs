using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioSanatorio
{
    public class Hospital
    {
        public List<Doctor> Doctores { get; set; } = new();
        public List<Paciente> Pacientes { get; set; } = new();
        public List<Intervencion> Intervenciones { get; set; } = new();
        private int ultimoID = 1;

        public Hospital()
        {
            // Doctores
            Doctores.Add(new Doctor("Juan Pérez", "12345", "Cardiología", true));
            Doctores.Add(new Doctor("Laura Gómez", "23456", "Traumatología", false));
            Doctores.Add(new Doctor("Carlos Ruiz", "34567", "Neurología", true));
            Doctores.Add(new Doctor("María Silva", "45678", "Gastroenterología", true));
            Doctores.Add(new Doctor("Fernando Torres", "56789", "Cardiología", true));
            Doctores.Add(new Doctor("Cecilia López", "67890", "Traumatología", true));

            // Pacientes
            Pacientes.Add(new Paciente("30111222", "Ana Torres", "1111-2222", "ObraMed", 80));
            Pacientes.Add(new Paciente("29222333", "Luis Fernández", "2222-3333", null, 0));
            Pacientes.Add(new Paciente("28444555", "Clara Méndez", "3333-4444", "SaludPlus", 90));
            Pacientes.Add(new Paciente("27555666", "Pedro Gómez", "4444-5555", "VidaTotal", 70));
            Pacientes.Add(new Paciente("26666777", "Lucía Ortega", "5555-6666", null, 0));
            Pacientes.Add(new Paciente("25777888", "Jorge Ramírez", "6666-7777", "SaludPlus", 60));

            // Intervenciones comunes
            Intervenciones.Add(new IntervencionComun("INT001", "Bypass coronario", "Cardiología", 120000));
            Intervenciones.Add(new IntervencionComun("INT003", "Artroscopía de rodilla", "Traumatología", 80000));
            Intervenciones.Add(new IntervencionComun("INT005", "Endoscopía digestiva", "Gastroenterología", 40000));
            Intervenciones.Add(new IntervencionComun("INT007", "Colocación de stent", "Cardiología", 95000));
            Intervenciones.Add(new IntervencionComun("INT008", "Reducción de fractura", "Traumatología", 60000));

            // Intervenciones de alta complejidad
            Intervenciones.Add(new IntervencionAltaComplejidad("INT002", "Neurocirugía", "Neurología", 200000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT004", "Revascularización miocárdica", "Cardiología", 250000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT006", "Cirugía de columna", "Traumatología", 180000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT009", "Cirugía bariátrica", "Gastroenterología", 220000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT010", "Craneotomía", "Neurología", 270000));
        }

        public void DarDeAltaPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void ListarPacientes()
        {
            foreach (var p in Pacientes)
            {
                Console.WriteLine($"DNI: {p.DNI} - {p.NombreApellido} - {p.ObraSocial}");
            }
        }

        public void AsignarIntervencion(string dniPaciente, string codigoIntervencion, string matriculaMedico, DateTime fecha, string estadoPago)
        {
            var paciente = Pacientes.Find(p => p.DNI == dniPaciente);
            var intervencion = Intervenciones.Find(i => i.Codigo == codigoIntervencion);
            var medico = Doctores.Find(m => m.Matricula == matriculaMedico);

            if (paciente == null || intervencion == null || medico == null || medico.Especialidad != intervencion.Especialidad)
            {
                Console.WriteLine("Error: Datos inválidos o especialidad incompatible.");
                return;
            }

            var registro = new RegistroIntervencion(ultimoID++, fecha, intervencion, medico, paciente, estadoPago);
            paciente.Intervenciones.Add(registro);
        }

        public decimal CalcularCostoTotalPaciente(string dni)
        {
            var paciente = Pacientes.Find(p => p.DNI == dni);
            if (paciente == null) return 0;

            return paciente.Intervenciones.Sum(i => i.CalcularImporte());
        }

        public void ReportePendientes()
        {
            Console.WriteLine("\n=== LIQUIDACIONES PENDIENTES ===");
            foreach (var p in Pacientes)
            {
                foreach (var r in p.Intervenciones.Where(i => i.EstadoPago == "Pendiente"))
                {
                    r.MostrarLineaReporte();
                }
            }
        }
    }
}
