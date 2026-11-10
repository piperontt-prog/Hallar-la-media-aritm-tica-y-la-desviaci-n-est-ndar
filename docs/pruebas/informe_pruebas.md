# Informe de Ejecución de Pruebas (PSP0)

**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Proceso:** PSP0 · Fase de Pruebas  
**Autor:** Camilo Andrés Torres  
**Fecha:** 4 de noviembre de 2026  

---

## 1. Resumen Ejecutivo de la Fase de Pruebas

- **Total de casos diseñados:** 19 casos de prueba (CP-01 a CP-19)
- **Total de pruebas automatizadas en xUnit:** 20 pruebas unitarias
- **Primera ejecución (08:22):** 11 pruebas superadas, 9 fallidas
- **Defectos identificados y corregidos:** D6 (Fórmula de desviación), D7 (Cultura regional es-CO), D8 (Sintaxis al corregir D7), D9 (Manejo de archivo y lista vacía)
- **Ejecución final (09:35):** **20 superadas, 0 fallidas (100% de éxito)**

---

## 2. Matriz de Resultados de Ejecución

| Caso | Resultado Esperado | Obtenido (1.ª Ejecución) | Estado Inicial | Defecto Asociado | Estado Final |
|:---:|---|---|:---:|:---:|:---:|
| **CP-01** | Media: 550.60 · Desv: 572.03 | Media: 550.60 · Desv: 542.67 | ❌ Falla | **D6** | ✅ Pasa |
| **CP-02** | Media: 60.32 · Desv: 62.26 | Media: 60.32 · Desv: 59.06 | ❌ Falla | **D6** | ✅ Pasa |
| **CP-03** | Media: 638.90 · Desv: 625.63 | Media: 638.90 · Desv: 593.53 | ❌ Falla | **D6** | ✅ Pasa |
| **CP-04** | Excepción `DatosInsuficientesException` | Devuelve `NaN` sin excepción | ❌ Falla | **D9** | ✅ Pasa |
| **CP-05** | Media: 42.50 · Desviación: null | Media: 42.50 · Desviación: null | ✅ Pasa | — | ✅ Pasa |
| **CP-06** | Desviación: 0.00 | Desviación: 0.00 | ✅ Pasa | — | ✅ Pasa |
| **CP-07** | Media: 0.00 · Desv: 2.50 | Media: 0.00 · Desv: 2.04 | ❌ Falla | **D6** | ✅ Pasa |
| **CP-08** | Preserva orden [3, 1, 2] y $n=3$ | Idéntico | ✅ Pasa | — | ✅ Pasa |
| **CP-09** | [10.0, 20.0] ignorando vacías | [10.0, 20.0] | ✅ Pasa | — | ✅ Pasa |
| **CP-10** | Lanza indicando «Línea 3» | «Línea 3: «abc» no es un número...» | ✅ Pasa | — | ✅ Pasa |
| **CP-11** | Lanza `DatosInvalidosException` | No lanza excepción | ❌ Falla | **D9** | ✅ Pasa |
| **CP-12** | «No se encontró el archivo...» | Idéntico | ✅ Pasa | — | ✅ Pasa |
| **CP-13** | [15.0, 6.5] bajo cultura `es-CO` | [150.0, 65.0] (coma como miles) | ❌ Falla | **D7** | ✅ Pasa |
| **CP-14** | $n = 10$ elementos leídos de archivo | $n = 10$ | ✅ Pasa | — | ✅ Pasa |
| **CP-15** | Consola con ruta: 550.60 / 572.03, código 0 | 542.67 en desv. | ❌ Falla | **D6** | ✅ Pasa |
| **CP-16** | Consola sin args: solicita ruta, código 0 | Solicita y calcula 60.32 / 62.26 | ✅ Pasa | — | ✅ Pasa |
| **CP-16b**| Ruta en blanco: ERROR y código 1 | Idéntico | ✅ Pasa | — | ✅ Pasa |
| **CP-17** | Archivo vacío: ERROR legible, código 1 | Devuelve `NaN` y código 0 | ❌ Falla | **D9** | ✅ Pasa |
| **CP-18** | Archivo 1 dato: «no definida», código 0 | «Desv. estándar: no definida», código 0 | ✅ Pasa | — | ✅ Pasa |
| **CP-19** | 100 000 números procesados en &lt; 1 000 ms | Ejecutado en 43 ms ($&lt; 1\,000\text{ ms}$) | ✅ Pasa | — | ✅ Pasa |

---

## 3. Conclusión de la Fase de Pruebas

Todos los defectos funcionales, de datos y de validación de entradas fueron subsanados. La totalidad de los criterios de aceptación establecidos en la fase de Planeación (RF-01 a RF-07 y RNF-01 a RNF-08) han sido verificados y validados empíricamente con xUnit.
