using System.Diagnostics;
using Programa1.Estadistica.Dominio;
using Xunit;

namespace Programa1.Estadistica.Tests;

public class ListaEnlazadaTests
{
    // CP-08: Lista nueva, inserción y recorrido en orden
    [Fact]
    public void CP08_AgregarYRecorrer_ConservaOrdenYCantidad()
    {
        var lista = new ListaEnlazada();
        Assert.True(lista.EstaVacia);
        Assert.Equal(0, lista.Cantidad);

        lista.Agregar(3.0);
        lista.Agregar(1.0);
        lista.Agregar(2.0);

        Assert.False(lista.EstaVacia);
        Assert.Equal(3, lista.Cantidad);
        Assert.Equal(new[] { 3.0, 1.0, 2.0 }, lista.ToArray());
    }

    // CP-19: Rendimiento O(1) con 100 000 números en menos de 1000 ms
    [Fact]
    public void CP19_Rendimiento_CienMilDatos_MenosDeUnSegundo()
    {
        var lista = new ListaEnlazada();
        var sw = Stopwatch.StartNew();

        for (var i = 0; i < 100_000; i++)
        {
            lista.Agregar(i % 100);
        }

        var resultado = CalculadoraEstadistica.Calcular(lista);
        sw.Stop();

        Assert.Equal(100_000, resultado.Cantidad);
        Assert.True(sw.ElapsedMilliseconds < 1_000,
            $"El cálculo tardó {sw.ElapsedMilliseconds} ms, excediendo el límite de 1000 ms.");
    }
}
