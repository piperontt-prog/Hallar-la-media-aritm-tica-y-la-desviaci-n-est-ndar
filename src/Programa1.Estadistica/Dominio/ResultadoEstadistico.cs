namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Registro inmutable que almacena el resultado consolidado del análisis estadístico.
/// Cumple con RF-03, RF-04 y RF-05.
/// </summary>
/// <param name="Cantidad">Cantidad total de datos analizados (n).</param>
/// <param name="Media">Media aritmética calculada.</param>
/// <param name="DesviacionEstandar">Desviación estándar muestral calculada, o null si n &lt; 2.</param>
public sealed record ResultadoEstadistico(int Cantidad, double Media, double? DesviacionEstandar);
