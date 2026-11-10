using Programa1.Estadistica.Dominio;

namespace Programa1.Estadistica.Infraestructura;

/// <summary>
/// Componente de lectura secuencial de archivos numéricos (RF-01, RF-06).
/// </summary>
public static class LectorArchivoNumeros
{
    /// <summary>Lee todos los números reales de un archivo en disco.</summary>
    public static ListaEnlazada Leer(string ruta)
    {
        if (!File.Exists(ruta))
        {
            throw new DatosInvalidosException($"No se encontró el archivo: {ruta}");
        }

        return LeerLineas(File.ReadLines(ruta));
    }

    /// <summary>Procesa una secuencia de líneas de texto y construye la lista enlazada.</summary>
    public static ListaEnlazada LeerLineas(IEnumerable<string> lineas)
    {
        ArgumentNullException.ThrowIfNull(lineas);
        var lista = new ListaEnlazada();
        var numeroLinea = 0;

        foreach (var linea in lineas)
        {
            numeroLinea++;
            var textoLimpio = linea.Trim();
            if (textoLimpio.Length == 0)
            {
                continue;
            }

            var valor = Convertir(textoLimpio, numeroLinea);
            lista.Agregar(valor);
        }

        return lista;
    }

    private static double Convertir(string texto, int numeroLinea)
    {
        try
        {
            return double.Parse(texto);
        }
        catch (FormatException)
        {
            throw new DatosInvalidosException(
                $"Línea {numeroLinea}: «{texto}» no es un número real. Use punto decimal (ej. 15.0).", numeroLinea);
        }
    }
}
