﻿using escuela_app.App;
using escuela_app.Entidades;
using escuela_app.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsg = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluaXAsig();
            var listaPromXAsig = reporteador.GetPromeAlumnPorAsignatura();

            Printer.WriteTitle("Captura de una Evaluación por Consola");
            var newEval = new Evaluacion();
            string nombre, notastring;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluacion ha sido ingresado correctamente");
            }


            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notastring = Console.ReadLine();


            try
            {
                newEval.Nota = float.Parse(notastring);
                if (newEval.Nota < 0 || newEval.Nota > 5)
                {
                    throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                }
                WriteLine("La nota de la evaluacion ha sido ingresada correctamente");
                return;
            }
            catch (ArgumentOutOfRangeException arge)
            {
                Printer.WriteTitle(arge.Message);
                WriteLine("Saliendo del programa");
            }
            finally
            {
                Printer.WriteTitle("FINALLY");
                Printer.Beep(2500, 500, 3);

            }
      

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIÓ");
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
