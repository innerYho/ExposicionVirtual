# Feria Virtual de Videojuegos

Proyecto de exposición virtual desarrollado en **Unity 6000.3.14f1** con URP (Universal Render Pipeline) para la asignatura de Realidad Virtual — UNAD Semestre VI 2026.

El jugador controla un avatar (Unity-chan) que recorre una sala con 5 stands de videojuegos y una pantalla principal.

---

## Requisitos

- Unity **6000.3.14f1** (o superior compatible)
- Universal Render Pipeline (incluido en `Packages/manifest.json`)
- Input System package (incluido en `Packages/manifest.json`)

---

## Assets de terceros — instalación obligatoria

Estos paquetes **no están incluidos** en el repositorio por su tamaño. Deben importarse manualmente desde Unity Asset Store antes de abrir la escena.

### 1. Unity-chan! Model

Personaje principal del proyecto (avatar, animaciones, scripts de expresión facial).

- **Asset Store:** https://assetstore.unity.com/packages/3d/characters/unity-chan-model-18705
- **Carpeta destino:** `Assets/unity-chan!/`

**Pasos:**
1. Abrir Unity Asset Store en el Editor: `Window > Asset Store`
2. Buscar **"Unity-chan! Model"** (autor: Unity Technologies Japan)
3. Descargar e importar al proyecto
4. Verificar que la carpeta `Assets/unity-chan!/Unity-chan! Model/` existe

### 2. FREE Interiors — Mnostva Art

Props y mobiliario de los stands (gabinetes, tableros, plantas, señalética de café).

- **Asset Store:** https://assetstore.unity.com/packages/3d/environments/free-interiors-pack-118045
- **Carpeta destino:** `Assets/Mnostva Art/`

**Pasos:**
1. Abrir Unity Asset Store en el Editor: `Window > Asset Store`
2. Buscar **"FREE Interiors Pack"** (autor: Mnostva Art)
3. Descargar e importar al proyecto
4. Verificar que la carpeta `Assets/Mnostva Art/FREE_Interiors_2/` existe

---

## Cómo abrir el proyecto

```
1. Clonar el repositorio
   git clone <url-del-repo>

2. Importar los dos paquetes de Asset Store (ver sección anterior)

3. Abrir Unity Hub → Add → seleccionar la carpeta clonada

4. Abrir la escena: Assets/Scenes/SampleScene.unity

5. (Opcional) Reconstruir la sala:
   Editor menu → Exposicion → Construir Escenario Completo
```

---

## Estructura del proyecto

```
Assets/
├── Exposicion/
│   └── Materiales/       # Materiales de paneles y pantalla principal
├── Editor/
│   └── ExhibitionSceneBuilder.cs   # Builder de la sala (menú Unity)
├── img/                  # Imágenes de los stands y pantalla principal
│   ├── mario/
│   ├── Hollow Knight/
│   ├── Death Starding/
│   ├── Fifa Street 2/
│   ├── Steins;Gate/
│   ├── titulo_feria.png
│   └── Official_unity_logo.png
├── Scenes/
│   └── SampleScene.unity
├── Scripts/
│   ├── PlayerMovement.cs   # Movimiento del avatar (WASD + flechas)
│   └── CameraFollow.cs     # Cámara orbital con mouse
└── Settings/               # Configuración URP
docs/
├── COORDENADAS.md    # Posiciones y GUIDs de todos los paneles
└── BACKUP_ESCENA.md  # Backup completo de la escena para recuperación
```

---

## Controles

| Tecla | Acción |
|---|---|
| W / Flecha arriba | Avanzar |
| S / Flecha abajo | Retroceder |
| A / Flecha izquierda | Moverse a la izquierda |
| D / Flecha derecha | Moverse a la derecha |
| Mouse | Rotar cámara |
| Escape | Liberar cursor |

---

## Stands de la exposición

| Stand | Juego |
|---|---|
| Stand_01 | Super Mario Bros. |
| Stand_02 | Hollow Knight |
| Stand_03 | Death Stranding |
| Stand_04 | FIFA Street 2 |
| Stand_05 | Steins;Gate |
