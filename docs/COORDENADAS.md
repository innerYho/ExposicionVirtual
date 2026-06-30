# Coordenadas de Paneles — Exposición Virtual

Paneles Quad hijos de cada prefab. Todas las coordenadas son **locales al prefab padre**.  
Las de `Pantalla_Principal` son **locales a ese objeto raíz**.

## Jerarquía de la escena

```
Sala_Exposicion
├── Stands
│   ├── Stand_01_Izq_Norte         mundo (-9.5, 0, 7.0)        rotY 90°
│   │   ├── Base
│   │   ├── Mario_Cabinet          ← prefab: Cafe_Cabinet_1  pos (0, 0.2, -0.6)    escala 1.4
│   │   │   ├── Panel_Mario_Gabinet_1
│   │   │   ├── Panel_Mario_Gabinet_2
│   │   │   └── Panel_Mario_Gabinet_3
│   │   ├── Cafe_Table_1
│   │   ├── Cafe_Board_1           ← prefab: Cafe_Board_1    pos (0, 5.28, -2.23)  escala 2.2
│   │   │   └── Panel_Mario_Board
│   │   └── Cafe_Plant_1
│   ├── Stand_02_Izq_Centro        mundo (-9.5, 0, 0.0)        rotY 90°
│   │   ├── Base
│   │   ├── Hollow_Cabinet         ← prefab: Cafe_Cabinet_1  pos (0, 0.2, -0.6)    escala 1.4
│   │   │   ├── Panel_Hollow_Gabinet_1
│   │   │   ├── Panel_Hollow_Gabinet_2
│   │   │   └── Panel_Hollow_Gabinet_3
│   │   └── Hollow_Board           ← prefab: Cafe_Board_1    pos (0, 5.39, -2.23)  escala 2.2
│   │       └── Panel_Hollow_Board
│   ├── Stand_03_Izq_Sur           mundo (-9.5, 0, -6.860002)  rotY 90°
│   │   ├── Base
│   │   ├── Death_Cabinet          ← prefab: Cafe_Cabinet_1  pos (0, 0.2, -0.6)    escala 1.4
│   │   │   ├── Panel_Death_Gabinet_1
│   │   │   ├── Panel_Death_Gabinet_2
│   │   │   └── Panel_Death_Gabinet_3
│   │   └── Death_Board            ← prefab: Cafe_Board_1    pos (0, 5.39, -2.23)  escala 2.2
│   │       └── Panel_Death_Board
│   ├── Stand_04_Der_Norte         mundo (9.5, 0, 4.0)         rotY -90°
│   │   ├── Base
│   │   ├── Fifa_Cabinet           ← prefab: Cafe_Cabinet_1  pos (0, 0.2, -0.6)    escala 1.4
│   │   │   ├── Panel_Fifa_Gabinet_1
│   │   │   ├── Panel_Fifa_Gabinet_2
│   │   │   └── Panel_Fifa_Gabinet_3
│   │   └── Fifa_Board             ← prefab: Cafe_Board_1    pos (0, 5.39, -2.23)  escala 2.2
│   │       └── Panel_Fifa_Board
│   └── Stand_05_Der_Sur           mundo (9.5, 0, -4.0)        rotY -90°
│       ├── Base
│       ├── Stain_Cabinet          ← prefab: Cafe_Cabinet_1  pos (0, 0.2, -0.6)    escala 1.4
│       │   ├── Panel_Stain_Gabinet_1
│       │   ├── Panel_Stain_Gabinet_2
│       │   └── Panel_Stain_Gabinet_3
│       └── Stain_Board            ← prefab: Cafe_Board_1    pos (0, 5.39, -2.23)  escala 2.2
│           └── Panel_Stain_Board
└── Pantalla_Principal             mundo (0, 3.2, 11.8)         sin rotación
    ├── Marco
    ├── Superficie
    ├── Panel_Logo_Feria
    └── Panel_Titulo_Feria
```

> **Regla:** el campo `prefab` indica el archivo `.prefab` exacto que debe usar el builder. Si se cambia el prefab, las coordenadas de los paneles dejan de ser válidas y hay que recalibrar.

---

## Stand_01 — Super Mario Bros.

### Panel_Mario_Board (Cafe_Board_1)
| Campo | Valor |
|---|---|
| Parent | `Cafe_Board_1` |
| localPosition | `(0.0268183, -0.625, 0.1572727)` |
| localRotation | `Euler(0, 183.462, 0)` |
| localScale | `(1.4569246, 0.891715, 0.021231668)` |
| Textura | `Assets/img/mario/Super_Mario_logo.png` |
| GUID textura | `f1f0bfee9b9b1f340bf934b75c6f699e` |
| Material | `Assets/Exposicion/Materiales/Mat_Board_Mario.mat` |

