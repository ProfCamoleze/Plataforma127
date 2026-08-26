using UnityEngine;

public class PlataformaRotativa : MonoBehaviour
{
    public Transform centro; // guarda a posição do centro da rotação
    public float velocidade = 50f; // define a velocidade de rotação em graus por segundo
    public bool sentidoHorario = true; // define o sentido de rotação, true para horário e false para anti-horário
    Quaternion rotacaoInicial; // armazena a rotação inicial da plataforma

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotacaoInicial = transform.rotation; // armazena a rotação inicial da plataforma
    }

    // Update is called once per frame
    void Update()
    {
        float direcao= sentidoHorario ? 1f : -1f; 
        transform.RotateAround(centro.position, Vector3.forward, direcao * velocidade * Time.deltaTime); 
        transform.rotation = rotacaoInicial; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pe"))
        {
            Transform player = collision.transform.parent;
            player.SetParent(transform, true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pe"))
        {
            Transform player = collision.transform.parent;
            player.SetParent(null);
        }
    }
}
