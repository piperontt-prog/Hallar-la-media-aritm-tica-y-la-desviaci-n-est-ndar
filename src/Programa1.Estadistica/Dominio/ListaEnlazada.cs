using System.Collections;

namespace Programa1.Estadistica.Dominio;

/// <summary>
/// Estructura de datos propia de lista enlazada simple que implementa IEnumerable&lt;double&gt;.
/// Administra punteros al primer y último nodo para permitir inserciones O(1) en cola (RNF-06).
/// Cumple con RF-02.
/// </summary>
public sealed class ListaEnlazada : IEnumerable<double>
{
    private Nodo? _primero;
    private Nodo? _ultimo;

    /// <summary>Cantidad total de elementos en la lista (n).</summary>
    public int Cantidad { get; private set; }

    /// <summary>Indica si la lista no contiene ningún nodo.</summary>
    public bool EstaVacia => Cantidad == 0;

    /// <summary>
    /// Agrega un nuevo valor al final de la lista enlazada en tiempo O(1).
    /// </summary>
    /// <param name="valor">Número real a agregar.</param>
    public void Agregar(double valor)
    {
        var nuevo = new Nodo(valor);
        if (_ultimo is null)
        {
            _primero = nuevo;
        }
        else
        {
            _ultimo.Siguiente = nuevo;
        }

        _ultimo = nuevo;
        Cantidad++;
    }

    /// <summary>
    /// Permite iterar secuencialmente por todos los valores de la lista en orden de inserción.
    /// </summary>
    public IEnumerator<double> GetEnumerator()
    {
        for (var actual = _primero; actual is not null; actual = actual.Siguiente)
        {
            yield return actual.Valor;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
