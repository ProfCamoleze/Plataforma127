using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMax = 3;
    public int vidaAtual;

    public Sprite coracaoCheio;
    public Sprite coracaoVazio;

    public SpriteRenderer spritePlayer;
    public bool estouInvencivel = false;
    public float tempoInvencivel = 2f;

    public Image[] imagemCoracoes; //adicionar o Using UnityEngine.UI; linha 1


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tomarDano(int dano)
    {
        if (estouInvencivel == true)
        {
            return; // essa lina sai do método sem faze nada
        }

        vidaAtual -= dano; //reduz a vida

        if(vidaAtual < 0) // controle para não ter vida negativa.
        {
            vidaAtual = 0;
        }
        atualizaCoracoes(); //erro , ainda vamos fazer

        if (vidaAtual <= 0)
        {
            morreu(); //erro, ainda vamos fazer
        }
        else
        {
            StartCoroutine("Invencivel"); //erro, ainda vamos fazer
        }
    }

    void atualizaCoracoes() //adicione no Start a linha: atualizaCoracoes(); 
    {
        for (int i = 0; i < imagemCoracoes.Length; i++)
        {
            if (i < vidaAtual)
            {
                imagemCoracoes[i].sprite = coracaoCheio;
            }
            else
            {
                imagemCoracoes[i].sprite = coracaoVazio;
            }
        }
    }

    void morreu()
     {
            Debug.Log("O jogador morreu!");
      
    }

    IEnumerator Invencivel() //corrigir de enumerable para IEnumerator
    {
         estouInvencivel = true;
        float tempoPiscando= 0f;
        while(tempoPiscando < tempoInvencivel)
        {
            if(spritePlayer != null)
            {
                spritePlayer.enabled = false; // torna o sprite visível
            }
            yield return new WaitForSeconds(0.2f); // espera 0.2 segundos
            if(spritePlayer != null)
            {
                    spritePlayer.enabled = true; // torna o sprite invisível
            }
            yield return new WaitForSeconds(0.2f); // espera 0.2 segundos
            tempoPiscando += 0.2f;
        }

        if (spritePlayer != null)
        {
            spritePlayer.enabled = true; // garante que o sprite fique visível no final
        }
        estouInvencivel = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("armadilha") )
        {
            tomarDano(1); // Exemplo: o jogador toma 1 ponto de dano ao colidir com um inimigo
        }
    }
}
