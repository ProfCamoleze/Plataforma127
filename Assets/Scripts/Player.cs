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

    bool ehchao; //armazenar se ta no chao
    public Transform checkChao;// armazena a posição do objeto que vai verificar se ta no chão
    public float raioCheckChao=0.2f; //raio do objeto que vai verificar se ta no chão
    public LayerMask oqueEchao; //armazenar quais objetos são considerados chão


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

        //verificar se ta no chão
        ehchao = Physics2D.OverlapCircle(checkChao.position, raioCheckChao, oqueEchao);

        if (controle.Player.Jump.WasPressedThisFrame() && ehchao)
        {
            pular();
        }
         // instruções para virar
        if (mover.x > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }else if(mover.x < -0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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
