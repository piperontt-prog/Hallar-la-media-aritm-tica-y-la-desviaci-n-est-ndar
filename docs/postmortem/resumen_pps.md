# Resumen del Plan de Proyecto (PSP0 Project Plan Summary)

**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Proceso:** PSP0 (Personal Software Process Nivel 0)  
**Autor:** Camilo Andrés Torres (`camilo.torres@ejemplo.edu.co`)  
**Fecha de Cierre:** 4 de noviembre de 2026  

---

## 1. Resumen Ejecutivo de Métricas

```
┌───────────────────────────┬───────────────────────────┬───────────────────────────┬───────────────────────────┐
│     TIEMPO PLAN / REAL    │    ERROR DE ESTIMACIÓN    │   DEFECTOS / MIN REPAR.   │        LOC MEDIDOS        │
│       300 / 342 min       │          +14.0 %          │          9 · 36 min       │          137 LOC          │
│        (5h / 5h 42m)      │    (300 plan vs 342 real) │   (4 en compil., 4 en test│     (Programa src/)       │
└───────────────────────────┴───────────────────────────┴───────────────────────────┴───────────────────────────┘
```

---

## 2. Registro de Tiempos (Time Recording Log)

| # | Fecha / Inicio | Fin | Interrup. | $\Delta$ Min | Fase PSP0 | Origen | Comentarios y Tareas Realizadas |
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|---|
| **1** | 02/11 08:00 | 08:40 | 5 min | **35** | Planificación | Cronómetro | Lectura exhaustiva del kit, redacción de RF/RNF, preguntas P1-P4, estimación por tareas (300 min). |
| **2** | 02/11 08:45 | 09:55 | 8 min | **62** | Diseño | Cronómetro | Pseudocódigo, traza de escritorio con Tabla 3 (hallazgo D1), diagramas UML, arquitectura e interfaz. |
| **3** | 03/11 14:00 | 15:20 | 10 min | **70** | Código | Cronómetro | Creación de solución y proyectos; implementación del Dominio (`Nodo`, `ListaEnlazada`, `Calculadora`). |
| **4** | 03/11 15:30 | 16:20 | 2 min | **48** | Código | Cronómetro | Implementación de Infraestructura (`Lector`), Presentación (`ConsolaUI`) y Aplicación (`Aplicacion.cs`). |
| **5** | 03/11 16:25 | 16:45 | 2 min | **18** | Compilación | Cronómetro | 5 ciclos de compilación; corrección de D2 (CS1002), D3 (CS0103), D4 (CS0103) y D5 (CS0266); 0 errores. |
| **6** | 04/11 08:00 | 09:00 | 5 min | **55** | Pruebas | Cronómetro | Diseño formal de 19 casos, implementación de 20 pruebas xUnit, 1.ª ejecución (9 fallan), corrección D6-D8. |
| **7** | 04/11 09:10 | 09:37 | 0 min | **27** | Pruebas | Manual | Corrección de D9 (archivo y lista vacía); ejecución final 20/20 pasando (olvidó reanudar cronómetro). |
| **8** | 04/11 10:00 | 10:30 | 3 min | **27** | Post-Mortem | Cronómetro | Consolidación del Project Plan Summary, conteo de LOC, tablas de defectos y redacción de PIP #1. |
| **TOTAL** | — | — | **35 min** | **342 min** | **(5 h 42 min)** | — | **8 registros auditables** |

---

## 3. Registro de Defectos (Defect Recording Log)

