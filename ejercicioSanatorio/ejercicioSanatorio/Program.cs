using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicioSanatorio
{
    class Program
    {
        static void Main()
        {
            Hospital hospital = new();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Alta paciente");
                Console.WriteLine("2. Listar pacientes");
                Console.WriteLine("3. Asignar intervención a paciente");
                Console.WriteLine("4. Calcular costo total intervenciones de un paciente");
                Console.WriteLine("5. Reporte de liquidaciones pendientes");
                Console.WriteLine("0. Salir");

                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("DNI: ");
                        string dni = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string tel = Console.ReadLine();
                        Console.Write("Obra social (- si no tiene): ");
                        string obra = Console.ReadLine();
                        Console.Write("Cobertura (0-100): ");
                        decimal cob = decimal.Parse(Console.ReadLine());

                        hospital.DarDeAltaPaciente(new Paciente(dni, nombre, tel, obra, cob));
                        break;

                    case "2":
                        hospital.ListarPacientes();
                        break;

                    case "3":
                        Console.Write("DNI del paciente: ");
                        string d1 = Console.ReadLine();
                        Console.Write("Código de intervención: ");
                        string cod = Console.ReadLine();
                        Console.Write("Matrícula del doctor: ");
                        string mat = Console.ReadLine();
                        Console.Write("Fecha (yyyy-MM-dd): ");
                        DateTime fecha = DateTime.Parse(Console.ReadLine());
                        Console.Write("Estado de pago (Pendiente/Pago): ");
                        string pago = Console.ReadLine();

                        hospital.AsignarIntervencion(d1, cod, mat, fecha, pago);
                        break;

                    case "4":
                        Console.Write("DNI del paciente: ");
                        string dniCosto = Console.ReadLine();
                        var total = hospital.CalcularCostoTotalPaciente(dniCosto);
                        Console.WriteLine($"Costo total: ${total:0.00}");
                        break;

                    case "5":
                        hospital.ReportePendientes();
                        break;

                    case "0":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}