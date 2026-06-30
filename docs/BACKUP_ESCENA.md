# Backup de Coordenadas — Escena Completa

Fuente de verdad para recuperar el escenario si el builder falla o se pierden datos.  
Todas las posiciones de prefabs son **locales al stand**. Las de paneles son **locales a su padre**.

> Ver también: `README.md` en la raíz del proyecto para instrucciones de clonación e instalación de paquetes.

---

## Stands — posición y rotación mundo

| Stand | Posición mundo | Rotación Y |
|---|---|---|
| Stand_01_Izq_Norte | (-9.5, 0, 7.0) | 90° |
| Stand_02_Izq_Centro | (-9.5, 0, 0.0) | 90° |
| Stand_03_Izq_Sur | (-9.5, 0, -6.860002) | 90° |
| Stand_04_Der_Norte | (9.5, 0, 4.0) | -90° |
| Stand_05_Der_Sur | (9.5, 0, -4.0) | -90° |

Base de cada stand: `Cube` pos `(0, 0.10, 0)` escala `(4.0, 0.20, 2.5)`

---

## Stand_01 — Super Mario Bros.

| Nombre en escena | Prefab | localPosition | localScale |
|---|---|---|---|
| Mario_Cabinet | `Cafe_Cabinet_1.prefab` | (0.0, 0.2, -0.6) | 1.4 |
| Cafe_Board_1 | `Cafe_Board_1.prefab` | (0.0, 5.28, -2.23) | 2.2 |
| Cafe_Plant_1 | `Cafe_Plant_1.prefab` | (1.6, 0.2, 0.4) | 1.0 |

### Paneles Stand_01

| Panel | Parent (prefab) | localPosition | localScale | rotY | Material |
|---|---|---|---|---|---|
| Panel_Mario_Gabinet_1 | Mario_Cabinet (`Cafe_Cabinet_1`) | (0.86, 0.42271432, 0.273) | (0.55413014, 0.50551015, 0.019314783) | -180.641° | Mat_Mario_Gabinet_1 |
| Panel_Mario_Gabinet_2 | Mario_Cabinet (`Cafe_Cabinet_1`) | (-0.003, 0.42, 0.277) | (0.55413014, 0.50551015, 0.019314783) | -180.889° | Mat_Mario_Gabinet_2 |
| Panel_Mario_Gabinet_3 | Mario_Cabinet (`Cafe_Cabinet_1`) | (-0.863, 0.413, 0.273) | (0.55413, 0.50551015, 0.019314779) | -181.157° | Mat_Mario_Gabinet_3 |
| Panel_Mario_Board | Cafe_Board_1 (`Cafe_Board_1`) | (0.0268183, -0.625, 0.1572727) | (1.4569246, 0.891715, 0.021231668) | 183.462° | Mat_Board_Mario |

### Materiales Stand_01

| Material | Textura | GUID textura |
|---|---|---|
| Mat_Mario_Gabinet_1.mat | `img/mario/Mario_gabinet_1.jpg` | `b61bc493a8e95274ab4cc7408934c0fd` |
| Mat_Mario_Gabinet_2.mat | `img/mario/Mario_gabinet_2.jpg` | `2c3d4e5f6a7b2c3d4e5f6a7b2c3d4e5f` |
| Mat_Mario_Gabinet_3.mat | `img/mario/Mario_gabinet_3.jpg` | `34f386cbff5743f49b2a1bb47019a021` |
| Mat_Board_Mario.mat | `img/mario/Super_Mario_logo.png` | `f1f0bfee9b9b1f340bf934b75c6f699e` |

---

## Stand_02 — Hollow Knight

| Nombre en escena | Prefab | localPosition | localScale |
|---|---|---|---|
| Hollow_Cabinet | `Cafe_Cabinet_1.prefab` | (0.0, 0.2, -0.6) | 1.4 |
| Hollow_Board | `Cafe_Board_1.prefab` | (0.0, 5.39, -2.23) | 2.2 |

