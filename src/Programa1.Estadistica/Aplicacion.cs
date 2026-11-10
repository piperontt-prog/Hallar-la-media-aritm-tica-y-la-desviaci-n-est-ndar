using Programa1.Estadistica.Dominio;
using Programa1.Estadistica.Infraestructura;
using Programa1.Estadistica.Presentacion;

namespace Programa1.Estadistica;

/// <summary>
/// Coordinador principal de la aplicación. Orquesta lectura, cálculo y presentación (RF-06, RF-07).
/// </summary>
public static class Aplicacion
{
    public const int Exito = 0;
    public const int ErrorDatos = 1;

    public static int Ejecutar(string[] args, TextReader entrada, TextWriter salida)
    {
        ArgumentNullException.ThrowIfNull(args);
        var ui = new ConsolaUI(entrada, salida);
        ui.MostrarEncabezado();

        var ruta = args.Length > 0 ? args[0] : ui.PedirRuta();
        if (string.IsNullOrWhiteSpace(ruta))
        {
            ui.MostrarError("No se proporcionó una ruta de archivo válida.");
            return ErrorDatos;
        }

        try
        {
            var datos = LectorArchivoNumeros.Leer(ruta);
            var resultado = CalculadoraEstadistica.Calcular(datos);
            ui.MostrarResultado(ruta, resultado);
            return Exito;
        }
        catch (Exception ex) when (ex is DatosInvalidosException or DatosInsuficientesException)
        {
            ui.MostrarError(ex.Message);
            return ErrorDatos;
        }
    }
}
