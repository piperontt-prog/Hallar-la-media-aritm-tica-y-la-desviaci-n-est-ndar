using System.Globalization;
using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Presentacion;

/// <summary>
/// Interfaz de usuario para consola. Encapsula presentación, alineación y captura interactiva.
/// Cumple con RF-05, RF-07, RNF-02 y RNF-05.
/// </summary>
public sealed class ConsolaUI
{
    private readonly TextReader _entrada;
    private readonly TextWriter _salida;
    private const string FormatoNumero = "F2";

    public ConsolaUI(TextReader entrada, TextWriter salida)
    {
        _entrada = entrada ?? throw new ArgumentNullException(nameof(entrada));
        _salida = salida ?? throw new ArgumentNullException(nameof(salida));
    }

    /// <summary>Muestra el encabezado estándar del programa.</summary>
    public void MostrarEncabezado()
    {
        _salida.WriteLine("===================================================");
        _salida.WriteLine(" PSP0 · Programa 1 — Media y desviación estándar");
        _salida.WriteLine("===================================================");
    }

    /// <summary>Solicita la ruta del archivo de datos interactivamente.</summary>
    public string PedirRuta()
    {
        _salida.Write("Ruta del archivo de datos (un número por línea): ");
        var ruta = _entrada.ReadLine();
        return ruta?.Trim() ?? string.Empty;
    }

    /// <summary>Muestra el resultado consolidado del análisis estadístico.</summary>
    public void MostrarResultado(string ruta, ResultadoEstadistico resultado)
    {
        ArgumentNullException.ThrowIfNull(resultado);
        _salida.WriteLine($"Archivo leído : {ruta}");
        _salida.WriteLine($"Datos (n)     : {resultado.Cantidad}");
        _salida.WriteLine($"Media         : {Formatear(resultado.Media)}");

        if (resultado.DesviacionEstandar.HasValue)
        {
            _salida.WriteLine($"Desv. estándar: {Formatear(resultado.DesviacionEstandar.Value)}");
        }
        else
        {
            _salida.WriteLine("Desv. estándar: no definida (se necesitan al menos 2 datos)");
        }
    }

    /// <summary>Muestra un mensaje de error legible al usuario.</summary>
    public void MostrarError(string mensaje)
    {
        _salida.WriteLine($"ERROR: {mensaje}");
    }

    private static string Formatear(double valor)
    {
        return valor.ToString(FormatoNumero, CultureInfo.InvariantCulture);
    }
}
