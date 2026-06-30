using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

/// Configura el título y logo de la Feria Virtual de Videojuegos en Pantalla_Principal.
/// Uso: adjuntar a Pantalla_Principal → Inspector → clic derecho → "Configurar Pantalla".
public class PantallaPrincipalSetup : MonoBehaviour
{
    [Header("Logo")]
    public Texture2D logo;

    [Header("Título")]
    public string textoTitulo = "Feria Virtual de Videojuegos";
    [Range(0.4f, 3f)] public float tamanoFuente = 1.1f;
    public Color colorTitulo = new Color(1f, 0.95f, 0.4f);

    // ──────────────────────────────────────────────────────────────
    // Pantalla_Principal: Marco 7.4 × 4.4, Superficie z=-0.14 (prof 0.08)
    // Cara frontal Superficie ≈ z = -0.18 → colocamos hijos en z = -0.25
    // ──────────────────────────────────────────────────────────────

    [ContextMenu("Configurar Pantalla")]
    public void Configurar()
    {
        SetupTitulo();
        SetupLogo();

#if UNITY_EDITOR
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
#endif
        Debug.Log("[PantallaPrincipal] Configuración aplicada.");
    }

    // ── Título ────────────────────────────────────────────────────
    void SetupTitulo()
    {
        const string nombre = "Titulo_Feria";
        Transform tr = transform.Find(nombre);
        GameObject go = tr != null ? tr.gameObject : new GameObject(nombre);

        go.transform.SetParent(transform, false);
        go.transform.localPosition = new Vector3(0f, 1.4f, -0.25f);
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale    = Vector3.one;

        var tmp = go.GetComponent<TextMeshPro>() ?? go.AddComponent<TextMeshPro>();
        tmp.text               = textoTitulo;
        tmp.fontSize           = tamanoFuente;
        tmp.fontStyle          = FontStyles.Bold;
        tmp.alignment          = TextAlignmentOptions.Center;
        tmp.color              = colorTitulo;
        tmp.enableWordWrapping = true;
        tmp.rectTransform.sizeDelta = new Vector2(6.5f, 2f);
    }

    // ── Logo ──────────────────────────────────────────────────────
    void SetupLogo()
    {
        if (logo == null)
        {
            Debug.LogWarning("[PantallaPrincipal] Asigna la textura 'logo' en el Inspector antes de configurar.");
            return;
        }

        const string nombre = "Logo_Feria";
        Transform tr = transform.Find(nombre);
        GameObject go;

        if (tr != null)
        {
            go = tr.gameObject;
        }
        else
        {
            go = GameObject.CreatePrimitive(PrimitiveType.Quad);
            go.name = nombre;
            if (go.TryGetComponent<MeshCollider>(out var col))
                DestroyImmediate(col);
        }

        go.transform.SetParent(transform, false);

        // Centrar el logo en el tercio inferior de la pantalla
        float alturaLogo = 2.2f;
        float ratio      = (float)logo.width / Mathf.Max(logo.height, 1);
        go.transform.localPosition = new Vector3(0f, -0.5f, -0.25f);
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale    = new Vector3(alturaLogo * ratio, alturaLogo, 1f);

        // Material URP-compatible con transparencia
        var renderer = go.GetComponent<MeshRenderer>();

#if UNITY_EDITOR
        string matDir  = "Assets/Materials";
        string matPath = $"{matDir}/Mat_LogoFeria.mat";

        if (!System.IO.Directory.Exists(matDir))
            System.IO.Directory.CreateDirectory(matDir);

        var mat = AssetDatabase.LoadAssetAtPath<Material>(matPath);
        if (mat == null)
        {
            mat = new Material(Shader.Find("Sprites/Default"));
            AssetDatabase.CreateAsset(mat, matPath);
        }
        mat.mainTexture = logo;
        EditorUtility.SetDirty(mat);
        AssetDatabase.SaveAssets();
        renderer.sharedMaterial = mat;
#else
        var mat = new Material(Shader.Find("Sprites/Default")) { mainTexture = logo };
        renderer.sharedMaterial = mat;
#endif
    }
}
