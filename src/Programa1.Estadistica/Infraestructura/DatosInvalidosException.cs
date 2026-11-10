namespace Programa1.Estadistica.Infraestructura;

/// <summary>
/// Excepción lanzada cuando los datos leídos del archivo son inválidos, corruptos o no numéricos (RF-06).
/// </summary>
public sealed class DatosInvalidosException : Exception
{
    /// <summary>Número de línea del archivo donde ocurrió el error, o null si es general.</summary>
    public int? Linea { get; }

    public DatosInvalidosException(string mensaje, int? linea = null) : base(mensaje)
    {
        Linea = linea;
    }
}
