# Plan de Proyecto y Estimación de Tiempo (PSP0)

**Proyecto:** Programa 1 · Media y Desviación Estándar en C#  
**Proceso:** PSP0 · Project Plan Summary Inicial  
**Fecha:** 2 de noviembre de 2026  

---

## 1. Método de Estimación

Al encontrarse en el nivel inicial **PSP0**, el ingeniero de software no cuenta todavía con una base histórica personal de tamaño y productividad (LOC/hora) para aplicar el método formal PROBE (PSP1). Por tanto, la estimación se realiza mediante la técnica de **descomposición de tareas basada en juicio de experto y analogía**.

Se divide el trabajo requerido en micro-tareas asociadas a las fases del guion de PSP0, asignando una duración en minutos a cada una y agregando un margen de contingencia del 10% para absorber la sobrecarga de registro en tiempo real de Time Log y Defect Log.

---

## 2. Desglose de Estimación por Tareas y Fases

| Fase PSP0 | Tarea Detallada | Minutos Estimados |
|---|---|:---:|
| **Planificación** | Lectura exhaustiva del kit del SEI, formulación y resolución de dudas, redacción de RF/RNF con criterios de aceptación, estimación de tiempo | 30 |
| **Diseño** | Elaboración de pseudocódigo en español estructurado, traza de escritorio con Tabla 3 del kit, diagrama de clases UML, arquitectura en capas, flujo de actividad, diseño de interfaz de consola y definición de estándar de codificación | 50 |
| **Código** | Implementación de `Nodo` y `ListaEnlazada` con inserción $O(1)$ | 25 |
| **Código** | Implementación de `CalculadoraEstadistica` (cálculo de media y desviación estándar) | 20 |
| **Código** | Implementación de `LectorArchivoNumeros` con validaciones e invariancia cultural | 25 |
| **Código** | Implementación de interfaz de consola (`ConsolaUI`) y orquestador (`Aplicacion`, `Program.cs`) | 20 |
| **Compilación** | Ciclos de compilación con `dotnet build` hasta alcanzar 0 errores y 0 advertencias, documentando los defectos en el Defect Log | 15 |
| **Pruebas** | Diseño formal de 19 casos de prueba, automatización con xUnit (20 pruebas unitarias), ejecución y resolución de defectos | 60 |
| **Post-Mortem** | Consolidación del Project Plan Summary (Plan vs Real), análisis de defectos inyectados/removidos, medición de LOC y redacción de la propuesta de mejora PIP #1 | 25 |
| **SUBTOTAL** | Suma de tareas de desarrollo directo y análisis | **270** |
| **Contingencia (10%)** | Margen para registro de métricas y adaptación al proceso PSP0 | **30** |
| **TOTAL PLANEADO** | **Tiempo total registrado en PSP Tracker antes de iniciar Diseño** | **300 min (5.0 h)** |

---

## 3. Distribución Porcentual Planeada

- **Planeación:** $10.0\%$ (30 min)
- **Diseño:** $16.7\%$ (50 min)
- **Código:** $30.0\%$ (90 min)
- **Compilación:** $5.0\%$ (15 min)
- **Pruebas:** $20.0\%$ (60 min)
- **Post-Mortem:** $8.3\%$ (25 min)
- **Contingencia:** $10.0\%$ (30 min)

> **Regla de oro de PSP0:** El tiempo planeado de **300 minutos** se fija y congela en PSP Tracker antes de dar inicio a la fase de Diseño. No se modifica durante ni después del desarrollo para garantizar la validez del análisis postmortem.
