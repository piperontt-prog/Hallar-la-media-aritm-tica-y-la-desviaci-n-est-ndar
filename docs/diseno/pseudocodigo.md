# Pseudocódigo y Traza de Escritorio (PSP0 - Programa 1)

**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Proceso:** PSP0 · Fase de Diseño (DLD)  
**Fecha:** 2 de noviembre de 2026  

---

## 1. Pseudocódigo en Español Estructurado

### 1.1 Estructura de Datos: Nodo y Lista Enlazada

```text
CLASE Nodo
    ATRIBUTOS:
        Valor: real
        Siguiente: Nodo (nulo por defecto)
    
    CONSTRUCTOR(val: real)
        Valor ← val
        Siguiente ← NULO
FIN CLASE

CLASE ListaEnlazada
    ATRIBUTOS PRIVADOS:
        _primero: Nodo (inicialmente NULO)
        _ultimo: Nodo (inicialmente NULO)
    
    PROPIEDADES PÚBLICAS:
        Cantidad: entero (inicialmente 0)
        EstaVacia: booleano (Cantidad == 0)

    MÉTODO Agregar(val: real) : vacio
        nuevoNodo ← NUEVO Nodo(val)
        SI _ultimo ES NULO ENTONCES
            _primero ← nuevoNodo
        SINO
            _ultimo.Siguiente ← nuevoNodo
        FIN SI
        _ultimo ← nuevoNodo
        Cantidad ← Cantidad + 1
    FIN MÉTODO

    MÉTODO Recorrer() : iterador de reales
        actual ← _primero
        MIENTRAS actual NO SEA NULO HACER
            RETORNAR valor actual.Valor
            actual ← actual.Siguiente
        FIN MIENTRAS
    FIN MÉTODO
FIN CLASE
```

---

### 1.2 Lógica de Negocio: Calculadora Estadística

```text
MÓDULO CalculadoraEstadistica

    CONSTANTE MinimoParaDesviacion = 2

    FUNCIÓN Media(datos: ListaEnlazada) : real
        SI datos ES NULO ENTONCES
            LANZAR ArgumentNullException("Los datos no pueden ser nulos")
        FIN SI
        SI datos.EstaVacia ENTONCES
            LANZAR DatosInsuficientesException("Se necesita al menos 1 dato para calcular la media.")
        FIN SI

        suma ← 0.0                      // Acumulador real de doble precisión (double)
        PARA CADA x EN datos HACER
            suma ← suma + x
        FIN PARA CADA

        RETORNAR suma / datos.Cantidad
    FIN FUNCIÓN

    FUNCIÓN DesviacionEstandar(datos: ListaEnlazada) : real
        SI datos ES NULO ENTONCES
            LANZAR ArgumentNullException("Los datos no pueden ser nulos")
        FIN SI
        SI datos.Cantidad < MinimoParaDesviacion ENTONCES
            LANZAR DatosInsuficientesException("Se necesitan al menos 2 datos para calcular la desviación estándar.")
        FIN SI

        media ← Media(datos)
        sumaCuadrados ← 0.0             // Acumulador real
        PARA CADA x EN datos HACER
            diferencia ← x - media
            sumaCuadrados ← sumaCuadrados + (diferencia * diferencia)
        FIN PARA CADA

        // FÓRMULA MUESTRAL (n - 1)
        varianzaMuestral ← sumaCuadrados / (datos.Cantidad - 1)
        RETORNAR RAIZ_CUADRADA(varianzaMuestral)
    FIN FUNCIÓN

    ESTRUCTURA ResultadoEstadistico
        Cantidad: entero
        Media: real
        DesviacionEstandar: real opcional (nulo si n < 2)
    FIN ESTRUCTURA

    FUNCIÓN Calcular(datos: ListaEnlazada) : ResultadoEstadistico
        med ← Media(datos)
        desv ← NULO
        SI datos.Cantidad >= MinimoParaDesviacion ENTONCES
            desv ← DesviacionEstandar(datos)
        FIN SI
        RETORNAR NUEVO ResultadoEstadistico(datos.Cantidad, med, desv)
    FIN FUNCIÓN

FIN MÓDULO
```

---

### 1.3 Infraestructura: Lector de Archivos

```text
MÓDULO LectorArchivoNumeros

    FUNCIÓN Leer(ruta: texto) : ListaEnlazada
        SI NO EXISTE_ARCHIVO(ruta) ENTONCES
            LANZAR DatosInvalidosException("No se encontró el archivo: " + ruta, 0)
        FIN SI
        lineas ← LEER_LINEAS_DE_ARCHIVO(ruta)
        RETORNAR LeerLineas(lineas)
    FIN FUNCIÓN

    FUNCIÓN LeerLineas(lineas: secuencia de textos) : ListaEnlazada
        lista ← NUEVA ListaEnlazada()
        numeroLinea ← 0

        PARA CADA linea EN lineas HACER
            numeroLinea ← numeroLinea + 1
            lineaLimpia ← RECORTAR_ESPACIOS(linea)
            SI lineaLimpia NO ESTÁ VACÍA ENTONCES
                valor ← Convertir(lineaLimpia, numeroLinea)
                lista.Agregar(valor)
            FIN SI
        FIN PARA CADA

        SI lista.EstaVacia ENTONCES
            LANZAR DatosInvalidosException("El archivo no contiene datos numéricos válidos.", 0)
        FIN SI

        RETORNAR lista
    FIN FUNCIÓN

    FUNCIÓN Convertir(texto: texto, numeroLinea: entero) : real
        // Siempre usar formato numérico invariable (punto decimal)
        SI INTENTAR_CONVERTIR_REAL_INVARIANTE(texto, valor) Y ES_FINITO(valor) ENTONCES
            RETORNAR valor
        SINO
            LANZAR DatosInvalidosException(
                "Línea " + numeroLinea + ": «" + texto + "» no es un número real. Use punto decimal (ej. 15.0).",
                numeroLinea)
        FIN SI
    FIN FUNCIÓN

FIN MÓDULO
```

