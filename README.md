# PSP0 · Programa 1: Media y Desviación Estándar en C# (.NET 9)

[![Compilación y Pruebas](https://img.shields.io/badge/xUnit-20%2F20%20Pasando-success.svg)](#fase-5-pruebas)
[![PSP Monitor](https://img.shields.io/badge/PSP%20Monitor-100%25%20Cumplimiento-blue.svg)](#fase-6-postmortem)
[![Framework](https://img.shields.io/badge/.NET-9.0-purple.svg)](#requisitos-y-entorno)

Este repositorio contiene la **solución modelo completa, auditada y verificada del Programa 1 del Assignment Kit del Software Engineering Institute (SEI)**, implementada bajo la disciplina del **Personal Software Process Nivel 0 (PSP0)**.

---

## 📋 Resumen del Problema

El programa lee $n$ números reales desde un archivo de texto plano, los almacena en memoria dinámica utilizando una **lista enlazada simple propia** (sin utilizar `List<T>` de .NET) y calcula:
1. La **media aritmética** ($\bar{x}$):
   $$\bar{x} = \frac{\sum x_i}{n}$$
2. La **desviación estándar muestral** ($\sigma$):
   $$\sigma = \sqrt{\frac{\sum (x_i - \bar{x})^2}{n - 1}}$$

---

## 🎯 Resultados Verificados con el Assignment Kit del SEI

| Conjunto de Datos | Archivo en `datos/` | Valores ($n$) | Media Esperada | Desv. Esperada | Resultado del Programa | Estado |
|---|---|:---:|:---:|:---:|:---:|:---:|
| **Tabla 1, Columna 1 (Tamaño proxy)** | `columna1_tamano_proxy.txt` | 10 | **550.60** | **572.03** | `Media: 550.60` \| `Desv: 572.03` | ✅ Coincidencia exacta |
| **Tabla 1, Columna 2 (Horas desarrollo)** | `columna2_horas.txt` | 10 | **60.32** | **62.26** | `Media: 60.32` \| `Desv: 62.26` | ✅ Coincidencia exacta |
| **Tabla 3 (Ejemplo resuelto del Kit)** | `tabla3_ejemplo.txt` | 10 | **638.90** | **625.63** | `Media: 638.90` \| `Desv: 625.63` | ✅ Coincidencia exacta |

---

## 🏛️ Arquitectura del Sistema

La solución se estructura en **4 capas concéntricas** que aíslan el dominio del entorno de I/O y consola:

```
psp0-programa1-media-desviacion/
├── Programa1.sln
├── README.md
├── datos/                                 # Conjuntos de datos del kit y casos de prueba
│   ├── columna1_tamano_proxy.txt
│   ├── columna2_horas.txt
│   ├── tabla3_ejemplo.txt
│   ├── malo.txt, uno.txt, vacio.txt
├── docs/                                  # Evidencias documentales por fase PSP0
│   ├── flujo_psp0.svg                     # Diagrama del proceso PSP0
│   ├── planeacion/                        # requisitos.md, estimacion.md
│   ├── diseno/                            # pseudocodigo.md, diseno.md, estandar_codificacion.md
│   │   └── diagramas/                     # uml_clases.svg, arquitectura_capas.svg, flujo, interfaz
│   ├── pruebas/                           # casos_prueba.md, informe_pruebas.md, evidencias/
│   └── postmortem/                        # resumen_pps.md, pip.md
├── src/Programa1.Estadistica/
│   ├── Dominio/                           # Nodo, ListaEnlazada, CalculadoraEstadistica, etc.
│   ├── Infraestructura/                   # LectorArchivoNumeros, DatosInvalidosException
│   ├── Presentacion/                      # ConsolaUI (desacoplada con TextReader/TextWriter)
│   ├── Aplicacion.cs                      # Orquestador del caso de uso
│   └── Program.cs                         # Punto de entrada
└── tests/Programa1.Estadistica.Tests/     # 20 pruebas unitarias con xUnit
```

---

## 🚀 Guía de Ejecución

### 1. Compilación
```bash
dotnet build
```
*Configurado con `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`: 0 errores y 0 advertencias.*

### 2. Ejecución de Pruebas Unitarias (xUnit)
```bash
dotnet test
```
*Ejecuta los 19 casos de prueba documentados (20 pruebas unitarias con 100% de éxito).*

### 3. Ejecución de la Aplicación de Consola

**Modo 1: Pasando la ruta por argumento (RF-07):**
```bash
dotnet run --project src/Programa1.Estadistica -- datos/columna1_tamano_proxy.txt
```

**Modo 2: Modo interactivo por consola:**
```bash
dotnet run --project src/Programa1.Estadistica
# Solicitará: Ruta del archivo de datos: datos/columna2_horas.txt
```

---

## 📜 Trazabilidad del Historial Git (Commits por Fase PSP0)

El historial de Git audita fielmente la secuencia metodológica de PSP0:

```text
* postmortem: resumen del plan (300/342 min, +14 %), defectos por fase, LOC y PIP #1
* pruebas: corrige D6 (n-1), D7, D8 y D9; 20/20 pasan
* pruebas: diseno de 19 casos (CP-01 a CP-19) y proyecto xUnit
* compilacion: corrige D2 a D5 (CS1002, CS0103 x2, CS0266)
* codigo: implementa capas Dominio, Infraestructura, Presentacion y Aplicacion
* diseno: pseudocodigo, estandar de codificacion, UML, arquitectura, flujo e interfaz
* planeacion: requisitos RF/RNF, preguntas resueltas y estimacion (300 min)
```

---

## 📊 Métricas Consolidadas (PSP Tracker / PSP Monitor)

- **Tiempo Planeado:** 300 minutos (5.0 h)
- **Tiempo Real:** 342 minutos (5 h 42 min) — *Error de estimación: +14.0%*
- **Total Defectos:** 9 defectos registrados (36 min de reparación)
- **Tamaño:** 137 LOC (`src/`), 158 LOC (`tests/`), 295 LOC total
- **Productividad:** 24.0 LOC/h
- **Cumplimiento en PSP Monitor:** **100%**