| # | Fecha / Hora | Tipo PSP | Fase Inyectado | Fase Removido | Min Rep. | Fix Ref | Descripción del Defecto y Solución Aplicada |
|:---:|:---:|:---:|:---:|:---:|:---:|:---:|---|
| **D1** | 02/11 09:10 | **80** Función | Planificación | Diseño | 3 | — | RF-04 no indicaba si la desviación era muestral ($n-1$) o poblacional ($n$). La traza de escritorio con la Tabla 3 solo coincidió con $n-1$.<br>✔ *Solución:* Se agregó P1 y se precisó RF-04 y pseudocódigo a desviación muestral ($n-1$). |
| **D2** | 03/11 16:27 | **20** Sintaxis | Código | Compilación | 1 | — | `CS1002: ; expected` en `ListaEnlazada.cs(35)` tras `Cantidad++`.<br>✔ *Solución:* Se agregó `;`. |
| **D3** | 03/11 16:30 | **20** Sintaxis | Código | Compilación | 1 | — | `CS0103: The name 'sumaCuadradso' does not exist` en `CalculadoraEstadistica.cs(39)`.<br>✔ *Solución:* Se corrigió el nombre de variable a `sumaCuadrados`. |
| **D4** | 03/11 16:34 | **30** Construcción | Código | Compilación | 2 | — | `CS0103: The name 'CultureInfo' does not exist` en `ConsolaUI.cs(52)`.<br>✔ *Solución:* Se agregó `using System.Globalization;`. |
| **D5** | 03/11 16:39 | **40** Asignación | Código | Compilación | 2 | — | `CS0266: Cannot implicitly convert type 'double' to 'int'` en `CalculadoraEstadistica.cs(18)` acumulando con `int suma`.<br>✔ *Solución:* Se declaró `double suma = 0;` (regla E-13). |
| **D6** | 04/11 08:25 | **80** Función | Código | Pruebas | 8 | — | CP-01, 02, 03, 07 y 15 fallan: desviación calculó $542.67$ en vez de $572.03$ porque dividió entre $n$.<br>✔ *Solución:* Se corrigió el divisor a $(n - 1)$ en `CalculadoraEstadistica.DesviacionEstandar`. |
| **D7** | 04/11 08:40 | **70** Datos | Código | Pruebas | 12 | — | CP-13 falla: bajo cultura `es-CO` `"15.0"` se interpretó como $150$ porque `double.Parse` usaba la cultura del equipo.<br>✔ *Solución:* Se implementó `double.TryParse(..., NumberStyles.Float, CultureInfo.InvariantCulture, ...)`. |
| **D8** | 04/11 08:52 | **20** Sintaxis | Pruebas | Pruebas | 1 | **D7** | `CS1003: Syntax error, ',' expected` en `LectorArchivoNumeros.cs` al corregir D7.<br>✔ *Solución:* Se colocó la coma faltante entre argumentos. |
| **D9** | 04/11 09:15 | **60** Chequeo | Código | Pruebas | 6 | — | CP-04, 11 y 17 fallan: archivo vacío mostraba `Media: NaN` con código 0 en vez de error controlado.<br>✔ *Solución:* Se agregó validación de `lista.EstaVacia` en `LectorArchivoNumeros` y `CalculadoraEstadistica.Media`. |
| **TOTAL** | — | — | — | — | **36 min** | — | **9 defectos registrados y subsanados** |

---

## 4. Distribución de Tiempos y Defectos por Fase

| Fase PSP0 | Tiempo Plan (min) | Tiempo Real (min) | % Tiempo Real | Defectos Inyectados | % Inyectados | Defectos Eliminados | % Eliminados |
|---|:---:|:---:|:---:|:---:|:---:|:---:|:---:|
| **Planificación** | 30 | 35 | 10.2 % | 1 | 11.1 % | 0 | 0.0 % |
| **Diseño** | 50 | 62 | 18.1 % | 0 | 0.0 % | 1 | 11.1 % |
| **Código** | 90 | 118 | 34.5 % | 7 | 77.8 % | 0 | 0.0 % |
| **Compilación** | 15 | 18 | 5.3 % | 0 | 0.0 % | 4 | 44.4 % |
| **Pruebas** | 60 | 82 | 24.0 % | 1 | 11.1 % | 4 | 44.4 % |
| **Post-Mortem** | 25 | 27 | 7.9 % | 0 | 0.0 % | 0 | 0.0 % |
| **Contingencia** | 30 | — | — | — | — | — | — |
| **TOTAL** | **300** | **342** | **100.0 %** | **9** | **100.0 %** | **9** | **100.0 %** |

---

## 5. Medición de Tamaño (LOC) y Productividad

- **Criterio de conteo de líneas de código:** Líneas físicas de código C# excluyendo líneas en blanco, llaves solas y comentarios (`//`, `///`).

| Componente | Archivos | Líneas Físicas Efectivas (LOC) |
|---|:---:|:---:|
| Código de producción (`src/Programa1.Estadistica/`) | 10 | 137 |
| Suite de pruebas unitarias (`tests/Programa1.Estadistica.Tests/`) | 5 | 158 |
| **TOTAL CÓDIGO NUEVO** | **15** | **295 LOC** |

### Métricas de Rendimiento del Proceso:
- **Productividad:** $\frac{137\text{ LOC}}{5.7\text{ horas}} = \mathbf{24.0\text{ LOC / hora}}$
- **Densidad de Defectos:** $\frac{9\text{ defectos}}{0.137\text{ KLOC}} = \mathbf{65.7\text{ defectos / KLOC}}$
- **Yield de Fase:** $\frac{1}{8} = \mathbf{12.5\%}$ de defectos removidos antes de compilar.
- **Costo medio de corrección por fase:**
  - En Compilación: $\frac{6\text{ min}}{4\text{ defectos}} = \mathbf{1.5\text{ min/defecto}}$
  - En Pruebas: $\frac{27\text{ min}}{4\text{ defectos}} = \mathbf{6.75\text{ min/defecto}}$ (4.5 veces más costoso corregir en pruebas que en compilación).
