# **🚗 GOTY CUJAE 2D - Proyecto Unity**

## **🎮 Información del Juego**

| **Elemento** | **Detalles** |
|--------------|--------------|
| **Título** | **[POR DEFINIR]** |
| **Género** | Arcade / Infinito / Supervivencia |
| **Inspiración** | Crossy Road |
| **Objetivo** | Cruzar la avenida infinitamente hacia la CUJAE, evitando vehículos y obteniendo la máxima puntuación. |
| **Motor** | Unity 2022.3.14f1 |
| **Tipo** | 2D |
| **Plataformas** | Windows, Linux, Android |

---

## **🎯 Idea del Videojuego**

### **Concepto Principal**
Juego arcade infinito inspirado en **Crossy Road**, donde el jugador debe cruzar una avenida interminable hacia la CUJAE. Cada paso hacia adelante suma puntos, y el objetivo es alcanzar la mayor puntuación posible antes de ser atropellado.

### **Mecánicas de Juego**
- **Movimiento**: Avanzar hacia adelante, atrás y laterales (si camina hacia adelante se va generando mapa y destruyendo atras, por tanto hacia atras solo se puede mover una cantidad limitada, para adelante avanza la camara pero hacia detras no)
- **Puntuación**: +1 punto por cada paso adelante
- **Dificultad**: Los vehículos aumentan velocidad progresivamente
- **Fin del juego**: Colisión con cualquier vehículo o estar sin avansar por 5 segundos

### **Potenciadores (Power-ups)**
Los potenciadores aparecen aleatoriamente en la calle:

| **Potenciador** | **Efecto** | **Duración/Aparición** |
|-----------------|------------|-------------------------|
| **🛡️ Escudo** | Protege de un impacto | Temporal (5 segundos) |
| **🍕 Pizza Cubana** | Permite "morir" una vez (revivir) | Se consume al morir |
| **⭐ +10 Puntos** | Aumenta puntuación inmediatamente | Instantáneo |
| **⏱️ Reloj** | Ralentiza todos los vehículos | 5 segundos |
| **🌀 Agujero Negro** | Destruye todos los carros en esa calle | Instantáneo |

**Notas de diseño**:
- Los potenciadores deben ser **pocos y esporádicos**
- Aparecen en **posiciones aleatorias**
- **No deben** aparecer demasiados seguidos

---
