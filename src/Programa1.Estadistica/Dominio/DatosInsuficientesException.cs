namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Excepción lanzada cuando los datos proporcionados no satisfacen la cantidad mínima
/// requerida para una operación estadística (RF-06).
/// </summary>
public sealed class DatosInsuficientesException : Exception
{
    public DatosInsuficientesException(string mensaje) : base(mensaje)
    {
    }
}
