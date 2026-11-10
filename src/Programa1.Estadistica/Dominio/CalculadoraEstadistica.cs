namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Módulo de cálculo estadístico para media y desviación estándar.
/// Cumple con RF-03 y RF-04.
/// </summary>
public static class CalculadoraEstadistica
{
    /// <summary>Cantidad mínima requerida para calcular desviación estándar muestral.</summary>
    public const int MinimoParaDesviacion = 2;

    /// <summary>Calcula la media aritmética.</summary>
    public static double Media(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);
        if (datos.EstaVacia)
        {
            throw new DatosInsuficientesException("Se necesita al menos 1 dato para calcular la media.");
        }

        double suma = 0;
        foreach (var valor in datos)
        {
            suma += valor;
        }

        return suma / datos.Cantidad;
    }

    /// <summary>Calcula la desviación estándar.</summary>
    public static double DesviacionEstandar(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);
        if (datos.Cantidad < MinimoParaDesviacion)
        {
            throw new DatosInsuficientesException(
                $"Se necesitan al menos {MinimoParaDesviacion} datos para calcular la desviación estándar.");
        }

        var media = Media(datos);
        double sumaCuadrados = 0;
        foreach (var valor in datos)
        {
            sumaCuadrados += Math.Pow(valor - media, 2);
        }

        return Math.Sqrt(sumaCuadrados / (datos.Cantidad - 1));
    }

    /// <summary>Consolida el cálculo estadístico completo.</summary>
    public static ResultadoEstadistico Calcular(ListaEnlazada datos)
    {
        ArgumentNullException.ThrowIfNull(datos);
        var media = Media(datos);
        double? desviacion = datos.Cantidad >= MinimoParaDesviacion
            ? DesviacionEstandar(datos)
            : null;

        return new ResultadoEstadistico(datos.Cantidad, media, desviacion);
    }
}
