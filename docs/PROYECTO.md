# ExposicionVirtual — Documentación del Proyecto

**Última actualización:** 2026-06-28  
**Estado:** Stand_01 con imagen en tablero funcionando. Pendiente: replicar a los otros 4 stands.

---

## Convención de texturas por stand

Carpeta raíz: `Assets/img/{nombre_stand}/`  
Nombre de archivo: `{stand}_{componente}_{posicion}.ext`  
*(posicion solo cuando hay múltiples instancias del mismo componente)*

| Componente Unity | Nombre archivo | Ejemplo Stand_01 |
|---|---|---|
| `Cafe_Board_1` | `{stand}_board.png` | `mario/Mario_board.png` |
| `Cafe_Cabinet_1` (N instancias) | `{stand}_gabinet_{N}.jpg` | `mario/Mario_gabinet_2.jpg` |

---

## Contexto
Proyecto académico VR, semestre VI, UNAD 2026.  
Feria Virtual de Videojuegos — exposición 3D interactiva con Unity-chan como personaje jugable.  
Asset pack de mobiliario: FREE Interiors 2 (Cozy Cartoon Pack 2, Asset Store).

---

## Stack técnico
| Elemento | Valor |
|---|---|
| Motor | Unity 6000.3.14f1 |
| Target | StandaloneWindows64 |
| Lenguaje | C# 9 / netstandard2.1 |
| Input | New Input System (`UnityEngine.InputSystem`) |
| Render | URP (Universal Render Pipeline) |
| Personaje | Unity-chan (asset oficial) |
| Python | `D:\Python311\python.exe` (Pillow + cairosvg instalados) |

---

## Builder — `Assets/Editor/ExhibitionSceneBuilder.cs`

Menú Unity: **Exposicion → Construir Escenario Completo**

### Comportamiento
- Destruye el `Sala_Exposicion` existente antes de crear uno nuevo (**anti-duplicados — fix 2026-06-28**)
- Crea suelo, paredes, techo, iluminación, avatar (Unity-chan + CharacterController + PlayerMovement)
- Instancia **5 stands** con sus prefabs de mobiliario de cafetería

### Posiciones de los 5 stands
| Stand | Posición mundo | Rotación Y |
|---|---|---|
| Stand_01_Izq_Norte | (-9.5, 0, 7.0) | 90° |
| Stand_02_Izq_Centro | (-9.5, 0, 0.0) | 90° |
| Stand_03_Izq_Sur | (-9.5, 0, -7.0) | 90° |
| Stand_04_Der_Norte | (9.5, 0, 4.0) | -90° |
| Stand_05_Der_Sur | (9.5, 0, -4.0) | -90° |

### Posición del Cafe_Board_1 en cada stand (local al stand)
`new Vector3(0.0f, 2.8f, -2.23f)`, escala `Vector3.one * 2.2f`  
*(Corregido de -1.0 a -2.23 para coincidir con la alineación del panel de imagen)*

---

## Estructura de cada stand — patrón con imagen en tablero

```
Stand_0X_Nombre              ← raíz (creada por el builder)
├── Base                     ← Cube, mat color del juego
├── Cafe_Cabinet_1 (prefab)
├── Cafe_Table_1   (prefab)
├── Cafe_Board_1   (prefab)  ← tablero en (0, 2.8, -2.23), escala 2.2
│   └── [PrefabInstance override → ninguno, tablero en material original]
├── [otros prefabs según stand]
└── Panel_Imagen             ← Quad con el logo del juego
    pos local al stand: (0, 2.8, -2.18)   ← frente al tablero
    escala: (1.2, 1.5, 0.01)
    MeshFilter → Quad mesh (fileID:10210, guid:0000000000000000e000000000000000)
    MeshRenderer → material con logo PNG
```

### ¿Por qué un Quad en vez de cambiar el material del board?
El `Cafe_Board_1` tiene UVs de cafetería (menú). Cambiar su material aplica la textura pero deformada. El Quad hijo es un plano delgado posicionado justo en frente del tablero — muestra la imagen sin depender de las UVs del mesh original.

---

## Stand_01 — Super Mario Bros. (COMPLETADO)

| Propiedad | Valor |
|---|---|
| Posición mundo | (-9.5, 0, 7.0), rot Y=90° |
| Transform fileID (escena) | `1536155528` |
| Board PrefabInstance fileID | `1908521542` |
| Board Transform fileID (stripped) | `1908521543` |
| Panel GO/Tr fileID | `3006001` / `3006002` |
| Panel MeshRenderer fileID | `3006004` |
| Panel posición (local stand) | (0, 2.8, -2.18) |
| Panel escala | (1.2, 1.5, 0.01) |
| Material panel | `Assets/Exposicion/Materiales/Mat_Board_Mario.mat` |
| GUID material panel | `d1e2f3a4b5c6d1e2f3a4b5c6d1e2f301` |
| Textura tablero | `Assets/img/mario/Mario_board.png` (imagen personaje Mario) |
| GUID textura | `b619e46160cdacf42a67f3dc8fd65a6d` |

