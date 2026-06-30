using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float velocidadRotacion = 720f;

    private CharacterController _controller;
    private Transform _camara;
    private Animator _animator;
    private float _velocidadY;
    private bool _estabaMoviendo;
    private const float Gravedad = -15f;
    private static readonly int HashIdle = Animator.StringToHash("Idle");
    private static readonly int HashSpeed = Animator.StringToHash("Speed");
    private static readonly int HashDirection = Animator.StringToHash("Direction");

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camara = Camera.main?.transform;
        _animator = GetComponentInChildren<Animator>();
        if (_animator != null)
            _animator.speed = 1.5f;
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        float h = 0f, v = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  h = -1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) h =  1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed)  v = -1f;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed)    v =  1f;

        Vector3 direccion = Vector3.zero;

        if (_camara != null)
        {
            Vector3 adelante = _camara.forward; adelante.y = 0f; adelante.Normalize();
            Vector3 derecha  = _camara.right;   derecha.y  = 0f; derecha.Normalize();
            direccion = adelante * v + derecha * h;
        }
        else
        {
            direccion = new Vector3(h, 0f, v).normalized;
        }

        bool estaMoviendo = direccion.sqrMagnitude > 0.01f;

        if (_animator != null)
        {
            _animator.SetFloat(HashSpeed,     estaMoviendo ? 1f : 0f, 0.1f, Time.deltaTime);
            _animator.SetFloat(HashDirection, h,                       0.1f, Time.deltaTime);

            // Saltar el exit-time de Idle para que la caminata arranque inmediatamente
            if (estaMoviendo && !_estabaMoviendo)
            {
                var estado = _animator.GetCurrentAnimatorStateInfo(0);
                if (estado.shortNameHash == HashIdle)
                    _animator.CrossFade("Locomotion", 0.15f, 0);
            }
        }

        _estabaMoviendo = estaMoviendo;

        if (estaMoviendo)
        {
            Quaternion rotObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, rotObjetivo, velocidadRotacion * Time.deltaTime);
        }

        if (_controller.isGrounded && _velocidadY < 0f)
            _velocidadY = -2f;

        _velocidadY += Gravedad * Time.deltaTime;

        _controller.Move((direccion * velocidad + Vector3.up * _velocidadY) * Time.deltaTime);
    }
}
