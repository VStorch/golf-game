using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public TMP_Text textTacadas;
    public TMP_Text textPar;

    public int tacadas;
    public int par;

    private int recorde;
    private int pontuacao;

    void Start()
    {
        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();

        tacadas = 0;
        textTacadas.text = "Tacadas: 0";
        textPar.text = "Par: " + par;
        pontuacao = 0;
    }

    public void tacada()
    {
        tacadas++;
        textTacadas.text = "Tacadas: " + tacadas;
    }

    public void FinalizarBuraco()
    {
        int diff = tacadas - par;

        string resultado = diff switch
        {
            -3 => "Albatross",
            -2 => "Eagle",
            -1 => "Birdie",
            0 => "Par",
            1 => "Bogey",
            2 => "Double Bogey",
            3 => "Triple Bogey",
            _ => tacadas < par ? "Excelente!" : "Ruim!"
        };

        Debug.Log("Resultado: " + resultado);

        // Abrir um painel UI avisando o resultado
    }
}
