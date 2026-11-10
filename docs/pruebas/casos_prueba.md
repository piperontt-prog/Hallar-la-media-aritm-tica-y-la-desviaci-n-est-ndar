# Especificación y Diseño de Casos de Prueba (PSP0)

**Proyecto:** Programa 1 · Media y Desviación Estándar con Lista Enlazada  
**Proceso:** PSP0 · Fase de Pruebas  
**Autor:** Camilo Andrés Torres  
**Fecha:** 4 de noviembre de 2026  

---

## 1. Estrategia de Pruebas

Para garantizar la cobertura completa de los Requisitos Funcionales (RF-01 a RF-07) y Requisitos No Funcionales (RNF-01 a RNF-08), se aplicaron técnicas de diseño de pruebas de caja negra y caja blanca:
- **Partición en Clases de Equivalencia:** Datos reales, decimales, negativos, ceros.
- **Análisis de Valores Límite (BVA):** Lista vacía ($n=0$), un solo elemento ($n=1$), tamaño mínimo para desviación ($n=2$).
- **Pruebas de Robustez / Negativas:** Archivo inexistente, líneas con texto corrupto, archivos en blanco.
- **Pruebas de Independencia Regional:** Validación bajo cultura hispana (`es-CO`) para punto decimal.
- **Pruebas de Desempeño:** Inserción y cálculo sobre $100\,000$ elementos en memoria.

---

## 2. Matriz de Casos de Prueba

| Caso | Requisito Trazable | Técnica de Diseño | Datos de Entrada | Resultado Esperado |
|:---:|---|---|---|---|
| **CP-01** | RF-03, RF-04, RNF-03 | Datos del Kit (Tabla 1, Col. 1) | `160, 591, 114, 229, 230, 270, 128, 1657, 624, 1503` | Media: $550.60 \pm 0.01$<br>Desv. muestral: $572.03 \pm 0.01$ |
| **CP-02** | RF-03, RF-04, RNF-03 | Datos del Kit (Tabla 1, Col. 2) | `15.0, 69.9, 6.5, 22.4, 28.4, 65.9, 19.4, 198.7, 38.8, 138.2` | Media: $60.32 \pm 0.01$<br>Desv. muestral: $62.26 \pm 0.01$ |
| **CP-03** | RF-03, RF-04 | Ejemplo resuelto (Tabla 3) | `186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601` | Media: $638.90 \pm 0.01$<br>Desv. muestral: $625.63 \pm 0.01$ |
| **CP-04** | RF-06 | Límite inferior ($n=0$) | `ListaEnlazada` vacía enviada a `Media()` | Lanza `DatosInsuficientesException` con mensaje claro |
| **CP-05** | RF-04, RF-06 | Límite ($n=1$) | Un solo valor: `42.5` | Media: $42.50$; Desviación: `null` (no definida) |
| **CP-06** | RF-04 | Varianza nula | `7.0, 7.0, 7.0, 7.0` ($n=4$ idénticos) | Desv. estándar: $0.00$ |
| **CP-07** | RF-03, RF-04 | Reales con signo | `-2.5, 0.0, 2.5` | Media: $0.00$; Desv: $2.50$ |
| **CP-08** | RF-02 | Integridad de Estructura | Lista vacía; luego agregar `3.0, 1.0, 2.0` | `EstaVacia` pasa de `true` a `false`; `Cantidad=3`; orden: `3, 1, 2` |
| **CP-09** | RF-01 | Manejo de espacios | Líneas: `" 10 "`, `""`, `"   "`, `"20"` | Omite vacías; lista resultante con `[10, 20]`, $n=2$ |
| **CP-10** | RF-06, RNF-05 | Validación de formato | Líneas: `"1"`, `"2"`, `"abc"` | Lanza `DatosInvalidosException` indicando `"Línea 3"` |
| **CP-11** | RF-06 | Archivo sin números | Líneas: `""`, `"   "`, `"  \t "` | Lanza `DatosInvalidosException` ("no contiene datos...") |
| **CP-12** | RF-06 | Archivo no existe | Ruta: `"archivo_fantasma_inexistente.txt"` | Lanza `DatosInvalidosException` ("No se encontró...") |
| **CP-13** | RNF-02 | Independencia cultural | Líneas: `"15.0"`, `"6.5"` con cultura `es-CO` | Se interpretan como `15.0` y `6.5` (NO como `150` y `65`) |
| **CP-14** | RF-01 | Lectura física en disco | Archivo real: `datos/columna2_horas.txt` | Lee exitosamente $n=10$ elementos |
| **CP-15** | RF-05, RF-07 | Consola con argumento | Argumento: `datos/columna1_tamano_proxy.txt` | Muestra 3 líneas formateadas (`550.60`, `572.03`); salida `0` |
| **CP-16** | RF-07 | Consola sin argumentos | Sin args; entrada interactiva: ruta válida | Solicita ruta amigablemente y muestra resultados con salida `0` |
| **CP-17** | RF-06 | Consola con archivo vacío | Archivo con 0 bytes | Muestra mensaje de error amigable sin `NaN`; salida `1` |
| **CP-18** | RF-04, RF-06 | Consola con 1 dato | Archivo con un único dato (`42.50`) | Muestra: "Desv. estándar: no definida"; salida `0` |
| **CP-19** | RNF-06 | Rendimiento $O(1)$ | $100\,000$ números reales insertados | Tiempo total de ejecución menor a $1\,000\text{ ms}$ |
