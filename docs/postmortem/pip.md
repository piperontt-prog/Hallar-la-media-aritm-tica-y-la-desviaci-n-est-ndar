# Propuesta de Mejora del Proceso (PIP #1)

**Proyecto:** Programa 1 · Media y Desviación Estándar  
**Proceso:** PSP0 · Fase de Post-Mortem  
**Autor:** Camilo Andrés Torres  
**Fecha:** 4 de noviembre de 2026  

---

## 1. Justificación y Propósito

El guion de Humphrey para PSP establece que el análisis postmortem y las propuestas de mejora de procesos (Process Improvement Proposals - PIP) constituyen el mecanismo central de aprendizaje empírico del ingeniero. Las propuestas no deben ser deseos genéricos sino acciones operativas basadas en datos medidos, con metas verificables en el siguiente ciclo (Programa 2 / PSP0.1).

---

## 2. Propuestas Concretas de Mejora

| # | Problema Identificado (con Datos Medidos) | Propuesta de Acción Concreta | Cómo se Medirá en el Programa 2 (PSP0.1) |
|:---:|---|---|---|
| **1** | **Inyección excesiva en Código:**<br>El $77.8\%$ de los defectos ($7$ de $9$) se inyectaron en Código. Los defectos D6 (fórmula $n-1$), D7 (cultura invariante) y D9 (validación lista vacía) contradecían decisiones que ya estaban resueltas en el pseudocódigo y en el estándar. | • Codificar manteniendo el pseudocódigo visible en paralelo y tachar cada bloque conforme se implementa.<br>• Realizar una inspección de escritorio previa a la primera compilación contrastando el código contra las reglas E-12 (cultura invariante) y E-13 (acumuladores reales). | Defectos de tipo 70 (Datos) y 80 (Función) detectados en la fase de Pruebas $\le 1$. |
| **2** | **Costo desproporcionado de corrección en Pruebas:**<br>Reparar un defecto en Pruebas promedió $6.75\text{ min}$, frente a apenas $1.5\text{ min}$ en Compilación ($4.5$ veces más costoso). | • Redactar los casos de prueba con los datos del kit (CP-01 a CP-03) de forma previa a la codificación de la calculadora (enfoque TDD guiado).<br>• Detectar discrepancias algorítmicas de inmediato sin arrastrar errores al final del ciclo. | Tiempo total de corrección de defectos en la fase de Pruebas menor a $15\text{ minutos}$. |
| **3** | **Subestimación en fases de construcción:**<br>Las fases de Código ($+28\text{ min}$) y Pruebas ($+22\text{ min}$) absorbieron el exceso del tiempo real, llevando a un error de estimación de $+14.0\%$ ($342$ vs $300\text{ min}$). Sin la contingencia del 10% el error hubiera sido $+26.7\%$. | • En el Programa 2, ajustar la distribución de estimación asignando un peso mayor a Código ($\approx 35\%$) y Pruebas ($\approx 25\%$).<br>• Mantener una contingencia mínima del $10\%$ para registros de métricas. | Error de estimación global de tiempo acotado entre $-10\%$ y $+10\%$. |
| **4** | **Registro manual por olvido de cronómetro:**<br>Uno de los registros de tiempo de Pruebas ($27\text{ min}$) se ingresó manualmente porque se detuvo la sesión durante una llamada y se olvidó reactivar el cronómetro al regresar. | • Utilizar exclusivamente la función de **Pausar** de PSP Tracker en lugar de detener y crear una nueva sesión.<br>• Fijar una alarma o recordatorio visual en el escritorio de trabajo al retomar la actividad. | $100\%$ de los registros de tiempo capturados mediante cronómetro en tiempo real. |

---

## 3. Compromiso para el Nivel PSP0.1

Para el desarrollo del **Programa 2 (PSP0.1)**, el aprendiz incorporará el estándar formal de conteo de líneas de código (LOC), la plantilla formal de resumen de proyecto y el registro automatizado de PIPs en PSP Tracker, aplicando las 4 lecciones aprendidas aquí documentadas.