### Panel_Mario_Gabinet_1 (Cafe_Cabinet_1 — cara izquierda)
| Campo | Valor |
|---|---|
| Parent | `Cafe_Cabinet_1` |
| localPosition | `(0.86, 0.42271432, 0.273)` |
| localRotation | `Euler(0, -180.641, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/mario/Mario_gabinet_1.jpg` |
| GUID textura | `b61bc493a8e95274ab4cc7408934c0fd` |
| Material | `Assets/Exposicion/Materiales/Mat_Mario_Gabinet_1.mat` |

### Panel_Mario_Gabinet_2 (Cafe_Cabinet_1 — cara central)
| Campo | Valor |
|---|---|
| Parent | `Cafe_Cabinet_1` |
| localPosition | `(-0.003, 0.42, 0.277)` |
| localRotation | `Euler(0, -180.889, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/mario/Mario_gabinet_2.jpg` |
| GUID textura | `2c3d4e5f6a7b2c3d4e5f6a7b2c3d4e5f` |
| Material | `Assets/Exposicion/Materiales/Mat_Mario_Gabinet_2.mat` |

### Panel_Mario_Gabinet_3 (Cafe_Cabinet_1 — cara derecha)
| Campo | Valor |
|---|---|
| Parent | `Cafe_Cabinet_1` |
| localPosition | `(-0.863, 0.413, 0.273)` |
| localRotation | `Euler(0, -181.157, 0)` |
| localScale | `(0.55413, 0.50551015, 0.019314779)` |
| Textura | `Assets/img/mario/Mario_gabinet_3.jpg` |
| GUID textura | `34f386cbff5743f49b2a1bb47019a021` |
| Material | `Assets/Exposicion/Materiales/Mat_Mario_Gabinet_3.mat` |

---

## Stand_02 — Hollow Knight

> `Hollow_Cabinet` usa **`Cafe_Cabinet_1.prefab`** — coordenadas de paneles idénticas a los demás stands.

### Panel_Hollow_Board (Hollow_Board / Cafe_Board_1)
| Campo | Valor |
|---|---|
| Parent | `Hollow_Board` |
| localPosition | `(0.0268183, -0.625, 0.1572727)` |
| localRotation | `Euler(0, 183.462, 0)` |
| localScale | `(1.4569246, 0.891715, 0.021231668)` |
| Textura | `Assets/img/Hollow Knight/hollow-knight-title.png` |
| GUID textura | `730602d0428d7684996f1a4e9ee13787` |
| Material | `Assets/Exposicion/Materiales/Mat_Board_Hollow.mat` |

### Panel_Hollow_Gabinet_1 (Hollow_Cabinet — cara izquierda)
| Campo | Valor |
|---|---|
| Parent | `Hollow_Cabinet` |
| localPosition | `(0.86, 0.42271432, 0.273)` |
| localRotation | `Euler(0, -180.641, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Hollow Knight/HollowKnigh1.jpg` |
| GUID textura | `bf7370515696fce44a190c79e256242e` |
| Material | `Assets/Exposicion/Materiales/Mat_Hollow_Gabinet_1.mat` |

### Panel_Hollow_Gabinet_2 (Hollow_Cabinet — cara central)
| Campo | Valor |
|---|---|
| Parent | `Hollow_Cabinet` |
| localPosition | `(-0.003, 0.42, 0.277)` |
| localRotation | `Euler(0, -180.889, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Hollow Knight/HollowKnigth2.jpeg` |
| GUID textura | `b9215481249593a448ac616b05063eca` |
| Material | `Assets/Exposicion/Materiales/Mat_Hollow_Gabinet_2.mat` |

### Panel_Hollow_Gabinet_3 (Hollow_Cabinet — cara derecha)
| Campo | Valor |
|---|---|
| Parent | `Hollow_Cabinet` |
| localPosition | `(-0.863, 0.413, 0.273)` |
| localRotation | `Euler(0, -181.157, 0)` |
| localScale | `(0.55413, 0.50551015, 0.019314779)` |
| Textura | `Assets/img/Hollow Knight/HollowKniight3.jpeg` |
| GUID textura | `241736beff5d91b4a8a4af53e662bf9c` |
| Material | `Assets/Exposicion/Materiales/Mat_Hollow_Gabinet_3.mat` |

