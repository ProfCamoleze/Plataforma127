using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade= 5f;
    Rigidbody2D rig;
    Vector2 mover;
    PlayerContole controle;

    [Header("Pulo")]
    public float forcaPulo = 6f;

    private void Awake()
    {
        rig= GetComponent<Rigidbody2D>();
        controle = new PlayerContole();
    }

    private void OnEnable()
    {
        controle.Enable();
    }
    private void OnDisable()
    {
        controle.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        mover= controle.Player.Move.ReadValue<Vector2>();

        if(controle.Player.Jump.WasPressedThisFrame())
        {
            pular();
        }
    }
    void FixedUpdate()
    {
        rig.linearVelocityX=mover.x * velocidade;
    }

    void pular()
    {
        rig.linearVelocityY = 0f; //zerando a velocidade do eixo y
        rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
    }
}