### Paneles Stand_02

| Panel | Parent (prefab) | localPosition | localScale | rotY | Material |
|---|---|---|---|---|---|
| Panel_Hollow_Gabinet_1 | Hollow_Cabinet (`Cafe_Cabinet_1`) | (0.86, 0.42271432, 0.273) | (0.55413014, 0.50551015, 0.019314783) | -180.641° | Mat_Hollow_Gabinet_1 |
| Panel_Hollow_Gabinet_2 | Hollow_Cabinet (`Cafe_Cabinet_1`) | (-0.003, 0.42, 0.277) | (0.55413014, 0.50551015, 0.019314783) | -180.889° | Mat_Hollow_Gabinet_2 |
| Panel_Hollow_Gabinet_3 | Hollow_Cabinet (`Cafe_Cabinet_1`) | (-0.863, 0.413, 0.273) | (0.55413, 0.50551015, 0.019314779) | -181.157° | Mat_Hollow_Gabinet_3 |
| Panel_Hollow_Board | Hollow_Board (`Cafe_Board_1`) | (0.0268183, -0.625, 0.1572727) | (1.4569246, 0.891715, 0.021231668) | 183.462° | Mat_Board_Hollow |

### Materiales Stand_02

| Material | Textura | GUID textura |
|---|---|---|
| Mat_Hollow_Gabinet_1.mat | `img/Hollow Knight/HollowKnigh1.jpg` | `bf7370515696fce44a190c79e256242e` |
| Mat_Hollow_Gabinet_2.mat | `img/Hollow Knight/HollowKnigth2.jpeg` | `b9215481249593a448ac616b05063eca` |
| Mat_Hollow_Gabinet_3.mat | `img/Hollow Knight/HollowKniight3.jpeg` | `241736beff5d91b4a8a4af53e662bf9c` |
| Mat_Board_Hollow.mat | `img/Hollow Knight/hollow-knight-title.png` | `730602d0428d7684996f1a4e9ee13787` |

---

## Stand_03 — Death Stranding

| Nombre en escena | Prefab | localPosition | localScale |
|---|---|---|---|
| Death_Cabinet | `Cafe_Cabinet_1.prefab` | (0.0, 0.2, -0.6) | 1.4 |
| Cafe_Coffee_Bean_Sign_1 | `Cafe_Coffee_Bean_Sign_1.prefab` | (0.0, 2.8, -1.0) | 2.0 |
| Death_Board | `Cafe_Board_1.prefab` | (0.0, 5.39, -2.23) | 2.2 |

### Paneles Stand_03

| Panel | Parent (prefab) | localPosition | localScale | rotY | Material |
|---|---|---|---|---|---|
| Panel_Death_Gabinet_1 | Death_Cabinet (`Cafe_Cabinet_1`) | (0.86, 0.42271432, 0.273) | (0.55413014, 0.50551015, 0.019314783) | -180.641° | Mat_Death_Gabinet_1 |
| Panel_Death_Gabinet_2 | Death_Cabinet (`Cafe_Cabinet_1`) | (-0.003, 0.42, 0.277) | (0.55413014, 0.50551015, 0.019314783) | -180.889° | Mat_Death_Gabinet_2 |
| Panel_Death_Gabinet_3 | Death_Cabinet (`Cafe_Cabinet_1`) | (-0.863, 0.413, 0.273) | (0.55413, 0.50551015, 0.019314779) | -181.157° | Mat_Death_Gabinet_3 |
| Panel_Death_Board | Death_Board (`Cafe_Board_1`) | (0.0268183, -0.625, 0.1572727) | (1.4569246, 0.891715, 0.021231668) | 183.462° | Mat_Board_Death |

### Materiales Stand_03

