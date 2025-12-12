using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("UI")]
    public TMP_Text textTacadas;
    public TMP_Text textTacadasFinal;
    public TMP_Text textPar;
    public TMP_Text textRecorde;
    public GameObject panelVitoria;
    public GameObject panelDados;
    public TMP_Text textResultadoFinal;

    [Header("Jogo")]
    public int tacadas;
    public int par;

    private int recorde;
    private string recordeKey;

    private void Awake()
    {
        gm = this;
    }

    void Start()
    {
        // Identificador do recorde baseado no nome da fase
        recordeKey = "recorde_" + SceneManager.GetActiveScene().name;

        tacadas = 0;
        textTacadas.text = "Tacadas: 0";
        textPar.text = "Par: " + par;

        recorde = PlayerPrefs.GetInt(recordeKey, -1);

        if (recorde == -1)
            textRecorde.text = "Recorde: –";
        else
            textRecorde.text = "Recorde: " + recorde;

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

        AtualizarRecorde();
        AbrirTelaVitoria(resultado);
    }

    private void AtualizarRecorde()
    {
        if (recorde == -1)
        {
            SalvarNovoRecorde(tacadas);
            return;
        }

        if (tacadas < recorde)
        {
            SalvarNovoRecorde(tacadas);
        }
    }

    private void SalvarNovoRecorde(int novoRecorde)
    {
        recorde = novoRecorde;
        PlayerPrefs.SetInt(recordeKey, recorde);
        PlayerPrefs.Save();
        textRecorde.text = "Recorde: " + recorde;
    }

    private void AbrirTelaVitoria(string resultado)
    {
        textResultadoFinal.text = resultado;
        textTacadasFinal.text = "Tacadas: " + tacadas;

        panelDados.SetActive(false);
        panelVitoria.SetActive(true);

        Time.timeScale = 0f; // Pausar jogo
    }

    public void Continuar()
    {
        Time.timeScale = 1f;

        // Recarregar a fase atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Avançar pra próxima fase:
        // SceneManager.LoadScene("Fase2");
    }
}