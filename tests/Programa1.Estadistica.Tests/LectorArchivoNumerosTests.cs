using System.Globalization;
using Programa1.Estadistica.Infraestructura;
using Xunit;

namespace Programa1.Estadistica.Tests;

public class LectorArchivoNumerosTests
{
    // CP-09: Ignorar líneas en blanco
    [Fact]
    public void CP09_LeerLineas_IgnoraLineasEnBlanco()
    {
        var lineas = new[] { " 10 ", "", "   ", "20" };
        var lista = LectorArchivoNumeros.LeerLineas(lineas);
        Assert.Equal(2, lista.Cantidad);
        Assert.Equal(new[] { 10.0, 20.0 }, lista.ToArray());
    }

    // CP-10: Formato no numérico indica número de línea
    [Fact]
    public void CP10_LeerLineas_DatoInvalido_LanzaConNumeroDeLinea()
    {
        var lineas = new[] { "1", "2", "abc" };
        var ex = Assert.Throws<DatosInvalidosException>(() => LectorArchivoNumeros.LeerLineas(lineas));
        Assert.Equal(3, ex.Linea);
        Assert.Contains("Línea 3", ex.Message);
        Assert.Contains("abc", ex.Message);
    }

    // CP-11: Archivo con sólo líneas en blanco lanza DatosInvalidosException
    [Fact]
    public void CP11_LeerLineas_SoloLineasEnBlanco_LanzaDatosInvalidosException()
    {
        var lineas = new[] { "", "   ", "\t" };
        Assert.Throws<DatosInvalidosException>(() => LectorArchivoNumeros.LeerLineas(lineas));
    }

    // CP-12: Archivo inexistente lanza DatosInvalidosException
    [Fact]
    public void CP12_Leer_ArchivoInexistente_LanzaDatosInvalidosException()
    {
        var ex = Assert.Throws<DatosInvalidosException>(() =>
            LectorArchivoNumeros.Leer("ruta_totalmente_inexistente.txt"));
        Assert.Contains("No se encontró el archivo", ex.Message);
    }

    // CP-13: Independencia de cultura regional (es-CO)
    [Fact]
    public void CP13_LeerLineas_CulturaEsCO_UsaPuntoDecimal()
    {
        var original = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-CO");
            var lista = LectorArchivoNumeros.LeerLineas(["15.0", "6.5"]);
            Assert.Equal(new[] { 15.0, 6.5 }, lista.ToArray());
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }

    // CP-14: Lectura de archivo físico existente
    [Fact]
    public void CP14_Leer_ArchivoRealColumna2_CantidadDiez()
    {
        var ruta = Path.Combine("datos", "columna2_horas.txt");
        var lista = LectorArchivoNumeros.Leer(ruta);
        Assert.Equal(10, lista.Cantidad);
    }
}