| Material | Textura | GUID textura |
|---|---|---|
| Mat_Death_Gabinet_1.mat | `img/Death Starding/Death1.jpg` | `6223db80238e3314580c46bd1a5a50bf` |
| Mat_Death_Gabinet_2.mat | `img/Death Starding/Death2.jpeg` | `38d176cce840e51458c9bf03b12a9e7c` |
| Mat_Death_Gabinet_3.mat | `img/Death Starding/Death3.jpeg` | `bfb5b04e3b0a62b4081714125eff562a` |
| Mat_Board_Death.mat | `img/Death Starding/deathTitulo.png` | `93259d2297016234f892507c3f5d2d61` |

---

## Stand_04 — FIFA Street 2

| Nombre en escena | Prefab | localPosition | localScale |
|---|---|---|---|
| Fifa_Cabinet | `Cafe_Cabinet_1.prefab` | (0.0, 0.2, -0.6) | 1.4 |
| Fifa_Board | `Cafe_Board_1.prefab` | (0.0, 5.39, -2.23) | 2.2 |

### Paneles Stand_04

| Panel | Parent (prefab) | localPosition | localScale | rotY | Material |
|---|---|---|---|---|---|
| Panel_Fifa_Gabinet_1 | Fifa_Cabinet (`Cafe_Cabinet_1`) | (0.86, 0.42271432, 0.273) | (0.55413014, 0.50551015, 0.019314783) | -180.641° | Mat_Fifa_Gabinet_1 |
| Panel_Fifa_Gabinet_2 | Fifa_Cabinet (`Cafe_Cabinet_1`) | (-0.003, 0.42, 0.277) | (0.55413014, 0.50551015, 0.019314783) | -180.889° | Mat_Fifa_Gabinet_2 |
| Panel_Fifa_Gabinet_3 | Fifa_Cabinet (`Cafe_Cabinet_1`) | (-0.863, 0.413, 0.273) | (0.55413, 0.50551015, 0.019314779) | -181.157° | Mat_Fifa_Gabinet_3 |
| Panel_Fifa_Board | Fifa_Board (`Cafe_Board_1`) | (0.0268183, -0.625, 0.1572727) | (1.4569246, 0.891715, 0.021231668) | 183.462° | Mat_Board_Fifa |

### Materiales Stand_04

| Material | Textura | GUID textura |
|---|---|---|
| Mat_Fifa_Gabinet_1.mat | `img/Fifa Street 2/Fifa1.jpeg` | `5c7cebc0f2daa5643829f91558297aad` |
| Mat_Fifa_Gabinet_2.mat | `img/Fifa Street 2/Fifa2.jpeg` | `fe522296e34822549a11fdccc57d08aa` |
| Mat_Fifa_Gabinet_3.mat | `img/Fifa Street 2/Fifa3.jpeg` | `8aa9e9fa09e8361469c3f1c6aead1f78` |
| Mat_Board_Fifa.mat | `img/Fifa Street 2/fifaTitulo2.png` | `938127e4f78c8b842a1336142aefbb56` |

---

## Stand_05 — Steins;Gate

| Nombre en escena | Prefab | localPosition | localScale |
|---|---|---|---|
| Stain_Cabinet | `Cafe_Cabinet_1.prefab` | (0.0, 0.2, -0.6) | 1.4 |
| Stain_Board | `Cafe_Board_1.prefab` | (0.0, 5.39, -2.23) | 2.2 |

### Paneles Stand_05

| Panel | Parent (prefab) | localPosition | localScale | rotY | Material |
|---|---|---|---|---|---|
| Panel_Stain_Gabinet_1 | Stain_Cabinet (`Cafe_Cabinet_1`) | (0.86, 0.42271432, 0.273) | (0.55413014, 0.50551015, 0.019314783) | -180.641° | Mat_Stain_Gabinet_1 |
| Panel_Stain_Gabinet_2 | Stain_Cabinet (`Cafe_Cabinet_1`) | (-0.003, 0.42, 0.277) | (0.55413014, 0.50551015, 0.019314783) | -180.889° | Mat_Stain_Gabinet_2 |
| Panel_Stain_Gabinet_3 | Stain_Cabinet (`Cafe_Cabinet_1`) | (-0.863, 0.413, 0.273) | (0.55413, 0.50551015, 0.019314779) | -181.157° | Mat_Stain_Gabinet_3 |
| Panel_Stain_Board | Stain_Board (`Cafe_Board_1`) | (0.0268183, -0.625, 0.1572727) | (1.4569246, 0.891715, 0.021231668) | 183.462° | Mat_Board_Stain |

