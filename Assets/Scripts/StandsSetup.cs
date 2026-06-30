using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

/// Adjuntar al GameObject "Stands".
/// Inspector → clic derecho → "Decorar Stands con Juegos".
public class StandsSetup : MonoBehaviour
{
    // ── Asignación stands → juegos ──────────────────────────────
    // Modifica el array si quieres cambiar el orden de los juegos
    static readonly StandConfig[] Configs = new[]
    {
        new StandConfig("Stand_01_Izq_Norte", "Mario Bros",      "Mat_Stand_Mario"),
        new StandConfig("Stand_02_Izq_Centro","FIFA Street",     "Mat_Stand_FIFA"),
        new StandConfig("Stand_03_Izq_Sur",   "Death Stranding", "Mat_Stand_Death"),
        new StandConfig("Stand_04_Der_Norte",  "Hollow Knight",  "Mat_Stand_Hollow"),
        new StandConfig("Stand_05_Der_Sur",    "Steins;Gate",    "Mat_Stand_Steins"),
    };

    const string MatPath = "Assets/Exposicion/Materiales/";

    [ContextMenu("Decorar Stands con Juegos")]
    public void Decorar()
    {
#if UNITY_EDITOR
        foreach (var cfg in Configs)
        {
            Transform stand = transform.Find(cfg.StandName);
            if (stand == null) { Debug.LogWarning($"No encontré: {cfg.StandName}"); continue; }

            // 1 ── Cambiar color de la Base
            var mat = AssetDatabase.LoadAssetAtPath<Material>($"{MatPath}{cfg.MatName}.mat");
            if (mat != null)
            {
                foreach (var r in stand.GetComponentsInChildren<MeshRenderer>(true))
                {
                    // Solo los hijos propios del stand (no los prefabs de café que tienen su propio material)
                    if (r.gameObject.name == "Base" || r.gameObject.name == "Panel")
                        r.sharedMaterial = mat;
                }
            }
            else Debug.LogWarning($"Material no encontrado: {cfg.MatName}");

            // 2 ── Etiqueta del juego (TextMesh encima de la base)
            SetEtiqueta(stand, cfg.GameName, mat);

            EditorUtility.SetDirty(stand.gameObject);
        }

        EditorSceneManager.MarkSceneDirty(gameObject.scene);
        Debug.Log("[StandsSetup] Stands decorados. Guarda la escena (Ctrl+S).");
#endif
    }

    static void SetEtiqueta(Transform stand, string texto, Material mat)
    {
        const string tag = "Etiqueta";
        Transform existing = stand.Find(tag);
        GameObject go = existing != null ? existing.gameObject : new GameObject(tag);
        go.transform.SetParent(stand, false);
        go.transform.localPosition = new Vector3(0f, 1.6f, 0f);
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale    = new Vector3(0.5f, 0.5f, 0.5f);

        var tm = go.GetComponent<TextMesh>() ?? go.AddComponent<TextMesh>();
        tm.text          = texto;
        tm.characterSize = 0.4f;
        tm.fontSize      = 60;
        tm.fontStyle     = FontStyle.Bold;
        tm.anchor        = TextAnchor.MiddleCenter;
        tm.alignment     = TextAlignment.Center;
        tm.color         = mat != null ? LightenColor(mat.GetColor("_BaseColor")) : Color.white;

        var mr = go.GetComponent<MeshRenderer>() ?? go.AddComponent<MeshRenderer>();
        _ = mr; // Unity gestiona el material de fuente automáticamente
    }

    static Color LightenColor(Color c) =>
        new Color(Mathf.Clamp01(c.r + 0.55f),
                  Mathf.Clamp01(c.g + 0.55f),
                  Mathf.Clamp01(c.b + 0.55f), 1f);

    struct StandConfig
    {
        public string StandName, GameName, MatName;
        public StandConfig(string s, string g, string m) { StandName=s; GameName=g; MatName=m; }
    }
}
