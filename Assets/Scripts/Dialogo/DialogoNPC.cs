using UnityEngine;

public class DialogoNPC : MonoBehaviour
{
    [Header("Diálogo")]
    public DadosDialogo dialogo;
    [Header("Gerenciador de Diálogo")]
    public GerenciadorDialogo gerenciadorDialogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o jogador entrou na área de interação.
        if (collision.CompareTag("Player"))
        {
            // Inicia o diálogo com o NPC.
            gerenciadorDialogo.IniciarDialogo(dialogo);
        }
    }
}
