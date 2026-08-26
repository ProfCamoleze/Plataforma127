using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    Rigidbody2D rig;
    Vector2 mover;
    PlayerContole controle;
    Animator anima;
    private void Awake()
    {
        rig=GetComponent<Rigidbody2D>();
        controle = new PlayerContole();
        anima = GetComponent<Animator>();
    }
    void OnEnable()
    {
        controle.Enable();
    }
    void OnDisable()
    {
        controle.Disable();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mover= controle.Player.Move.ReadValue<Vector2>();
        if (Mathf.Abs(mover.x) > Mathf.Abs(mover.y))
        {
            mover.y = 0;
        }
        else
        {
            mover.x = 0;
        }

        anima.SetFloat("eixoX", mover.x);
        anima.SetFloat("eixoY", mover.y);
        anima.SetFloat("velocidade", mover.sqrMagnitude);
        //  sqrMagnitude  o que é mais eficiente para comparaçã entre distâncias nos eixos

    }
    private void FixedUpdate()
    {
        
            rig.linearVelocity= mover * velocidade;
       
           
    }
}