---

## Stand_03 — Death Stranding

> `Death_Cabinet` usa **`Cafe_Cabinet_1.prefab`** — mismas coords de paneles que Stand_01 y Stand_02.

### Panel_Death_Board (Death_Board / Cafe_Board_1)
| Campo | Valor |
|---|---|
| Parent | `Death_Board` |
| localPosition | `(0.0268183, -0.625, 0.1572727)` |
| localRotation | `Euler(0, 183.462, 0)` |
| localScale | `(1.4569246, 0.891715, 0.021231668)` |
| Textura | `Assets/img/Death Starding/deathTitulo.png` |
| GUID textura | `93259d2297016234f892507c3f5d2d61` |
| Material | `Assets/Exposicion/Materiales/Mat_Board_Death.mat` |

### Panel_Death_Gabinet_1 (Death_Cabinet — cara izquierda)
| Campo | Valor |
|---|---|
| Parent | `Death_Cabinet` |
| localPosition | `(0.86, 0.42271432, 0.273)` |
| localRotation | `Euler(0, -180.641, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Death Starding/Death1.jpg` |
| GUID textura | `6223db80238e3314580c46bd1a5a50bf` |
| Material | `Assets/Exposicion/Materiales/Mat_Death_Gabinet_1.mat` |

### Panel_Death_Gabinet_2 (Death_Cabinet — cara central)
| Campo | Valor |
|---|---|
| Parent | `Death_Cabinet` |
| localPosition | `(-0.003, 0.42, 0.277)` |
| localRotation | `Euler(0, -180.889, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Death Starding/Death2.jpeg` |
| GUID textura | `38d176cce840e51458c9bf03b12a9e7c` |
| Material | `Assets/Exposicion/Materiales/Mat_Death_Gabinet_2.mat` |

### Panel_Death_Gabinet_3 (Death_Cabinet — cara derecha)
| Campo | Valor |
|---|---|
| Parent | `Death_Cabinet` |
| localPosition | `(-0.863, 0.413, 0.273)` |
| localRotation | `Euler(0, -181.157, 0)` |
| localScale | `(0.55413, 0.50551015, 0.019314779)` |
| Textura | `Assets/img/Death Starding/Death3.jpeg` |
| GUID textura | `bfb5b04e3b0a62b4081714125eff562a` |
| Material | `Assets/Exposicion/Materiales/Mat_Death_Gabinet_3.mat` |

---

## Stand_04 — FIFA Street 2

> `Fifa_Cabinet` usa **`Cafe_Cabinet_1.prefab`** — mismas coords de paneles que stands anteriores.

### Panel_Fifa_Board (Fifa_Board / Cafe_Board_1)
| Campo | Valor |
|---|---|
| Parent | `Fifa_Board` |
| localPosition | `(0.0268183, -0.625, 0.1572727)` |
| localRotation | `Euler(0, 183.462, 0)` |
| localScale | `(1.4569246, 0.891715, 0.021231668)` |
| Textura | `Assets/img/Fifa Street 2/fifaTitulo2.png` |
| GUID textura | `938127e4f78c8b842a1336142aefbb56` |
| Material | `Assets/Exposicion/Materiales/Mat_Board_Fifa.mat` |

### Panel_Fifa_Gabinet_1 (Fifa_Cabinet — cara izquierda)
| Campo | Valor |
|---|---|
| Parent | `Fifa_Cabinet` |
| localPosition | `(0.86, 0.42271432, 0.273)` |
| localRotation | `Euler(0, -180.641, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Fifa Street 2/Fifa1.jpeg` |
| GUID textura | `5c7cebc0f2daa5643829f91558297aad` |
| Material | `Assets/Exposicion/Materiales/Mat_Fifa_Gabinet_1.mat` |

### Panel_Fifa_Gabinet_2 (Fifa_Cabinet — cara central)
| Campo | Valor |
|---|---|
| Parent | `Fifa_Cabinet` |
| localPosition | `(-0.003, 0.42, 0.277)` |
| localRotation | `Euler(0, -180.889, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Fifa Street 2/Fifa2.jpeg` |
| GUID textura | `fe522296e34822549a11fdccc57d08aa` |
| Material | `Assets/Exposicion/Materiales/Mat_Fifa_Gabinet_2.mat` |

