using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform objetivo;

    [Header("Configuración")]
    public float distancia = 6f;
    public float altura = 2.5f;
    public float suavizado = 8f;

    [Header("Mouse")]
    public float sensibilidad = 0.15f;
    public float pitchMin = 5f;
    public float pitchMax = 55f;

    private float _yaw;
    private float _pitch = 20f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (objetivo != null)
            _yaw = objetivo.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (objetivo == null) return;

        var mouse = Mouse.current;
        var kb    = Keyboard.current;

        if (mouse != null)
        {
            Vector2 delta = mouse.delta.ReadValue();
            _yaw   += delta.x * sensibilidad;
            _pitch -= delta.y * sensibilidad;
            _pitch  = Mathf.Clamp(_pitch, pitchMin, pitchMax);

            if (kb != null && kb.escapeKey.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (mouse.leftButton.wasPressedThisFrame && Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        Quaternion rotacion   = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3    posDeseada = objetivo.position
                              + Vector3.up * altura
                              + rotacion * new Vector3(0f, 0f, -distancia);

        transform.position = Vector3.Lerp(transform.position, posDeseada, suavizado * Time.deltaTime);
        transform.LookAt(objetivo.position + Vector3.up * (altura * 0.5f));
    }
}