### Materiales Stand_05

| Material | Textura | GUID textura |
|---|---|---|
| Mat_Stain_Gabinet_1.mat | `img/Steins;Gate/StainsGate1.png` | `315d63d2fbf0ee748ac550703ee49ce3` |
| Mat_Stain_Gabinet_2.mat | `img/Steins;Gate/SteinsGate2.jpg` | `7c8315e49d8c1d74d88a7a6dd677e688` |
| Mat_Stain_Gabinet_3.mat | `img/Steins;Gate/SteinsGate3.jpg` | `12130b1e9aceabb4a94fcf0c3d61a619` |
| Mat_Board_Stain.mat | `img/Hollow Knight/steins-gateTitulo.png` | `56139c01562d6474fb3dec7b975e5097` |

---

## Pantalla_Principal — Superficie frontal

Objeto raíz en escena: `Pantalla_Principal` (fileID `2026015857`, Transform `2026015858`)  
Posición mundo: **(0, 3.2, 11.8)** sin rotación  
Hijos directos de Transform `2026015858`: Marco (`1119719454`), Superficie (`1468412786`), Panel_Logo_Feria (`8100002`), Panel_Titulo_Feria (`8200002`)

### Quads montados sobre Superficie

| GameObject | localPosition (relativa a Pantalla_Principal) | localScale | Material | Textura |
|---|---|---|---|---|
| Panel_Logo_Feria | (0, -0.3, -0.21) | (2.6, 2.6, 0.01) | Mat_Logo_Feria | `img/Official_unity_logo.png` |
| Panel_Titulo_Feria | (0, 1.3, -0.21) | (6.0, 1.0, 0.01) | Mat_Titulo_Feria | `img/titulo_feria.png` |

### Materiales Pantalla_Principal

| Material | GUID mat | Textura | GUID textura | Shader | Surface |
|---|---|---|---|---|---|
| Mat_Logo_Feria.mat | `a8b9c0d1e2f3a4b5c6d7e8f9a0b1c2d3` | `img/Official_unity_logo.png` | `b75113171aabb9d4db362b04ab654ad2` | URP Lit | Transparent |
| Mat_Titulo_Feria.mat | `b9c0d1e2f3a4b5c6d7e8f9a0b1c2d3e4` | `img/titulo_feria.png` | `8e1f8e167d7fc754db7d789691a55267` | URP Lit | Transparent |

`titulo_feria.png` — 1920×320 RGBA, texto "Feria Virtual de Videojuegos" en Agency Bold 148pt, dorado (255,215,0) sobre fondo transparente. Script Python en scratchpad si necesita regenerarse.

---

## Personaje — UnityChan_Visual

| Propiedad | Valor |
|---|---|
| Prefab fuente | `unitychan.prefab` (GUID: `412b92d4feeb9c548bfa98f62c4d1022`) |
| GameObject en escena | `UnityChan_Visual` — hijo del objeto jugador |
| Animator fileID en prefab | `9500000` |
| Controller por defecto (prefab) | `UnityChanARPose.controller` — GUID `3173dc991e314594abd6180b45c49c92` (**brazos levantados, NO usar**) |
| Controller correcto (override en escena) | `UnityChanLocomotions.controller` — GUID `8d5a0e0d58f4e4176a844a1a03976c19` |
| Parámetros Animator | `Speed` (float, 0=idle / ≥0.8=run) · `Direction` (float, -1=izq / 0=adelante / 1=der) |
| Script que los alimenta | `Assets/Scripts/PlayerMovement.cs` — `SetFloat("Speed", direccion.magnitude)` + `SetFloat("Direction", h)` |