### Panel_Fifa_Gabinet_3 (Fifa_Cabinet — cara derecha)
| Campo | Valor |
|---|---|
| Parent | `Fifa_Cabinet` |
| localPosition | `(-0.863, 0.413, 0.273)` |
| localRotation | `Euler(0, -181.157, 0)` |
| localScale | `(0.55413, 0.50551015, 0.019314779)` |
| Textura | `Assets/img/Fifa Street 2/Fifa3.jpeg` |
| GUID textura | `8aa9e9fa09e8361469c3f1c6aead1f78` |
| Material | `Assets/Exposicion/Materiales/Mat_Fifa_Gabinet_3.mat` |

---

## Stand_05 — Steins;Gate

> `Stain_Cabinet` usa **`Cafe_Cabinet_1.prefab`** — mismas coords de paneles que stands anteriores.

### Panel_Stain_Board (Stain_Board / Cafe_Board_1)
| Campo | Valor |
|---|---|
| Parent | `Stain_Board` |
| localPosition | `(0.0268183, -0.625, 0.1572727)` |
| localRotation | `Euler(0, 183.462, 0)` |
| localScale | `(1.4569246, 0.891715, 0.021231668)` |
| Textura | `Assets/img/Hollow Knight/steins-gateTitulo.png` |
| GUID textura | `56139c01562d6474fb3dec7b975e5097` |
| Material | `Assets/Exposicion/Materiales/Mat_Board_Stain.mat` |

### Panel_Stain_Gabinet_1 (Stain_Cabinet — cara izquierda)
| Campo | Valor |
|---|---|
| Parent | `Stain_Cabinet` |
| localPosition | `(0.86, 0.42271432, 0.273)` |
| localRotation | `Euler(0, -180.641, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Steins;Gate/StainsGate1.png` |
| GUID textura | `315d63d2fbf0ee748ac550703ee49ce3` |
| Material | `Assets/Exposicion/Materiales/Mat_Stain_Gabinet_1.mat` |

### Panel_Stain_Gabinet_2 (Stain_Cabinet — cara central)
| Campo | Valor |
|---|---|
| Parent | `Stain_Cabinet` |
| localPosition | `(-0.003, 0.42, 0.277)` |
| localRotation | `Euler(0, -180.889, 0)` |
| localScale | `(0.55413014, 0.50551015, 0.019314783)` |
| Textura | `Assets/img/Steins;Gate/SteinsGate2.jpg` |
| GUID textura | `7c8315e49d8c1d74d88a7a6dd677e688` |
| Material | `Assets/Exposicion/Materiales/Mat_Stain_Gabinet_2.mat` |

### Panel_Stain_Gabinet_3 (Stain_Cabinet — cara derecha)
| Campo | Valor |
|---|---|
| Parent | `Stain_Cabinet` |
| localPosition | `(-0.863, 0.413, 0.273)` |
| localRotation | `Euler(0, -181.157, 0)` |
| localScale | `(0.55413, 0.50551015, 0.019314779)` |
| Textura | `Assets/img/Steins;Gate/SteinsGate3.jpg` |
| GUID textura | `12130b1e9aceabb4a94fcf0c3d61a619` |
| Material | `Assets/Exposicion/Materiales/Mat_Stain_Gabinet_3.mat` |

---

## Pantalla_Principal

Objeto raíz en escena: posición mundo **(0, 3.2, 11.8)**, sin rotación.  
Coordenadas de paneles son **locales a `Pantalla_Principal`** (no al hijo `Superficie`).

### Panel_Logo_Feria
| Campo | Valor |
|---|---|
| Parent | `Pantalla_Principal` |
| localPosition | `(0, -0.3, -0.21)` |
| localRotation | `Euler(0, 0, 0)` |
| localScale | `(2.6, 2.6, 0.01)` |
| Textura | `Assets/img/Official_unity_logo.png` |
| GUID textura | `b75113171aabb9d4db362b04ab654ad2` |
| Material | `Assets/Exposicion/Materiales/Mat_Logo_Feria.mat` |
| GUID material | `a8b9c0d1e2f3a4b5c6d7e8f9a0b1c2d3` |

### Panel_Titulo_Feria
| Campo | Valor |
|---|---|
| Parent | `Pantalla_Principal` |
| localPosition | `(0, 1.3, -0.21)` |
| localRotation | `Euler(0, 0, 0)` |
| localScale | `(6.0, 1.0, 0.01)` |
| Textura | `Assets/img/titulo_feria.png` |
| GUID textura | `8e1f8e167d7fc754db7d789691a55267` |
| Material | `Assets/Exposicion/Materiales/Mat_Titulo_Feria.mat` |
| GUID material | `b9c0d1e2f3a4b5c6d7e8f9a0b1c2d3e4` |
