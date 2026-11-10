# Documento de Diseño de Arquitectura y Componentes (PSP0)

**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Proceso:** PSP0 · Fase de Diseño (DLD)  
**Autor:** Camilo Andrés Torres  
**Fecha:** 2 de noviembre de 2026  

---

## 1. Arquitectura en Capas

El sistema se estructura siguiendo una arquitectura en 4 capas concéntricas basada en principios de separación de responsabilidades y diseño guiado por el dominio (DDD elemental):

```
┌────────────────────────────────────────────────────────┐
│             Presentación (Presentacion/)               │
│  - ConsolaUI (TextReader / TextWriter)                 │
└───────────────────────────┬────────────────────────────┘
                            │ usa
┌───────────────────────────▼────────────────────────────┐
│              Aplicación (Aplicacion.cs)                │
│  - Orquesta el flujo: ruta -> leer -> calcular -> ui   │
│  - Mapea excepciones de dominio a códigos de retorno  │
└─────────────┬───────────────────────────┬──────────────┘
              │ usa                       │ usa
┌─────────────▼──────────────┐ ┌──────────▼──────────────┐
│       Infraestructura      │ │         Dominio         │
│     (Infraestructura/)     │ │        (Dominio/)       │
│ - LectorArchivoNumeros     │ │ - ListaEnlazada, Nodo   │
│ - DatosInvalidosException  │ │ - CalculadoraEstadistica│
│                            │ │ - ResultadoEstadistico  │
│                            │ │ - DatosInsuficientes... │
└────────────────────────────┘ └─────────────────────────┘
```

### Responsabilidad de cada componente:
1. **Presentación (`Presentacion/ConsolaUI.cs`):**
   - Recibe la entrada del usuario y da formato visual estricto a los resultados numéricos o mensajes de error.
   - Utiliza `CultureInfo.InvariantCulture` para garantizar que la salida use punto decimal (`F2`).
   - Admite inyección de `TextReader` y `TextWriter` para facilitar pruebas unitarias automatizadas con `StringReader` y `StringWriter`.

2. **Aplicación (`Aplicacion.cs`):**
   - Punto de coordinación del caso de uso.
   - Determina si la ruta viene de `args` o se solicita interactivamente.
   - Captura las excepciones controladas (`DatosInvalidosException`, `DatosInsuficientesException`) y devuelve el código de salida adecuado (`0` para éxito, `1` para error).

3. **Infraestructura (`Infraestructura/LectorArchivoNumeros.cs`):**
   - Lee el archivo línea por línea en streaming.
   - Omite líneas vacías.
   - Realiza la conversión con `double.TryParse(..., NumberStyles.Float, CultureInfo.InvariantCulture, ...)`.
   - Lanza `DatosInvalidosException` indicando el número exacto de línea ante datos corruptos.

4. **Dominio (`Dominio/`):**
   - **`Nodo`:** Estructura que almacena un número de tipo `double` y el enlace al siguiente nodo.
   - **`ListaEnlazada`:** Implementa `IEnumerable<double>`, administra el puntero inicial `_primero` y final `_ultimo`, lo que garantiza que `Agregar` sea una operación $O(1)$ sin recorrer la lista.
   - **`CalculadoraEstadistica`:** Módulo de funciones puras (`Media`, `DesviacionEstandar`, `Calcular`) sin efectos secundarios ni dependencias de I/O.
   - **`ResultadoEstadistico`:** Registro inmutable (`record`) con `Cantidad`, `Media` y `DesviacionEstandar`.

---

## 2. Decisión sobre Base de Datos y Persistencia

### Justificación de NO inclusión de Base de Datos relacional ni documental:
- **Requisito del cliente:** El enunciado oficial del SEI Assignment Kit estipula expresamente:
  > *"Escribir un programa que lea $n$ números reales de un archivo de texto, los almacene en una lista enlazada propia y calcule su media y desviación estándar."*
- **Volatilidad y Naturaleza del Problema:** El procesamiento es por lotes (*batch execution*), autónomo y sin estado persistente entre corridas.
- **Sobrecarga técnica innecesaria:** Introducir un motor de base de datos (como SQLite o PostgreSQL) incrementaría la complejidad de despliegue, configuración de conexiones, migraciones y dependencias sin aportar valor a ninguno de los requisitos funcionales (RF-01 a RF-07).
- **Conclusión arquitectónica:** Los datos de entrada residen en archivos de texto plano (`.txt`) y los datos procesados residen en memoria dinámica dentro de la clase `ListaEnlazada`. La persistencia adicional está formalmente descartada.

---

## 3. Manejo de Errores y Códigos de Salida

| Condición Detectada | Origen | Excepción Lanzada | Salida al Usuario | Código de Salida |
|---|---|---|---|:---:|
| Ejecución nominal correcta | Dominio / Aplicación | Ninguna | Encabezado, Archivo leído, Datos (n), Media, Desv. estándar | `0` |
| Archivo no existe | Infraestructura | `DatosInvalidosException` | `"ERROR: No se encontró el archivo: <ruta>"` | `1` |
| Línea con texto no numérico | Infraestructura | `DatosInvalidosException` | `"ERROR: Línea <k>: «<texto>» no es un número real..."` | `1` |
| Archivo vacío o solo espacios | Infraestructura | `DatosInvalidosException` | `"ERROR: El archivo no contiene datos numéricos válidos."` | `1` |
| Archivo con 1 solo dato ($n=1$) | Dominio / UI | Ninguna (caso límite) | Datos (n): 1, Media: valor, Desv: no definida | `0` |
| Lista vacía enviada a cálculo | Dominio | `DatosInsuficientesException` | `"ERROR: Se necesita al menos 1 dato..."` | `1` |
