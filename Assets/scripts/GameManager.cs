using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("UI")]
    public TMP_Text textTacadas;
    public TMP_Text textPar;
    public GameObject panelVitoria;
    public GameObject panelDados;
    public TMP_Text textResultadoFinal;

    [Header("Jogo")]
    public int tacadas;
    public int par;

    private void Awake()
    {
        gm = this;
    }

    void Start()
    {
        tacadas = 0;
        textTacadas.text = "Tacadas: 0";
        textPar.text = "Par: " + par;

        panelDados.SetActive(true);
        panelVitoria.SetActive(false);
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
            _ => tacadas < par ? "Incrível!" : "Ruim!"
        };

        AbrirTelaVitoria(resultado);
    }

    private void AbrirTelaVitoria(string resultado)
    {
        textResultadoFinal.text = resultado;
        panelDados.SetActive(false);
        panelVitoria.SetActive(true);

        // Pausar o jogo
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        // Despausar
        Time.timeScale = 1f;

        // 1) Recarregar fase atual:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // ou 2) Carregar próxima fase
        // SceneManager.LoadScene("Fase2");
    }
}
