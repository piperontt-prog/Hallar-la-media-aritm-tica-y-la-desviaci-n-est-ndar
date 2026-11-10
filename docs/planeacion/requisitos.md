# Especificación de Requisitos de Software (PSP0 - Programa 1)

**Proyecto:** Programa 1 · Media y Desviación Estándar con Lista Enlazada  
**Proceso:** PSP0 (Personal Software Process Nivel 0)  
**Autor:** Camilo Andrés Torres  
**Fecha de elaboración:** 2 de noviembre de 2026  

---

## 1. Enunciado del Problema (Assignment Kit SEI)

El objetivo del Programa 1 es desarrollar una aplicación de software que calcule la media ($\bar{x}$) y la desviación estándar muestral ($\sigma$) de un conjunto de $n$ números reales leídos secuencialmente desde un archivo de texto.

El requisito fundamental de diseño arquitectónico y de estructuras de datos exige que los números se almacenen en memoria dinámica utilizando una **lista enlazada propia**, sin recurrir a estructuras prediseñadas como `List<T>` de .NET.

### Fórmulas Matemáticas
- **Media aritmética:**
  $$\bar{x} = \frac{\sum_{i=1}^n x_i}{n}$$

- **Desviación estándar muestral:**
  $$\sigma = \sqrt{\frac{\sum_{i=1}^n (x_i - \bar{x})^2}{n - 1}}$$

---

## 2. Preguntas Previas Resueltas

| # | Pregunta | Decisión / Respuesta y Fuente |
|---|---|---|
| **P1** | ¿De dónde se leen los datos de entrada? | De un archivo de texto plano especificado por ruta. El kit no recomienda ingreso manual por teclado para garantizar reproducibilidad. |
| **P2** | ¿Qué formato tiene el archivo de entrada? | Un número real por línea con separador decimal punto (`.`). Las líneas en blanco o con espacios deben ignorarse. |
| **P3** | ¿Se puede usar `List<double>` de .NET? | **No.** El kit exige implementar y utilizar una lista enlazada propia para evaluar estructuras de datos dinámicas. |
| **P4** | ¿Cuántos decimales deben mostrarse en el reporte? | Dos decimales (`F2`), consistente con la Tabla 2 del Assignment Kit del SEI. |

> **Nota de proceso (Defecto D1):** En la versión inicial de la planeación se omitió consultar explícitamente si la desviación debía ser muestral ($n-1$) o poblacional ($n$). Esto generó una discrepancia descubierta durante la traza de escritorio en la fase de Diseño (registrada como defecto D1). Se precisó definitivamente como **desviación estándar muestral ($n-1$)**.

---

## 3. Requisitos Funcionales (RF)

| Id | Requisito Funcional | Criterio de Aceptación |
|---|---|---|
| **RF-01** | Leer $n$ números reales desde un archivo de texto plano (un número por línea). | El sistema lee correctamente los 10 valores de cada columna de prueba de la Tabla 1 del kit; omite líneas en blanco sin generar error. |
| **RF-02** | Almacenar los números leídos en una lista enlazada propia en memoria. | La clase `ListaEnlazada` almacena los elementos preservando el orden de lectura y contabiliza la cantidad exacta $n$ de nodos. |
| **RF-03** | Calcular la media aritmética de los $n$ números. | Para los datos de la Tabla 1 (Columna 1) debe obtenerse $550.60 \pm 0.01$; para la Columna 2 debe obtenerse $60.32 \pm 0.01$. |
| **RF-04** | Calcular la desviación estándar muestral ($n - 1$). | Para la Columna 1 debe obtenerse $572.03 \pm 0.01$; para la Columna 2 debe obtenerse $62.26 \pm 0.01$. Para $n < 2$ no se define desviación. |
| **RF-05** | Presentar en consola $n$, la media y la desviación estándar formateados con 2 decimales. | La salida muestra etiquetas alineadas a 14 caracteres con formato decimal invariable (punto decimal). |
| **RF-06** | Validar la integridad de los datos de entrada y emitir mensajes de error claros en español. | Ante archivo inexistente, archivo vacío, formato no numérico (indicando número de línea) o $n < 2$, se informa la causa con código de salida `1`. |
| **RF-07** | Permitir ingresar la ruta del archivo por argumento de línea de comandos o solicitarla interactivamente. | Permite `dotnet run -- datos/x.txt`; si se ejecuta sin argumentos, solicita la ruta por consola (`Console.In`). |

---

## 4. Requisitos No Funcionales (RNF)

| Id | Requisito No Funcional | Criterio de Aceptación |
|---|---|---|
| **RNF-01** | **Multiplataforma (.NET 9):** Aplicación de consola en C# ejecutable en Windows, Linux y macOS. | Compilación limpia con `dotnet build` y ejecución transparente mediante `dotnet run`. |
| **RNF-02** | **Independencia cultural / regional:** Uso estricto de punto decimal invariante. | Al ejecutarse en entornos con cultura regional hispana (ej. `es-CO` donde la coma es separador decimal), la cadena `"15.0"` se analiza como `15.0` y no como `150`. |
| **RNF-03** | **Exactitud numérica:** Precisión de punto flotante de doble precisión (`double`). | La diferencia absoluta frente a los valores teóricos del Assignment Kit debe ser $\le 0.01$. |
| **RNF-04** | **Mantenibilidad y Estándar de Codificación:** Arquitectura en capas desacopladas, métodos $\le 30$ líneas. | Separación en capas de Presentación, Aplicación, Infraestructura y Dominio; compilación con `TreatWarningsAsErrors=true`. |
| **RNF-05** | **Usabilidad en mensajes de error:** Claridad pedagógica sin trazas técnicas directas al usuario final. | Todo error de entrada inicia con `"ERROR:"` e indica la causa comprensible y la acción sugerida. |
| **RNF-06** | **Rendimiento:** Eficiencia temporal en la inserción y cálculo. | Procesamiento completo de $100\,000$ números en menos de $1\,000\text{ ms}$ gracias a inserción en cola $O(1)$ en la lista enlazada. |
| **RNF-07** | **Pruebas Automatizadas:** Cobertura de pruebas unitarias exhaustivas con xUnit. | Suite automatizada que cubre casos nominales, bordes, particiones de equivalencia y escenarios de error. |
| **RNF-08** | **Control de Versiones y Trazabilidad PSP0:** Historial de Git sincronizado con las fases PSP. | Al menos un commit por fase con la nomenclatura canónica (`planeacion:`, `diseno:`, `codigo:`, etc.). |
