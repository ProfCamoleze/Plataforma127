using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDialogo : MonoBehaviour
{
    [Header("Interface")]
    public GameObject painelDialogo;
    public TMP_Text txtNome;
    public TMP_Text txtFala;
    public Image imgRetrato;
    // Diálogo que está sendo exibido.
    private DadosDialogo dialogoAtual;
    // Número da fala atual.
    private int indiceFala;

    private void Start()
    {
        // Começa com a janela escondida.
        painelDialogo.SetActive(false);
    }

    public void IniciarDialogo(DadosDialogo dialogo)
    {
        // Guarda o diálogo recebido do NPC.
        dialogoAtual = dialogo;
        // Começa pela primeira fala.
        indiceFala = 0;
        // Abre a janela.
        painelDialogo.SetActive(true);
        // Mostra a primeira fala.
        MostrarFala();
    }
    private void MostrarFala()
    {
        // Pega a fala correspondente ao índice atual.
        FalaDialogo fala = dialogoAtual.falas[indiceFala];
        // Atualiza os elementos da interface.
        txtNome.text = fala.nomePersonagem;
        txtFala.text = fala.texto;
        imgRetrato.sprite = fala.retrato;
    }
    public void ContinuarDialogo()
    {
        // Avança para a próxima fala.
        indiceFala++;
        // Se ainda existe uma fala, mostra a próxima.
        if (indiceFala < dialogoAtual.falas.Length)
        {
            MostrarFala();
        }
        else
        {
            // Se acabaram as falas, fecha a conversa.
            FecharDialogo();
        }
    }
    public void FecharDialogo()
    {
        // Esconde a janela.
        painelDialogo.SetActive(false);
    }
}
