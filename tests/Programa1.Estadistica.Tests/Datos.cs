using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Tests;

public static class Datos
{
    public static readonly double[] Tabla1Columna1 =
    [
        160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503
    ];

    public static readonly double[] Tabla1Columna2 =
    [
        15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2
    ];

    public static readonly double[] Tabla3Ejemplo =
    [
        186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601
    ];

    public static ListaEnlazada Lista(IEnumerable<double> valores)
    {
        var lista = new ListaEnlazada();
        foreach (var v in valores)
        {
            lista.Agregar(v);
        }

        return lista;
    }
}
