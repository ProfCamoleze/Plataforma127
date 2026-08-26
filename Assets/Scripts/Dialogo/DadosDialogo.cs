using UnityEngine;

// Permite criar arquivos de diálogo pelo menu Create.
[CreateAssetMenu(fileName = "NovoDialogo", menuName = "Dialogo/Novo Dialogo")]
public class DadosDialogo : ScriptableObject
{
    // Guarda todas as falas da conversa.
    public FalaDialogo[] falas;
}
