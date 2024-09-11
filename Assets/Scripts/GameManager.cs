using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed {get; private set;}
    
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private Player player;
    private Spawner spawner;
    private AudioManager audioManager;
    private float score;
    //private bool hiscoreUp;

    
    private void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy(){
        if(Instance == this){
            Instance = null;
        }
    }

    private void Start(){
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        NewGame();
    }

    public void NewGame(){
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach(var obstacle in obstacles){
            Destroy(obstacle.gameObject);
        }
        gameSpeed = initialGameSpeed;
        enabled = true;
        score = 0f;
        audioManager.StopMusic();
        audioManager.PlayBG(audioManager.background);
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }
    public void GameOver(){
        gameSpeed = 0;
        enabled = false;
        audioManager.StopMusic();
        audioManager.PlayBG(audioManager.gameOverSound);
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        UpdateHiScore();
    }
    private void Update(){
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        //Debug.Log(hiscoreUp);
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    // private void HighScoreSound(){
    //     if(score >= float.Parse(highScoreText.text)){
    //         audioManager.PlayBG(audioManager.background);
    //         //audioManager.PlaySFX(audioManager.hiscoreSfx);
    //         hiscoreUp = false;
    //     }

    // }
    private void UpdateHiScore(){
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        //hiscore = 5;
        if(score > hiscore){
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        highScoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    } 
}
