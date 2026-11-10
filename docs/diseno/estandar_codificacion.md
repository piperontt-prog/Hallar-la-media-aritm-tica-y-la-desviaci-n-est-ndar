# Estándar de Codificación C# (.NET 9) y Convenciones Git

**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Proceso:** PSP0 · Fase de Diseño  
**Autor:** Camilo Andrés Torres  
**Fecha:** 2 de noviembre de 2026  

---

## 1. Reglas de Codificación C#

| Regla | Descripción | Ejemplo Correcto | Ejemplo Incorrecto |
|:---:|---|---|---|
| **E-01** | **Nombres de Tipos y Miembros:** Clases, estructuras, registros, métodos y propiedades en `PascalCase`, sustantivos o verbos claros en español. | `CalculadoraEstadistica.Media()` | `calc.m()`, `calculadora_estadistica` |
| **E-02** | **Variables Locales y Parámetros:** En `camelCase`, descriptivos y sin abreviaciones ambiguas. | `sumaCuadrados`, `numeroLinea` | `sc`, `nl`, `x1` |
| **E-03** | **Campos Privados:** Prefijados con guion bajo `_` en `camelCase`. | `private Nodo? _primero;` | `private Nodo primero;` |
| **E-04** | **Constantes y Sin Números Mágicos:** Identificadores con nombre en `PascalCase`. | `const int MinimoParaDesviacion = 2;` | `if (n < 2)` |
| **E-05** | **Tipos Explícitos vs var:** Usar `var` cuando el tipo resulte evidente en el lado derecho; tipo explícito si aclara la semántica. | `var nodo = new Nodo(valor);` | `var x = Obtener();` (si el tipo no es obvio) |
| **E-06** | **Tipos de Referencia Anulables (NRT):** Activados obligatoriamente (`<Nullable>enable</Nullable>`). Los tipos anulables llevan `?`. | `public Nodo? Siguiente { get; set; }` | Supresiones con `!` injustificadas |
| **E-07** | **Inmutabilidad y Sellado:** Clases que no son puntos de extensión se declaran `sealed`. | `public sealed class ListaEnlazada` | Clases públicas abiertas sin justificación |
| **E-08** | **Longitud de Métodos:** Máximo 30 líneas de código efectivo por método. Una única responsabilidad. | `Convertir()` desacoplado de `LeerLineas()` | Método `Main` de 120 líneas monolítico |
| **E-09** | **Comentarios de Documentación:** Todo miembro público debe contar con documentación XML `/// <summary>`. Comentarios de línea `//` únicamente para justificar decisiones. | `/// <summary>Calcula la media...</summary>` | `// suma uno a i` |
| **E-10** | **Validación Temprana (Fail-Fast):** Validar argumentos y precondiciones al inicio de cada método público. | `ArgumentNullException.ThrowIfNull(datos);` | Dejar que ocurra `NullReferenceException` profunda |
| **E-11** | **Excepciones Propias para Errores del Dominio:** No capturar `Exception` genérica vacía ni silenciar errores. | `throw new DatosInvalidosException(...)` | `catch { }` |
| **E-12** | **Cultura Invariante Obligatoria:** Toda conversión y formateo de números en punto flotante debe especificar `CultureInfo.InvariantCulture`. | `double.TryParse(..., CultureInfo.InvariantCulture, ...)` | `double.Parse(texto)` (sensible a cultura del SO) |
| **E-13** | **Precisión de Acumuladores:** Variables acumuladoras para sumas y medias deben declararse de tipo `double`. | `double suma = 0.0;` | `int suma = 0;` (genera truncamiento o error de asignación CS0266) |
| **E-14** | **Tratamiento de Advertencias como Errores:** Configurar `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>` y `<AnalysisLevel>latest-recommended</AnalysisLevel>`. | Compilación con 0 advertencias | Ignorar advertencias de compilador |
| **E-15** | **Inyección de Entrada/Salida para Pruebas:** Las clases de consola no deben acoplarse rígidamente a `System.Console`. Deben admitir `TextReader` y `TextWriter`. | `new ConsolaUI(entrada, salida)` | Invocaciones directas a `Console.ReadLine()` no interceptables |
| **E-16** | **Aislamiento Estricto del Dominio:** Las clases de Dominio (`ListaEnlazada`, `CalculadoraEstadistica`) no deben tener dependencias de I/O, consola ni librerías externas. | `Media(ListaEnlazada datos)` puro | `Calculadora` leyendo archivos o escribiendo a pantalla |

---

## 2. Convención de Mensajes de Commit (PSP0)

Cada commit debe representar el cierre auditable de una fase del proceso PSP0, utilizando los siguientes prefijos estandarizados:

1. `planeacion: <descripción>`
2. `diseno: <descripción>`
3. `codigo: <descripción>`
4. `compilacion: <descripción y códigos de error CS corregidos>`
5. `pruebas: <descripción de casos y estado de ejecución>`
6. `postmortem: <resumen de métricas, análisis y PIP>`
