from PIL import Image, ImageDraw, ImageFont
import os

OUT = r"D:\Cursos\Unad\2026\SemestreVI\VR\unity\ExposicionVirtual\Assets\Textures\Stands"
os.makedirs(OUT, exist_ok=True)

GAMES = [
    dict(
        file="img_mario.png",
        titulo="Super Mario Bros.",
        sub="Nintendo  |  Plataformas  |  1985",
        desc=[
            "El fontanero Mario atraviesa el Reino Champiñon",
            "rescatando a la Princesa Peach de Bowser.",
            "Mas de 40 años definiendo el genero plataformero.",
        ],
        bg=(180, 30, 20),
        acc=(255, 200, 0),
    ),
    dict(
        file="img_fifa.png",
        titulo="FIFA Street",
        sub="EA Sports  |  Deportes Arcade  |  2005",
        desc=[
            "Futbol callejero con trucos, estilo y jugadores",
            "reales. Redes, parques y azoteas como estadio.",
            "Modo Panna y partidas 4 contra 4.",
        ],
        bg=(15, 110, 30),
        acc=(255, 220, 0),
    ),
    dict(
        file="img_death.png",
        titulo="Death Stranding",
        sub="Kojima Productions  |  Accion  |  2019",
        desc=[
            "Sam Porter Bridges recorre EE.UU. postapocaliptico,",
            "conectando colonias aisladas y enfrentando entes.",
            "Primer juego del genero Strand (conexion social).",
        ],
        bg=(15, 15, 15),
        acc=(210, 165, 60),
    ),
    dict(
        file="img_hollow.png",
        titulo="Hollow Knight",
        sub="Team Cherry  |  Metroidvania  |  2017",
        desc=[
            "Un caballero insecto explora Hallownest,",
            "reino subterraneo de insectos caidos.",
            "Combate preciso, mundo vasto e historia implicita.",
        ],
        bg=(45, 20, 80),
        acc=(180, 140, 255),
    ),
    dict(
        file="img_steins.png",
        titulo="Steins;Gate",
        sub="5pb  |  Visual Novel  |  2009",
        desc=[
            "Okabe Rintaro inventa sin querer un dispositivo",
            "de mensajes al pasado. Thriller cientifico sobre",
            "viajes en el tiempo y sus consecuencias.",
        ],
        bg=(0, 70, 100),
        acc=(0, 210, 210),
    ),
]

W, H = 800, 600

# Font paths to try (Windows)
FONT_PATHS = [
    r"C:\Windows\Fonts\arialbd.ttf",
    r"C:\Windows\Fonts\arial.ttf",
    r"C:\Windows\Fonts\calibrib.ttf",
    r"C:\Windows\Fonts\calibri.ttf",
]

def load_font(size, bold=False):
    candidates = [p for p in FONT_PATHS if ("bd" in p or "b.ttf" in p) == bold] + FONT_PATHS
    for p in candidates:
        if os.path.exists(p):
            try:
                return ImageFont.truetype(p, size)
            except Exception:
                pass
    return ImageFont.load_default()

font_title = load_font(50, bold=True)
font_sub   = load_font(20)
font_desc  = load_font(22)
font_small = load_font(15)

for g in GAMES:
    img = Image.new("RGB", (W, H), g["bg"])
    d   = ImageDraw.Draw(img)

    # Accent top bar
    d.rectangle([0, 0, W, 14], fill=g["acc"])
    # Accent bottom bar
    d.rectangle([0, H - 14, W, H], fill=g["acc"])
    # Accent left bar
    d.rectangle([0, 0, 10, H], fill=g["acc"])

    # Title
    d.text((26, 28), g["titulo"], font=font_title, fill=g["acc"])

    # Subtitle
    d.text((28, 108), g["sub"], font=font_sub, fill=(210, 210, 210))

    # Separator line
    sep_color = tuple(min(255, int(c * 0.6)) for c in g["acc"])
    d.line([(25, 152), (W - 25, 152)], fill=sep_color, width=2)

    # Description lines
    for i, line in enumerate(g["desc"]):
        d.text((28, 168 + i * 38), line, font=font_desc, fill=(255, 255, 255))

    # Decorative corner accent square
    sq = 60
    d.rectangle([W - sq - 20, 28, W - 20, 28 + sq], fill=g["acc"])
    # First letter of title inside square
    initial = g["titulo"][0]
    d.text((W - sq + 5, 34), initial, font=load_font(38, bold=True), fill=g["bg"])

    # Footer
    footer = "Feria Virtual de Videojuegos  -  UNAD 2026"
    d.text((28, H - 42), footer, font=font_small, fill=(150, 150, 150))

    out_path = os.path.join(OUT, g["file"])
    img.save(out_path, "PNG")
    print(f"OK  {g['file']}  ({W}x{H})")

print("Todas las imagenes generadas.")
