// Coloca este archivo en Assets/Editor/
// Menú Unity: Exposicion > Construir Escenario Completo
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ExhibitionSceneBuilder : EditorWindow
{
    private const string RutaMat = "Assets/Exposicion/Materiales";

    [MenuItem("Exposicion/Construir Escenario Completo")]
    public static void ConstruirEscenario()
    {
        AsegurarCarpetas();

        // ── Materiales ──────────────────────────────────────────────────────────
        var matSuelo    = CrearMaterial("Suelo",           new Color(0.55f, 0.51f, 0.46f));
        var matPared    = CrearMaterial("Pared",           new Color(0.93f, 0.91f, 0.88f));
        var matTecho    = CrearMaterial("Techo",           new Color(0.82f, 0.81f, 0.80f));
        var matStandB   = CrearMaterial("Stand_Base",      new Color(0.15f, 0.35f, 0.62f));
        var matStandP   = CrearMaterial("Stand_Panel",     new Color(0.09f, 0.21f, 0.48f));
        var matMarco    = CrearMaterial("Pantalla_Marco",  new Color(0.06f, 0.06f, 0.06f));
        var matPantalla = CrearMaterial("Pantalla",        new Color(0.88f, 0.94f, 1.00f), emissive: true);
        var matAvatar   = CrearMaterial("Avatar",          new Color(0.22f, 0.62f, 0.33f));

        // ── Destruir instancia previa para evitar duplicados ────────────────────
        var existente = GameObject.Find("Sala_Exposicion");
        if (existente != null)
        {
            Object.DestroyImmediate(existente);
            Debug.Log("[Builder] Sala_Exposicion anterior eliminada.");
        }

        // ── Raíz jerárquica ─────────────────────────────────────────────────────
        var raiz = new GameObject("Sala_Exposicion");

        ConstruirSuelo(raiz, matSuelo);
        ConstruirParedes(raiz, matPared, matTecho);
        ConstruirPantallaPrincipal(raiz, matMarco, matPantalla);
        ConstruirStands(raiz, matStandB, matStandP);
        ConstruirIluminacion(raiz);
        ConstruirAvatar(raiz, matAvatar);

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        Selection.activeGameObject = raiz;
        SceneView.FrameLastActiveSceneView();

        Debug.Log("<color=#00CC44><b>Escenario creado correctamente.</b> Guarda la escena con Ctrl+S.</color>");
    }

    // ─── PASO 1 · SUELO ────────────────────────────────────────────────────────

    static void ConstruirSuelo(GameObject padre, Material mat)
    {
        var suelo = GameObject.CreatePrimitive(PrimitiveType.Plane);
        suelo.name = "Suelo";
        suelo.transform.SetParent(padre.transform, false);
        suelo.transform.localScale = new Vector3(2.5f, 1f, 2.5f); // → 25 × 25 u
        suelo.GetComponent<Renderer>().sharedMaterial = mat;
    }

    // ─── PASO 1 · PAREDES Y TECHO ──────────────────────────────────────────────

    static void ConstruirParedes(GameObject padre, Material matP, Material matT)
    {
        var grupo = Hijo("Paredes", padre);
        float semi = 12.5f;
        float alt  = 7f;

        // Tres paredes + techo (la entrada queda abierta al frente, Z-)
        CrearCaja("Pared_Fondo",     new Vector3( 0f,   alt / 2f,  semi), new Vector3(semi * 2f, alt,  0.4f), matP, grupo);
        CrearCaja("Pared_Izquierda", new Vector3(-semi, alt / 2f,  0f),   new Vector3(0.4f,  alt,  semi * 2f), matP, grupo);
        CrearCaja("Pared_Derecha",   new Vector3( semi, alt / 2f,  0f),   new Vector3(0.4f,  alt,  semi * 2f), matP, grupo);
        CrearCaja("Techo",           new Vector3( 0f,   alt + 0.2f, 0f),  new Vector3(semi * 2f, 0.4f, semi * 2f), matT, grupo);
    }

    // ─── PASO 2 · PANTALLA PRINCIPAL ───────────────────────────────────────────

    static void ConstruirPantallaPrincipal(GameObject padre, Material matM, Material matS)
    {
        var grupo = Hijo("Pantalla_Principal", padre);
        grupo.transform.position = new Vector3(0f, 3.2f, 11.8f);

        // Marco oscuro (ligeramente más grande que la pantalla)
        CrearCaja("Marco",      Vector3.zero,                new Vector3(7.4f, 4.4f, 0.20f), matM, grupo);
        // Superficie luminosa
        CrearCaja("Superficie", new Vector3(0f, 0f, -0.14f), new Vector3(6.8f, 3.8f, 0.08f), matS, grupo);
    }

    // ─── PASO 2 · CINCO STANDS ─────────────────────────────────────────────────

    private const string PrefabsPath = "Assets/Mnostva Art/FREE_Interiors_2/Prefabs/";

    static void ConstruirStands(GameObject padre, Material matB, Material matP)
    {
        var grupo = Hijo("Stands", padre);

        // 5 stands — posiciones tomadas del scene
        var configs = new (string nombre, Vector3 pos, float yRot)[]
        {
            ("Stand_01_Izq_Norte",  new Vector3(-9.5f, 0f,  7.0f),       90f),
            ("Stand_02_Izq_Centro", new Vector3(-9.5f, 0f,  0.0f),       90f),
            ("Stand_03_Izq_Sur",    new Vector3(-9.5f, 0f, -6.860002f),  90f),
            ("Stand_04_Der_Norte",  new Vector3( 9.5f, 0f,  4.0f),      -90f),
            ("Stand_05_Der_Sur",    new Vector3( 9.5f, 0f, -4.0f),      -90f),
        };

        foreach (var (nombre, pos, yRot) in configs)
            CrearStand(nombre, pos, yRot, matB, matP, grupo);
    }

    static void CrearStand(string nombre, Vector3 pos, float yRot,
                            Material matB, Material matP, GameObject padre)
    {
        var s = Hijo(nombre, padre);
        s.transform.localPosition    = pos;
        s.transform.localEulerAngles = new Vector3(0f, yRot, 0f);

        CrearCaja("Base", new Vector3(0f, 0.10f, 0f), new Vector3(4.0f, 0.20f, 2.5f), matB, s);

        switch (nombre)
        {
            case "Stand_01_Izq_Norte":
                var cabinet01 = InstanciarPrefab("Cafe_Cabinet_1.prefab", new Vector3(0.0f, 0.2f, -0.6f), Vector3.one * 1.4f, s);
                if (cabinet01 != null) { cabinet01.name = "Mario_Cabinet";
                    CrearPanelImagen(cabinet01, "Panel_Mario_Gabinet_1",
                        "Assets/Exposicion/Materiales/Mat_Mario_Gabinet_1.mat",
                        new Vector3(0.86f, 0.42271432f, 0.273f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.641f);
                    CrearPanelImagen(cabinet01, "Panel_Mario_Gabinet_2",
                        "Assets/Exposicion/Materiales/Mat_Mario_Gabinet_2.mat",
                        new Vector3(-0.003f, 0.42f, 0.277f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.889f);
                    CrearPanelImagen(cabinet01, "Panel_Mario_Gabinet_3",
                        "Assets/Exposicion/Materiales/Mat_Mario_Gabinet_3.mat",
                        new Vector3(-0.863f, 0.413f, 0.273f),
                        new Vector3(0.55413f, 0.50551015f, 0.019314779f),
                        -181.157f);
                }
                var board01 = InstanciarPrefab("Cafe_Board_1.prefab", new Vector3(0.0f, 5.28f, -2.23f), Vector3.one * 2.2f, s);
                if (board01 != null)
                    CrearPanelImagen(board01, "Panel_Mario_Board",
                        "Assets/Exposicion/Materiales/Mat_Board_Mario.mat",
                        new Vector3(0.0268183f, -0.625f, 0.1572727f),
                        new Vector3(1.4569246f, 0.891715f, 0.021231668f),
                        183.462f);
                InstanciarPrefab("Cafe_Plant_1.prefab",          new Vector3( 1.6f, 0.2f,  0.4f),  Vector3.one * 1.0f, s);
                break;

            case "Stand_02_Izq_Centro":
                var cabinet02 = InstanciarPrefab("Cafe_Cabinet_1.prefab", new Vector3(0.0f, 0.2f, -0.6f), Vector3.one * 1.4f, s);
                if (cabinet02 != null) { cabinet02.name = "Hollow_Cabinet";
                    CrearPanelImagen(cabinet02, "Panel_Hollow_Gabinet_1",
                        "Assets/Exposicion/Materiales/Mat_Hollow_Gabinet_1.mat",
                        new Vector3(0.86f, 0.42271432f, 0.273f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.641f);
                    CrearPanelImagen(cabinet02, "Panel_Hollow_Gabinet_2",
                        "Assets/Exposicion/Materiales/Mat_Hollow_Gabinet_2.mat",
                        new Vector3(-0.003f, 0.42f, 0.277f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.889f);
                    CrearPanelImagen(cabinet02, "Panel_Hollow_Gabinet_3",
                        "Assets/Exposicion/Materiales/Mat_Hollow_Gabinet_3.mat",
                        new Vector3(-0.863f, 0.413f, 0.273f),
                        new Vector3(0.55413f, 0.50551015f, 0.019314779f),
                        -181.157f);
                }
                var board02 = InstanciarPrefab("Cafe_Board_1.prefab", new Vector3(0.0f, 5.39f, -2.23f), Vector3.one * 2.2f, s);
                if (board02 != null) { board02.name = "Hollow_Board";
                    CrearPanelImagen(board02, "Panel_Hollow_Board",
                        "Assets/Exposicion/Materiales/Mat_Board_Hollow.mat",
                        new Vector3(0.0268183f, -0.625f, 0.1572727f),
                        new Vector3(1.4569246f, 0.891715f, 0.021231668f),
                        183.462f);
                }
                break;

            case "Stand_03_Izq_Sur":
                var cabinet03 = InstanciarPrefab("Cafe_Cabinet_1.prefab", new Vector3(0.0f, 0.2f, -0.6f), Vector3.one * 1.4f, s);
                if (cabinet03 != null) { cabinet03.name = "Death_Cabinet";
                    CrearPanelImagen(cabinet03, "Panel_Death_Gabinet_1",
                        "Assets/Exposicion/Materiales/Mat_Death_Gabinet_1.mat",
                        new Vector3(0.86f, 0.42271432f, 0.273f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.641f);
                    CrearPanelImagen(cabinet03, "Panel_Death_Gabinet_2",
                        "Assets/Exposicion/Materiales/Mat_Death_Gabinet_2.mat",
                        new Vector3(-0.003f, 0.42f, 0.277f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.889f);
                    CrearPanelImagen(cabinet03, "Panel_Death_Gabinet_3",
                        "Assets/Exposicion/Materiales/Mat_Death_Gabinet_3.mat",
                        new Vector3(-0.863f, 0.413f, 0.273f),
                        new Vector3(0.55413f, 0.50551015f, 0.019314779f),
                        -181.157f);
                }
                InstanciarPrefab("Cafe_Coffee_Bean_Sign_1.prefab", new Vector3( 0.0f, 2.8f, -1.0f), Vector3.one * 2.0f, s);
                var board03 = InstanciarPrefab("Cafe_Board_1.prefab", new Vector3(0.0f, 5.39f, -2.23f), Vector3.one * 2.2f, s);
                if (board03 != null) { board03.name = "Death_Board";
                    CrearPanelImagen(board03, "Panel_Death_Board",
                        "Assets/Exposicion/Materiales/Mat_Board_Death.mat",
                        new Vector3(0.0268183f, -0.625f, 0.1572727f),
                        new Vector3(1.4569246f, 0.891715f, 0.021231668f),
                        183.462f);
                }
                break;

            case "Stand_04_Der_Norte":
                var cabinet04 = InstanciarPrefab("Cafe_Cabinet_1.prefab", new Vector3(0.0f, 0.2f, -0.6f), Vector3.one * 1.4f, s);
                if (cabinet04 != null) { cabinet04.name = "Fifa_Cabinet";
                    CrearPanelImagen(cabinet04, "Panel_Fifa_Gabinet_1",
                        "Assets/Exposicion/Materiales/Mat_Fifa_Gabinet_1.mat",
                        new Vector3(0.86f, 0.42271432f, 0.273f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.641f);
                    CrearPanelImagen(cabinet04, "Panel_Fifa_Gabinet_2",
                        "Assets/Exposicion/Materiales/Mat_Fifa_Gabinet_2.mat",
                        new Vector3(-0.003f, 0.42f, 0.277f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.889f);
                    CrearPanelImagen(cabinet04, "Panel_Fifa_Gabinet_3",
                        "Assets/Exposicion/Materiales/Mat_Fifa_Gabinet_3.mat",
                        new Vector3(-0.863f, 0.413f, 0.273f),
                        new Vector3(0.55413f, 0.50551015f, 0.019314779f),
                        -181.157f);
                }
                var board04 = InstanciarPrefab("Cafe_Board_1.prefab", new Vector3(0.0f, 5.39f, -2.23f), Vector3.one * 2.2f, s);
                if (board04 != null) { board04.name = "Fifa_Board";
                    CrearPanelImagen(board04, "Panel_Fifa_Board",
                        "Assets/Exposicion/Materiales/Mat_Board_Fifa.mat",
                        new Vector3(0.0268183f, -0.625f, 0.1572727f),
                        new Vector3(1.4569246f, 0.891715f, 0.021231668f),
                        183.462f);
                }
                break;

            case "Stand_05_Der_Sur":
                var cabinet05 = InstanciarPrefab("Cafe_Cabinet_1.prefab", new Vector3(0.0f, 0.2f, -0.6f), Vector3.one * 1.4f, s);
                if (cabinet05 != null) { cabinet05.name = "Stain_Cabinet";
                    CrearPanelImagen(cabinet05, "Panel_Stain_Gabinet_1",
                        "Assets/Exposicion/Materiales/Mat_Stain_Gabinet_1.mat",
                        new Vector3(0.86f, 0.42271432f, 0.273f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.641f);
                    CrearPanelImagen(cabinet05, "Panel_Stain_Gabinet_2",
                        "Assets/Exposicion/Materiales/Mat_Stain_Gabinet_2.mat",
                        new Vector3(-0.003f, 0.42f, 0.277f),
                        new Vector3(0.55413014f, 0.50551015f, 0.019314783f),
                        -180.889f);
                    CrearPanelImagen(cabinet05, "Panel_Stain_Gabinet_3",
                        "Assets/Exposicion/Materiales/Mat_Stain_Gabinet_3.mat",
                        new Vector3(-0.863f, 0.413f, 0.273f),
                        new Vector3(0.55413f, 0.50551015f, 0.019314779f),
                        -181.157f);
                }
                var board05 = InstanciarPrefab("Cafe_Board_1.prefab", new Vector3(0.0f, 5.39f, -2.23f), Vector3.one * 2.2f, s);
                if (board05 != null) { board05.name = "Stain_Board";
                    CrearPanelImagen(board05, "Panel_Stain_Board",
                        "Assets/Exposicion/Materiales/Mat_Board_Stain.mat",
                        new Vector3(0.0268183f, -0.625f, 0.1572727f),
                        new Vector3(1.4569246f, 0.891715f, 0.021231668f),
                        183.462f);
                }
                break;
        }
    }

    static GameObject InstanciarPrefab(string archivo, Vector3 posLocal, Vector3 escala, GameObject padre)
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PrefabsPath + archivo);
        if (prefab == null)
        {
            Debug.LogWarning($"Prefab no encontrado: {PrefabsPath + archivo}");
            return null;
        }
        var go = (GameObject)PrefabUtility.InstantiatePrefab(prefab, padre.transform);
        go.transform.localPosition = posLocal;
        go.transform.localScale    = escala;
        return go;
    }

    static void CrearPanelImagen(GameObject parent, string nombre, string rutaMaterial,
        Vector3 posLocal, Vector3 escala, float rotY = 183.462f)
    {
        var mat = AssetDatabase.LoadAssetAtPath<Material>(rutaMaterial);
        if (mat == null)
        {
            Debug.LogWarning($"Material no encontrado: {rutaMaterial}");
            return;
        }

        var panel = new GameObject(nombre);
        panel.transform.SetParent(parent.transform, false);
        panel.transform.localPosition = posLocal;
        panel.transform.localRotation = Quaternion.Euler(0f, rotY, 0f);
        panel.transform.localScale    = escala;

        var tempQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        var quadMesh = tempQuad.GetComponent<MeshFilter>().sharedMesh;
        Object.DestroyImmediate(tempQuad);

        var mf = panel.AddComponent<MeshFilter>();
        mf.sharedMesh = quadMesh;

        var mr = panel.AddComponent<MeshRenderer>();
        mr.sharedMaterial = mat;
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    // ─── PASO 1 · ILUMINACIÓN ──────────────────────────────────────────────────

    static void ConstruirIluminacion(GameObject padre)
    {
        var grupo = Hijo("Iluminacion", padre);

        // Deshabilitar la luz direccional por defecto si existe
        foreach (var l in Object.FindObjectsByType<Light>(FindObjectsSortMode.None))
        {
            if (l.type == LightType.Directional && l.name == "Directional Light")
            {
                l.gameObject.SetActive(false);
                break;
            }
        }

        // Luz ambiental base
        RenderSettings.ambientMode  = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(0.36f, 0.36f, 0.40f);

        // Luz direccional principal
        var dirGO = new GameObject("Luz_Direccional");
        dirGO.transform.SetParent(grupo.transform, false);
        dirGO.transform.eulerAngles = new Vector3(48f, -28f, 0f);
        var dir = dirGO.AddComponent<Light>();
        dir.type      = LightType.Directional;
        dir.intensity = 0.75f;
        dir.color     = new Color(1.00f, 0.97f, 0.90f);
        dir.shadows   = LightShadows.Soft;

        // Puntos de luz distribuidos en el techo
        CrearPuntoLuz("Luz_Centro",    new Vector3( 0f, 6f,  0f), 1.00f, 22f, new Color(1.00f, 0.98f, 0.92f), grupo);
        CrearPuntoLuz("Luz_Izquierda", new Vector3(-8f, 6f, -1f), 0.80f, 18f, new Color(1.00f, 0.98f, 0.92f), grupo);
        CrearPuntoLuz("Luz_Derecha",   new Vector3( 8f, 6f, -1f), 0.80f, 18f, new Color(1.00f, 0.98f, 0.92f), grupo);
        // Acento azul sobre la pantalla
        CrearPuntoLuz("Luz_Pantalla",  new Vector3( 0f, 5f,  8f), 1.20f, 12f, new Color(0.75f, 0.88f, 1.00f), grupo);
    }

    static void CrearPuntoLuz(string nombre, Vector3 posLocal, float intensidad,
                               float rango, Color color, GameObject padre)
    {
        var go = Hijo(nombre, padre);
        go.transform.localPosition = posLocal;
        var luz = go.AddComponent<Light>();
        luz.type      = LightType.Point;
        luz.intensity = intensidad;
        luz.range     = rango;
        luz.color     = color;
        luz.shadows   = LightShadows.None;
    }

    // ─── PASO 3 · AVATAR ───────────────────────────────────────────────────────

    private const string UnityChanPrefab = "Assets/unity-chan!/Unity-chan! Model/Prefabs/unitychan.prefab";

    static void ConstruirAvatar(GameObject padre, Material mat)
    {
        var avatar = Hijo("Avatar", padre);
        avatar.transform.position = new Vector3(0f, 0f, -9f);

        // Instanciar Unity-chan como modelo visual
        var ucPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(UnityChanPrefab);
        if (ucPrefab != null)
        {
            var uc = (GameObject)PrefabUtility.InstantiatePrefab(ucPrefab, avatar.transform);
            uc.name = "UnityChan_Visual";
            uc.transform.localPosition = Vector3.zero;
            uc.transform.localRotation = Quaternion.identity;
            uc.transform.localScale    = Vector3.one;

            // Eliminar componentes que chocan con el CharacterController del padre
            var ctrlScript = uc.GetComponent("UnityChanControlScriptWithRgidBody") as MonoBehaviour;
            if (ctrlScript != null) Object.DestroyImmediate(ctrlScript);
            var rb = uc.GetComponent<Rigidbody>();
            if (rb  != null) Object.DestroyImmediate(rb);
            var cap = uc.GetComponent<CapsuleCollider>();
            if (cap != null) Object.DestroyImmediate(cap);

            // Convertir materiales a URP para eliminar el color rosado
            ConvertirMaterialesAURP(uc);
        }
        else
        {
            Debug.LogWarning($"Unity-chan no encontrada en {UnityChanPrefab}. Usando cápsula de respaldo.");
            var cuerpo = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            cuerpo.name = "Cuerpo";
            cuerpo.transform.SetParent(avatar.transform, false);
            cuerpo.transform.localPosition = new Vector3(0f, 1f, 0f);
            cuerpo.transform.localScale    = new Vector3(0.6f, 0.5f, 0.6f);
            cuerpo.GetComponent<Renderer>().sharedMaterial = mat;
            Object.DestroyImmediate(cuerpo.GetComponent<CapsuleCollider>());
        }

        // Character Controller sobre el objeto padre (colisionador real)
        var cc = avatar.AddComponent<CharacterController>();
        cc.height = 1.6f;
        cc.radius = 0.35f;
        cc.center = new Vector3(0f, 0.8f, 0f);

        // Script de movimiento propio
        avatar.AddComponent<PlayerMovement>();

        // Cámara principal
        var cam = Camera.main;
        if (cam != null)
        {
            cam.transform.position = new Vector3(0f, 4.5f, -13f);
            cam.transform.LookAt(avatar.transform.position + Vector3.up * 1.2f);
            var cf = cam.GetComponent<CameraFollow>() ?? cam.gameObject.AddComponent<CameraFollow>();
            cf.objetivo = avatar.transform;
        }
        else
        {
            Debug.LogWarning("Cámara principal no encontrada.");
        }
    }

    // ─── CONVERSIÓN MATERIALES A URP ──────────────────────────────────────────

    static void ConvertirMaterialesAURP(GameObject go)
    {
        var shader = EncontrarShaderURP();
        foreach (var rend in go.GetComponentsInChildren<Renderer>(true))
        {
            var mats = rend.sharedMaterials;
            for (int i = 0; i < mats.Length; i++)
            {
                if (mats[i] == null) continue;
                var original = mats[i];
                var nuevo    = new Material(shader);
                nuevo.name   = original.name + "_URP";

                // Preservar textura y color originales
                if (original.HasProperty("_MainTex"))
                    nuevo.SetTexture("_BaseMap", original.GetTexture("_MainTex"));
                Color col = original.HasProperty("_Color") ? original.GetColor("_Color") : Color.white;
                nuevo.SetColor("_BaseColor", col);
                nuevo.SetFloat("_Smoothness", 0.05f);
                nuevo.SetFloat("_Metallic",   0f);

                mats[i] = nuevo;
            }
            rend.sharedMaterials = mats;
        }
    }

    // ─── UTILIDADES ────────────────────────────────────────────────────────────

    static void AsegurarCarpetas()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Exposicion"))
            AssetDatabase.CreateFolder("Assets", "Exposicion");
        if (!AssetDatabase.IsValidFolder(RutaMat))
            AssetDatabase.CreateFolder("Assets/Exposicion", "Materiales");
    }

    static Shader EncontrarShaderURP()
    {
        // Busca el shader Lit de URP directamente en los paquetes (más confiable que Shader.Find)
        string[] guids = AssetDatabase.FindAssets("Lit t:Shader",
            new[] { "Packages/com.unity.render-pipelines.universal" });
        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (path.EndsWith("Lit.shader"))
                return AssetDatabase.LoadAssetAtPath<Shader>(path);
        }
        var sh = Shader.Find("Universal Render Pipeline/Lit");
        if (sh != null) return sh;
        Debug.LogWarning("<color=yellow>URP Lit no encontrado, usando Standard.</color>");
        return Shader.Find("Standard");
    }

    static Material CrearMaterial(string nombre, Color color, bool emissive = false)
    {
        string ruta = $"{RutaMat}/{nombre}.mat";
        var shader = EncontrarShaderURP();

        var mat = AssetDatabase.LoadAssetAtPath<Material>(ruta);
        if (mat == null)
        {
            mat = new Material(shader) { name = nombre };
            AssetDatabase.CreateAsset(mat, ruta);
        }
        else
        {
            mat.shader = shader;
        }

        mat.SetColor("_BaseColor", color);
        mat.SetColor("_Color", color);
        mat.SetFloat("_Smoothness", 0.2f);
        mat.SetFloat("_Metallic", 0f);

        if (emissive)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", color * 0.5f);
        }
        EditorUtility.SetDirty(mat);
        return mat;
    }

    static GameObject CrearCaja(string nombre, Vector3 posLocal, Vector3 escala,
                                 Material mat, GameObject padre)
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.name = nombre;
        go.transform.SetParent(padre.transform, false);
        go.transform.localPosition = posLocal;
        go.transform.localScale    = escala;
        go.GetComponent<Renderer>().sharedMaterial = mat;
        return go;
    }

    static GameObject Hijo(string nombre, GameObject padre)
    {
        var go = new GameObject(nombre);
        go.transform.SetParent(padre.transform, false);
        return go;
    }
}
