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
    private AudioClip fase1;
    [SerializeField]
    private AudioClip fase2;
    [SerializeField]
    private AudioClip fase3;


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

    public void GameOver() {

    }

    // Use this for initialization
    void Start () {
        SceneManager.activeSceneChanged += OnSceneChanged;
	}

    private void OnSceneChanged(Scene current, Scene next) {
        if(next.name == "Tutorial") {
            SoundManager.Instance.PlayMusic(fase1);
        }
    }

    private void OnDestroy() {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    public float PegarTempoParaSeguirTexto() {
        return tempoParaSeguirTexto;
    }

    public void ComecarTutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public float PegarTempoDePausaDoTexto() {
        return tempoDePausaDoTexto;
    }

    public KeyCode PegarTeclaPularTexto() {
        return teclaParaPularTexto;
    }
}
