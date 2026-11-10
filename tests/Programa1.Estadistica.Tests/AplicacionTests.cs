using Xunit;

namespace Programa1.Estadistica.Tests;

public class AplicacionTests
{
    // CP-15: Argumento de línea de comandos con archivo válido
    [Fact]
    public void CP15_ArgumentoRuta_MuestraResultadosYRetornaCero()
    {
        var ruta = Path.Combine("datos", "columna1_tamano_proxy.txt");
        using var entrada = new StringReader(string.Empty);
        using var salida = new StringWriter();

        var codigo = Aplicacion.Ejecutar([ruta], entrada, salida);
        var salidaTexto = salida.ToString();

        Assert.Equal(0, codigo);
        Assert.Contains("550.60", salidaTexto);
        Assert.Contains("572.03", salidaTexto);
    }

    // CP-16: Sin argumentos -> pide la ruta por entrada estándar
    [Fact]
    public void CP16_SinArgumentos_PideRutaPorEntradaYRetornaCero()
    {
        var ruta = Path.Combine("datos", "columna2_horas.txt");
        using var entrada = new StringReader(ruta + Environment.NewLine);
        using var salida = new StringWriter();

        var codigo = Aplicacion.Ejecutar([], entrada, salida);
        var salidaTexto = salida.ToString();

        Assert.Equal(0, codigo);
        Assert.Contains("60.32", salidaTexto);
        Assert.Contains("62.26", salidaTexto);
    }

    // CP-16b: Sin argumentos y ruta en blanco retorna ErrorDatos (1)
    [Fact]
    public void CP16b_RutaEnBlanco_MuestraErrorYRetornaUno()
    {
        using var entrada = new StringReader(Environment.NewLine);
        using var salida = new StringWriter();

        var codigo = Aplicacion.Ejecutar([], entrada, salida);

        Assert.Equal(1, codigo);
        Assert.Contains("ERROR:", salida.ToString());
    }

    // CP-17: Archivo vacío muestra mensaje de error y retorna 1
    [Fact]
    public void CP17_ArchivoVacio_MuestraErrorYRetornaUno()
    {
        var ruta = Path.Combine("datos", "vacio.txt");
        using var entrada = new StringReader(string.Empty);
        using var salida = new StringWriter();

        var codigo = Aplicacion.Ejecutar([ruta], entrada, salida);
        var salidaTexto = salida.ToString();

        Assert.Equal(1, codigo);
        Assert.Contains("ERROR:", salidaTexto);
        Assert.DoesNotContain("NaN", salidaTexto);
    }

    // CP-18: Archivo con un solo dato muestra 'no definida' y retorna 0
    [Fact]
    public void CP18_ArchivoUnDato_MuestraDesviacionNoDefinidaYRetornaCero()
    {
        var ruta = Path.Combine("datos", "uno.txt");
        using var entrada = new StringReader(string.Empty);
        using var salida = new StringWriter();

        var codigo = Aplicacion.Ejecutar([ruta], entrada, salida);
        var salidaTexto = salida.ToString();

        Assert.Equal(0, codigo);
        Assert.Contains("42.50", salidaTexto);
        Assert.Contains("no definida", salidaTexto);
    }
}