---

### 1.4 Orquestación y Aplicación

```text
MÓDULO Aplicacion
    CONSTANTE Exito = 0
    CONSTANTE ErrorDatos = 1

    FUNCIÓN Ejecutar(argumentos: lista de textos, entrada: LectorTexto, salida: EscritorTexto) : entero
        ui ← NUEVA ConsolaUI(entrada, salida)
        ui.MostrarEncabezado()

        ruta ← ""
        SI LONGITUD(argumentos) > 0 ENTONCES
            ruta ← argumentos[0]
        SINO
            ruta ← ui.PedirRuta()
        FIN SI

        INTENTAR
            datos ← LectorArchivoNumeros.Leer(ruta)
            resultado ← CalculadoraEstadistica.Calcular(datos)
            ui.MostrarResultado(ruta, resultado)
            RETORNAR Exito
        CAPTURAR DatosInvalidosException O DatosInsuficientesException COMO ex
            ui.MostrarError(ex.Mensaje)
            RETORNAR ErrorDatos
        FIN INTENTAR
    FIN FUNCIÓN
FIN MÓDULO
```

---

## 2. Traza de Escritorio (Datos de la Tabla 3 del SEI Kit)

### 2.1 Datos de Entrada
Conjunto de prueba del SEI (Tabla 3, ejemplo resuelto):  
`186, 699, 132, 272, 291, 331, 199, 1890, 788, 1601` ($n = 10$).

### 2.2 Ejecución de Cálculos Paso a Paso

| $i$ | $x_i$ | $\sum x$ parcial | $(x_i - \bar{x})$ | $(x_i - \bar{x})^2$ | $\sum (x_i - \bar{x})^2$ parcial |
|:---:|:---:|:---:|:---:|:---:|:---:|
| 1 | 186 | 186 | $-452.9$ | $205\,118.41$ | $205\,118.41$ |
| 2 | 699 | 885 | $+60.1$ | $3\,612.01$ | $208\,730.42$ |
| 3 | 132 | 1017 | $-506.9$ | $256\,947.61$ | $465\,678.03$ |
| 4 | 272 | 1289 | $-366.9$ | $134\,615.61$ | $600\,293.64$ |
| 5 | 291 | 1580 | $-347.9$ | $121\,034.41$ | $721\,328.05$ |
| 6 | 331 | 1911 | $-307.9$ | $94\,802.41$ | $816\,130.46$ |
| 7 | 199 | 2110 | $-439.9$ | $193\,512.01$ | $1\,009\,642.47$ |
| 8 | 1890 | 4000 | $+1251.1$ | $1\,565\,251.21$ | $2\,574\,893.68$ |
| 9 | 788 | 4788 | $+149.1$ | $22\,230.81$ | $2\,597\,124.49$ |
| 10 | 1601 | **6389** | $+962.1$ | $925\,636.41$ | **$3\,522\,760.90$** |

### 2.3 Comparación de Fórmulas y Descubrimiento del Defecto D1

1. **Cálculo de la Media:**
   $$\bar{x} = \frac{6389}{10} = \mathbf{638.90} \quad \text{(Coincide con el kit)}$$

2. **Ensayo de Desviación Estándar Poblacional ($n$):**
   $$\sigma_{\text{pob}} = \sqrt{\frac{3\,522\,760.90}{10}} = \sqrt{352\,276.09} = \mathbf{593.528}$$
   *Discrepancia:* El valor esperado reportado por el SEI Assignment Kit es **$625.633981$**.

3. **Ensayo de Desviación Estándar Muestral ($n - 1$):**
   $$\sigma_{\text{muestral}} = \sqrt{\frac{3\,522\,760.90}{10 - 1}} = \sqrt{\frac{3\,522\,760.90}{9}} = \sqrt{391\,417.8778} = \mathbf{625.633981}$$
   *Conclusión:* La fórmula correcta es la desviación muestral ($n - 1$).

### 2.4 Registro del Defecto D1 en PSP Tracker

- **Número de Defecto:** 1
- **Fecha y Hora:** 02/11/2026 09:10
- **Tipo de Defecto:** 80 Función (Lógica / Requisitos)
- **Fase de Inyección:** Planificación (RF-04 no especificaba si la fórmula era muestral o poblacional)
- **Fase de Eliminación:** Diseño (Detectado durante la traza de escritorio)
- **Tiempo de Corrección:** 3 minutos
- **Descripción:** RF-04 no indicaba si la desviación es muestral ($n-1$) o poblacional ($n$). La traza de escritorio con los datos de la Tabla 3 reveló que el resultado solo coincide con $n-1$.
- **Solución implementada:** Se actualizó la pregunta P1 y se precisó formalmente el requisito funcional RF-04 y el pseudocódigo para utilizar estrictamente el divisor $(n - 1)$.
