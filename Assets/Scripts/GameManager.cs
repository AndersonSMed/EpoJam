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
    private AudioClip file;

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
        SceneManager.LoadScene("TelaInicial");
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
        } else {
            PassarFase();
        }
    }

    public int PegarArquivos() {
        return arquivos;
    }

    void Start () {
        SceneManager.activeSceneChanged += OnSceneChanged;
	}

    private void OnSceneChanged(Scene current, Scene next) {
        if (next.name == "GameOver") {
            arquivos = 0;
        }else if (next.name == "TelaInicial") {
            SoundManager.Instance.PlayMusicLevel(tutorial);
        }else if (next.name == "Fase1") {
            SoundManager.Instance.PlayMusicLevel(fase1);
        }else if (next.name == "Fase2") {
            SoundManager.Instance.PlayMusicLevel(fase2);
        }else if (next.name == "Fase3") {
            SoundManager.Instance.PlayMusicLevel(fase3);
        }
    }

    private void OnDestroy() {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    public float PegarTempoParaSeguirTexto() {
        return tempoParaSeguirTexto;
    }

    public void PassarFase() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public float PegarTempoDePausaDoTexto() {
        return tempoDePausaDoTexto;
    }

    public KeyCode PegarTeclaPularTexto() {
        return teclaParaPularTexto;
    }
}
