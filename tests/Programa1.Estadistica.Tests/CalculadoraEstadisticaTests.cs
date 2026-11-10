using Programa1.Estadistica.Dominio;
using Xunit;

namespace Programa1.Estadistica.Tests;

public class CalculadoraEstadisticaTests
{
    // CP-01: Tabla 1, columna 1 (proxy size)
    [Fact]
    public void CP01_Tabla1Columna1_MediaYDesviacionEsperadas()
    {
        var resultado = CalculadoraEstadistica.Calcular(Datos.Lista(Datos.Tabla1Columna1));
        Assert.Equal(550.60, resultado.Media, 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(572.03, resultado.DesviacionEstandar.Value, 2);
    }

    // CP-02: Tabla 1, columna 2 (development hours)
    [Fact]
    public void CP02_Tabla1Columna2_MediaYDesviacionEsperadas()
    {
        var resultado = CalculadoraEstadistica.Calcular(Datos.Lista(Datos.Tabla1Columna2));
        Assert.Equal(60.32, resultado.Media, 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(62.26, resultado.DesviacionEstandar.Value, 2);
    }

    // CP-03: Tabla 3 del kit SEI
    [Fact]
    public void CP03_Tabla3Ejemplo_MediaYDesviacionEsperadas()
    {
        var resultado = CalculadoraEstadistica.Calcular(Datos.Lista(Datos.Tabla3Ejemplo));
        Assert.Equal(638.90, resultado.Media, 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(625.63, resultado.DesviacionEstandar.Value, 2);
    }

    // CP-04: Lista vacía a Media() lanza DatosInsuficientesException
    [Fact]
    public void CP04_ListaVacia_LanzaDatosInsuficientesException()
    {
        var vacia = new ListaEnlazada();
        Assert.Throws<DatosInsuficientesException>(() => CalculadoraEstadistica.Media(vacia));
    }

    // CP-05: Un solo dato -> media calculable, desviación null
    [Fact]
    public void CP05_UnSoloDato_MediaCorrectaYDesviacionNula()
    {
        var datos = Datos.Lista([42.5]);
        var resultado = CalculadoraEstadistica.Calcular(datos);
        Assert.Equal(1, resultado.Cantidad);
        Assert.Equal(42.5, resultado.Media, 2);
        Assert.Null(resultado.DesviacionEstandar);
    }

    // CP-06: Varianza cero
    [Fact]
    public void CP06_ValoresIdenticos_DesviacionCero()
    {
        var datos = Datos.Lista([7.0, 7.0, 7.0, 7.0]);
        var resultado = CalculadoraEstadistica.Calcular(datos);
        Assert.Equal(7.0, resultado.Media, 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(0.0, resultado.DesviacionEstandar.Value, 2);
    }

    // CP-07: Negativos y cero
    [Fact]
    public void CP07_ValoresNegativosYPositivos_CalculoCorrecto()
    {
        var datos = Datos.Lista([-2.5, 0.0, 2.5]);
        var resultado = CalculadoraEstadistica.Calcular(datos);
        Assert.Equal(0.0, resultado.Media, 2);
        Assert.NotNull(resultado.DesviacionEstandar);
        Assert.Equal(2.50, resultado.DesviacionEstandar.Value, 2);
    }
}