**Override aplicado en SampleScene.unity a DOS instancias** (ambas dentro de `m_Modifications`):

| PrefabInstance | Rol | fileID padre |
|---|---|---|
| `392336086` | UnityChan decorativa (solo visual) | `225398708` |
| `921667375` | UnityChan del jugador (la que camina) | `1208025580` |

```yaml
- target: {fileID: 9500000, guid: 412b92d4feeb9c548bfa98f62c4d1022, type: 3}
  propertyPath: m_Controller
  value:
  objectReference: {fileID: 9100000, guid: 8d5a0e0d58f4e4176a844a1a03976c19, type: 2}
```

El bloque anterior debe estar presente en **ambos** PrefabInstances. El jugador es `921667375` — si solo se pone en `392336086` el personaje no camina.

> Si el builder destruye y recrea la escena, estos overrides se pierden — volver a añadirlos manualmente en ambas instancias o agregar la lógica al builder.

---

## Scripts del jugador

### `Assets/Scripts/PlayerMovement.cs`

| Variable | Tipo | Valor | Descripción |
|---|---|---|---|
| `velocidad` | `float` | `5` | Metros/segundo de desplazamiento |
| `velocidadRotacion` | `float` | `720` | Grados/segundo al girar |

Lectura de input: `Keyboard.current` (new Input System). Teclas: WASD + flechas.  
Parámetros Animator que alimenta: `Speed` y `Direction`.  
Serializado en escena: `SampleScene.unity` líneas 5152–5154.

### `Assets/Scripts/CameraFollow.cs`

| Variable | Tipo | Valor | Descripción |
|---|---|---|---|
| `objetivo` | `Transform` | jugador | Transform que sigue la cámara |
| `distancia` | `float` | `6` | Distancia orbital al jugador |
| `altura` | `float` | `2.5` | Altura sobre el jugador |
| `suavizado` | `float` | `8` | Velocidad de interpolación (Lerp) |
| `sensibilidad` | `float` | `0.15` | Velocidad de rotación con mouse |
| `pitchMin` | `float` | `5` | Ángulo vertical mínimo (grados) |
| `pitchMax` | `float` | `55` | Ángulo vertical máximo (grados) |

Usa `Mouse.current` (new Input System). `Escape` libera el cursor; clic izquierdo lo bloquea de nuevo.

---

## Repositorio Git

| Elemento | Estado |
|---|---|
| `Assets/unity-chan!/` | **Excluido** del repo — reimportar desde Asset Store |
| `Assets/Mnostva Art/` | **Excluido** del repo — reimportar desde Asset Store |
| `Library/`, `Temp/`, `Obj/`, `Logs/` | Excluidos (generados por Unity) |
| `Assets/Exposicion/`, `Assets/Scripts/`, `Assets/img/`, `Assets/Scenes/` | Incluidos |
| `ProjectSettings/`, `Packages/`, `docs/`, `README.md` | Incluidos |

**Si se clona el repo en una máquina nueva**, antes de abrir la escena hay que importar los dos paquetes desde Unity Asset Store. Ver instrucciones completas en `README.md`.

---

## Reglas de mantenimiento

1. **Cambiar un prefab = recalibrar sus paneles** — las coords de panel son locales al prefab raíz.
2. Antes de "Construir Escenario Completo", verificar que el builder tenga el prefab correcto en cada stand.
3. Cada vez que se calibre un panel en el editor, actualizar este archivo y `COORDENADAS.md`.
4. Los GUIDs de textura no cambian si no se mueve el archivo. Si se mueve, actualizar el `.mat` correspondiente.
5. Los overrides de UnityChan en la escena se pierden si el builder recrea `Sala_Exposicion` — restaurarlos manualmente (ver sección Personaje).
