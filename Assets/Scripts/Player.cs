using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade= 5f;
    Rigidbody2D rig;
    Vector2 mover;
    PlayerContole controle;

    private bool podeMover = true;

    Animator anime;

    [Header("Pulo")]
    public float forcaPulo = 6f;
    public float qtdPulos= 2f; //quantidade de pulos

    bool ehchao; //armazenar se ta no chao
    public Transform checkChao;// armazena a posição do objeto que vai verificar se ta no chão
    public float raioCheckChao=0.2f; //raio do objeto que vai verificar se ta no chão
    public LayerMask oqueEchao; //armazenar quais objetos são considerados chão
 
    private void Awake()
    {
        rig= GetComponent<Rigidbody2D>();
        controle = new PlayerContole();
        anime = GetComponent<Animator>();
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
        if (podeMover)
        {
            mover = controle.Player.Move.ReadValue<Vector2>();
            animar();
            //verificar se ta no chão
            ehchao = Physics2D.OverlapCircle(checkChao.position, raioCheckChao, oqueEchao);

            if (controle.Player.Jump.WasPressedThisFrame() && qtdPulos > 1) //adicionar a variavel qtdPulo linha 16
            {
                qtdPulos--;
                pular();

            }
            else if (ehchao)
            {
                qtdPulos = 2f;
            }

            // instruções para virar
            if (mover.x > 0.01f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (mover.x < -0.01f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

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

    void animar()
    {
        anime.SetFloat("andar",Mathf.Abs(rig.linearVelocityX));
        if (ehchao)
        {
            anime.SetBool("pular", false);
            anime.SetBool("cair", false);
        }
        else
        {
            if(rig.linearVelocityY > 0.1f)
            {
                anime.SetBool("pular", true);
                anime.SetBool("cair", false);
            }else if(rig.linearVelocityY < -0.1f)
            {
                anime.SetBool("pular", false);
                anime.SetBool("cair", true);
            }
        }

    }

    public void BloquearMovimento()
    {
        // Impede novas leituras de movimento.
        podeMover = false;
        // Limpa a última direção recebida do controle.
        mover = Vector2.zero;
        // Interrompe o movimento horizontal atual.
        rig.linearVelocityX = 0f;
    }

    public void LiberarMovimento()
    {
        // Permite novas leituras de movimento.
        podeMover = true;
    }
}