---

## Stand_05 — Steins;Gate (PARCIALMENTE CONFIGURADO)

| Propiedad | Valor |
|---|---|
| Posición mundo | (9.5, 0, -4.0), rot Y=-90° |
| Transform fileID (escena) | `978298341` |
| Board PrefabInstance fileID | `1181641352` |
| Board Transform fileID (stripped) | `1181641353` |
| Panel GO/Tr fileID | `3010001` / `3010002` |
| Material panel actual | `Mat_Img_Steins` (img_steins.png — tarjeta exhibición) |
| **Pendiente** | Conseguir logo Steins;Gate PNG y crear Mat_Board_Steins |

---

## Stands 02, 03, 04 — PENDIENTES

Estos stands serán reconstruidos por el builder con sus posiciones originales.  
Cada uno necesitará:
1. Imagen del tablero en `Assets/img/{stand}/{stand}_board.png`
2. Material `Mat_Board_{Stand}.mat` en `Assets/Exposicion/Materiales/`
3. Panel_Imagen Quad añadido al stand (mismo patrón que Stand_01)

| Stand | Juego | Textura tablero pendiente |
|---|---|---|
| Stand_02_Izq_Centro | FIFA Street | `Assets/img/fifa/Fifa_board.png` |
| Stand_03_Izq_Sur | Death Stranding | `Assets/img/death/Death_board.png` |
| Stand_04_Der_Norte | Hollow Knight | `Assets/img/hollow/Hollow_board.png` |

---

## Materiales activos

| Archivo | GUID | Uso |
|---|---|---|
| `Mat_Stand_Mario.mat` | `ee8fbdf2094f4c6fb0490ae71055cf99` | Color base Stand_01 |
| `Mat_Stand_Steins.mat` | `580c928e8db54a82b9ee22c741d33e0e` | Color base Stand_05 |
| `Mat_Board_Mario.mat` | `d1e2f3a4b5c6d1e2f3a4b5c6d1e2f301` | Panel logo Stand_01 |
| `Mat_Img_Steins.mat` | `b1c2d3e4f5a6b1c2d3e4f5a6b1c2d305` | Panel Stand_05 (provisional) |
| `Mat_LogoFeria.mat` | `321fec25ba4a856429bc543a5c078f4a` | Logo Pantalla_Principal |

---

## Pantalla Principal

`Pantalla_Principal` en pos (0, 3.2, 11.8):
- `Marco` (7.4×4.4×0.2) — borde físico
- `Superficie` (6.8×3.8×0.08) en z=-0.14

Script `PantallaPrincipalSetup.cs`: adjuntar a `Pantalla_Principal`, asignar logo, clic derecho → "Configurar Pantalla".  
Logo: `Assets/Textures/unity-game_logo.png` (GUID `9e12dab96e112ef43a63a66b784e455d`)

---

## Scripts propios

| Script | Propósito |
|---|---|
| `Assets/Scripts/PlayerMovement.cs` | CharacterController WASD, params Animator Speed+Direction |
| `Assets/Scripts/CameraFollow.cs` | Cámara tercera persona con mouse, pitch 5°-55° |
| `Assets/Scripts/PantallaPrincipalSetup.cs` | ContextMenu para título + logo en pantalla principal |
| `Assets/Scripts/StandsSetup.cs` | ContextMenu legacy — ya no necesario, cambios en escena YAML |
| `Assets/Editor/ExhibitionSceneBuilder.cs` | Menú Exposicion → Construir Escenario Completo |

---

## Reglas de edición de escena YAML (IMPORTANTE)

Al editar `Assets/Scenes/SampleScene.unity` directamente desde PowerShell:
- Usar `[System.IO.File]::ReadAllText/WriteAllText` con `.IndexOf()` + `.Replace()`
- **NO usar** `-replace` ni regex — los hooks del sistema lo bloquean
- Los saltos de línea en el archivo son **LF (`\n`)**, no CRLF — usar `` `n `` en PowerShell
- fileIDs 3001001–3010004: objetos insertados manualmente (Etiquetas y Paneles)

---

## Imágenes generadas (tarjetas de exhibición)

Script: `gen_stand_images.py` — ejecutar con `& "D:\Python311\python.exe" gen_stand_images.py`  
Salida en `Assets/Textures/Stands/` — estas son tarjetas informativas (800×600), distintas de los logos del tablero.

---

## Próximos pasos

1. Conseguir PNGs de logos para los 4 juegos restantes (FIFA Street, Death Stranding, Hollow Knight, Steins;Gate)
2. Crear materiales `Mat_Board_XXXX.mat` para cada uno
3. Añadir Panel_Imagen a Stand_05 con logo correcto
4. Integrar la creación de Paneles en el builder (`ExhibitionSceneBuilder.cs`) para que se generen automáticamente en los 5 stands al ejecutar "Construir Escenario Completo"
5. Verificar Pantalla_Principal (título + logo visibles)
