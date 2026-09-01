using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    [Header("Referências do Menu")]

    // Painel que contém os botões e elementos
    // visuais do Menu Principal.
    [SerializeField]
    private GameObject painelMenu;


    private void Awake()
    {
        // Quando a Scene começa, escondemos o Menu.
        // Dessa forma, a cutscene aparece primeiro.
        if (painelMenu != null)
        {
            painelMenu.SetActive(false);
        }
    }


    /// <summary>
    /// Exibe o Menu Principal.
    /// Este método será chamado pelo Signal do Timeline.
    /// </summary>
    public void ExibirMenu()
    {
        // Verifica se a referência foi configurada
        // corretamente no Inspector.
        if (painelMenu != null)
        {
            // Ativa o GameObject que contém o Menu.
            painelMenu.SetActive(true);
        }
    }
}
