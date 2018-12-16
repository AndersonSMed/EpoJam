using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager instance;

    [SerializeField]
    private float tempoParaSeguirTexto = 0.2f;
    [SerializeField]
    private float tempoDePausaDoTexto = 0.5f;
    [SerializeField]
    private KeyCode teclaParaPularTexto;
    [SerializeField]
    private AudioClip tutorial;
    [SerializeField]
    private AudioClip fase1;
    [SerializeField]
    private AudioClip fase2;
    [SerializeField]
    private AudioClip fase3;
    [SerializeField]
    private AudioClip gameOver;
    [SerializeField]
    private AudioClip file;
    [SerializeField]
    private AudioClip boss;

    private int arquivos = 0;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != gameObject)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    public string PegarCena() {
        return SceneManager.GetActiveScene().name;
    }

    public void ResetGame() {
        if(PegarCena() == "Menu")
            SceneManager.LoadScene("TelaInicial");
        if (PegarCena() == "GameOver")
            SceneManager.LoadScene("Fase1");
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void AumentarArquivos() {
        arquivos++;
        SoundManager.Instance.PlaySFX(file);
        if (SceneManager.GetActiveScene().name == "Fase2") {
            if (arquivos == 3) {
                PassarFase();
            }
        } else if (SceneManager.GetActiveScene().name != "Boss") {
            PassarFase();
        }
    }

    public void DiminuirArquivos() {
        arquivos--;
        if (arquivos == 0)
            GameOver();
    }

    public int PegarArquivos() {
        return arquivos;
    }

    void Start () {
        SceneManager.activeSceneChanged += OnSceneChanged;
	}

    private void OnSceneChanged(Scene current, Scene next) {
        if (next.name == "GameOver") {
            SoundManager.Instance.PlayMusic(gameOver);
            arquivos = 0;
        }else if (next.name == "TelaInicial") {
            SoundManager.Instance.PlayMusicLevel(tutorial);
        }else if (next.name == "Fase1") {
            SoundManager.Instance.PlayMusicLevel(fase1);
        }else if (next.name == "Fase2") {
            SoundManager.Instance.PlayMusicLevel(fase2);
        }else if (next.name == "Fase3") {
            SoundManager.Instance.PlayMusicLevel(fase3);
        } else if (next.name == "TelaFinal") {
            SoundManager.Instance.PlayMusicLevel(tutorial);
        } else if (next.name == "LogFinal") {
            SoundManager.Instance.StopMusic();
        } else if (next.name == "Boss") {
            SoundManager.Instance.PlayMusic(boss);
        }
    }

    private void OnDestroy() {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    public float PegarTempoParaSeguirTexto() {
        return tempoParaSeguirTexto;
    }

    public void PassarFase() {
        if (SceneManager.GetActiveScene().name == "TelaInicial" || SceneManager.GetActiveScene().name == "GameOver" ||
            SceneManager.GetActiveScene().name == "TelaFinal")
            ChangeScene();
        else
            Invoke("ChangeScene", 1f);
    }

    private void ChangeScene() {
        if(SceneManager.GetActiveScene().name != "GameOver")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SairDoJogo() {
        Application.Quit();
    }

    public float PegarTempoDePausaDoTexto() {
        return tempoDePausaDoTexto;
    }

    public KeyCode PegarTeclaPularTexto() {
        return teclaParaPularTexto;
    }
}
