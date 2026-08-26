using UnityEngine;

// Permite que os dados desta classe apareçam no Inspector.
[System.Serializable]
public class FalaDialogo
{
    public string nomePersonagem;
    public Sprite retrato;
    [TextArea(3, 6)]
    public string texto;
}
