# **🚗 GOTY CUJAE 2D - Proyecto Unity / Unity Project**

---

## **🇪🇸 Español**

### **🎮 Información del Juego**

| **Elemento** | **Detalles** |
|--------------|--------------|
| **Título** | GOTY CUJAE 2D |
| **Género** | Arcade / Infinito / Supervivencia |
| **Inspiración** | Crossy Road |
| **Objetivo** | Cruzar la avenida infinitamente hacia la CUJAE, evitando vehículos y obteniendo la máxima puntuación. |
| **Motor** | Unity 2022.3.14f1 |
| **Tipo** | 2D |
| **Plataformas** | Windows, Linux, Android |
| **Estado** | En desarrollo |

---

### **🎯 Idea del Videojuego**

#### **Concepto Principal**
Juego arcade infinito inspirado en **Crossy Road**, donde el jugador debe cruzar una avenue interminable hacia la CUJAE (Universidad de la Informática en Cuba). Cada paso hacia adelante suma puntos, y el objetivo es alcanzar la mayor puntuación posible antes de ser atropellado.

#### **Mecánicas de Juego**
- **Movimiento**: Avanzar hacia adelante, atrás y lateralmente (el mapa se genera hacia adelante y se destruye atrás)
- **Puntuación**: +1 punto por cada paso adelante basado en la posición Y del jugador
- **Dificultad progresiva**: Los vehículos aumentan su velocidad progresivamente
- **Game Over**: Colisión con cualquier vehículo o quedarse sin avanzar por 5 segundos
- **Sistema de diálogos**: Historia introductoria con diálogos antes de comenzar a jugar

#### **Controles**
- **Teclas de flecha** o **WASD**: Mover al jugador
- **Panel táctil**: Botones direccionales para dispositivos móviles
- **Ctrl + R**: Reiniciar high score (en modo depuración)

---

### **🏗️ Estructura del Proyecto**

```
GotyCujae/
├── Assets/
│   ├── Scripts/
│   │   ├── GameManager.cs         # Gestor principal del juego
│   │   ├── player_movement.cs     # Movimiento del jugador (Player)
│   │   ├── ScoreManager.cs        # Sistema de puntuación y récords
│   │   ├── car.cs                 # Comportamiento de los vehículos
│   │   ├── DialogueManager.cs     # Sistema de diálogos
│   │   ├── DialogueTrigger.cs     # Activador de diálogos
│   │   ├── menu_manager.cs        # Menú principal
│   │   ├── GameSessionManager.cs  # Gestor de sesión
│   │   ├── CamaraFollow.cs        # Cámara que sigue al jugador
│   │   ├── RoadRowSpammer.cs      # Generador de filas de camino
│   │   └── word_builder.cs        # Constructor de texto
│   ├── UI Toolkit/                # Interfaz de usuario Unity
│   └── TextMesh Pro/              # Recursos de texto
├── ProjectSettings/               # Configuración del proyecto
├── Packages/                     # Paquetes de Unity
└── README.md
```

---

### **✨ Características**

- **Sistema de puntuación** con high score guardado en PlayerPrefs
- **Sistema de diálogos** con escritura tipeada (typewriter effect)
- **Menú principal** con opciones de inicio, créditos y ajustes
- **Controles táctiles** para dispositivos móviles
- **Efectos de audio**: pasos, gritos, colisiones, música de fondo
- **Generación procedural** del mapa infinitamente
- **Sprites direccionales** del personaje según el movimiento

---

### **🚀 Cómo Ejecutar**

1. Abre el proyecto en **Unity Hub** (versión 2022.3.14f1 o superior)
2. Selecciona la escena `scene.unity` en la carpeta Assets
3. Presiona el botón **Play** en el editor de Unity
4. Para construir, ve a **File > Build Settings** y selecciona la plataforma deseada

---

### **📝 Notas de Diseño**

- Los potenciadores (power-ups) deben ser **pocos y esporádicos**
- Aparecen en **posiciones aleatorias**
- **No deben** aparecer demasiados seguidos

---

## **🇬🇧 English**

### **🎮 Game Information**

| **Element** | **Details** |
|-------------|-------------|
| **Title** | GOTY CUJAE 2D |
| **Genre** | Arcade / Infinite / Survival |
| **Inspiration** | Crossy Road |
| **Goal** | Cross the endless avenue towards CUJAE, avoiding vehicles and achieving the highest score. |
| **Engine** | Unity 2022.3.14f1 |
| **Type** | 2D |
| **Platforms** | Windows, Linux, Android |
| **Status** | In development |

---

### **🎯 Video Game Idea**

#### **Main Concept**
Infinite arcade game inspired by **Crossy Road**, where the player must cross an endless avenue towards CUJAE (University of Computer Science in Cuba). Each step forward adds points, and the goal is to achieve the highest score possible before being run over.

#### **Game Mechanics**
- **Movement**: Move forward, backward, and sideways (map generates forward and destroys behind)
- **Score**: +1 point for each step forward based on player's Y position
- **Progressive difficulty**: Vehicles progressively increase speed
- **Game Over**: Collision with any vehicle or standing still for 5 seconds
- **Dialogue system**: Introductory story with dialogues before starting to play

#### **Controls**
- **Arrow keys** or **WASD**: Move the player
- **Touch panel**: Directional buttons for mobile devices
- **Ctrl + R**: Reset high score (debug mode)

---

### **🏗️ Project Structure**

```
GotyCujae/
├── Assets/
│   ├── Scripts/
│   │   ├── GameManager.cs         # Main game manager
│   │   ├── player_movement.cs     # Player movement
│   │   ├── ScoreManager.cs        # Score and high score system
│   │   ├── car.cs                 # Vehicle behavior
│   │   ├── DialogueManager.cs     # Dialogue system
│   │   ├── DialogueTrigger.cs     # Dialogue trigger
│   │   ├── menu_manager.cs        # Main menu
│   │   ├── GameSessionManager.cs  # Session manager
│   │   ├── CamaraFollow.cs        # Camera follow
│   │   ├── RoadRowSpammer.cs      # Road row generator
│   │   └── word_builder.cs        # Text builder
│   ├── UI Toolkit/                # Unity UI
│   └── TextMesh Pro/              # Text resources
├── ProjectSettings/               # Project settings
├── Packages/                      # Unity packages
└── README.md
```

---

### **✨ Features**

- **Score system** with high score saved in PlayerPrefs
- **Dialogue system** with typewriter effect
- **Main menu** with start, credits, and settings options
- **Touch controls** for mobile devices
- **Audio effects**: steps, screams, collisions, background music
- **Procedural map generation** infinitely
- **Directional sprites** based on player movement

---

### **🚀 How to Run**

1. Open the project in **Unity Hub** (version 2022.3.14f1 or higher)
2. Select the `scene.unity` scene in the Assets folder
3. Press the **Play** button in the Unity editor
4. To build, go to **File > Build Settings** and select your desired platform

---

### **📝 Design Notes**

- Power-ups should be **few and sporadic**
- They appear in **random positions**
- They should **not** appear too many in a row

---
