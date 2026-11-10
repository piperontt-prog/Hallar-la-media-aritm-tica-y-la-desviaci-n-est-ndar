namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Representa un nodo individual en la lista enlazada simple.
/// Almacena un número real (double) y la referencia al siguiente nodo.
/// Cumple con RF-02.
/// </summary>
public sealed class Nodo
{
    /// <summary>Valor numérico real almacenado en el nodo.</summary>
    public double Valor { get; }

    /// <summary>Referencia al siguiente nodo en la secuencia enlazada.</summary>
    public Nodo? Siguiente { get; set; }

    /// <summary>
    /// Inicializa un nuevo nodo con el valor proporcionado.
    /// </summary>
    /// <param name="valor">Número real a encapsular.</param>
    public Nodo(double valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}
