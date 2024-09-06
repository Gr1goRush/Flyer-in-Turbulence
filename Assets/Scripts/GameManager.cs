using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Text scoreText, money, GameOverScoreText, GameOverRecordText, moneyGameOver, InpytName, scoreTextSave, lid1, lid2, lid3;
    [SerializeField] private GameObject playButton;
    // [SerializeField] private GameObject gameOver;
    [SerializeField] GameObject shopButton, setiingsButton, LiderButton, moneyImage, moneyText, shop, game, menuUi, gameover, settings, firstPlay, liderboard, savePanel;
    int hp = 3;
    [SerializeField] Sprite live, DeLive;
    [SerializeField] Image live1, live2, live3;

    private float score;
    public float Score => score;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            Pause();
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("first") == 1)
        {
            firstPlay.SetActive(false);
        }
        else
        {
            firstPlay.SetActive(true);
            PlayerPrefs.SetInt("first", 1);
        }
    }

    private void Update()
    {
        lid1.text = "1: " + PlayerPrefs.GetString("s1N") + "   " + PlayerPrefs.GetInt("s1");
        lid2.text = "2: " + PlayerPrefs.GetString("s2N") + "   " + PlayerPrefs.GetInt("s2");
        lid3.text = "3: " + PlayerPrefs.GetString("s3N") + "   " + PlayerPrefs.GetInt("s3");
        moneyGameOver.text = PlayerPrefs.GetInt("money").ToString();
        score += Time.deltaTime * 2;

        scoreText.text = Mathf.Round(score).ToString();
        scoreTextSave.text = Mathf.Round(score).ToString();
        LivseUpdate();
        money.text = PlayerPrefs.GetInt("money").ToString();
      
    }

    public void Play()
    {
        liderboard.SetActive(false);
        firstPlay.SetActive(false);
        playButton.SetActive(false);
        // gameOver.SetActive(false);
        shopButton.SetActive(false);
        setiingsButton.SetActive(false);
        LiderButton.SetActive(false);
        game.SetActive(true);
        shop.SetActive(false);
        menuUi.SetActive(false);
        settings.SetActive(false);
        hp = 3;
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        if (PlayerPrefs.GetInt("vib") == 1)
        {
            Handheld.Vibrate();
        }

        hp--;
        if (hp <= 0)
        {
            menuUi.SetActive(true);
            playButton.SetActive(true);
            // gameOver.SetActive(true);
            shopButton.SetActive(true);
            setiingsButton.SetActive(true);
            LiderButton.SetActive(true);
            game.SetActive(false);
            shop.SetActive(false);

            GameOverMenu();
        }
    }

    public void Pause()
    {
        hp = 3;

        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOverMenu()
    {
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("score") < score)
        {
            PlayerPrefs.SetInt("score", (int)Mathf.Round(score));
        }
        menuUi.SetActive(false);
        playButton.SetActive(false);
        shopButton.SetActive(false);
        setiingsButton.SetActive(false);
        LiderButton.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        scoreText.gameObject.SetActive(false);
        gameover.SetActive(true);
        GameOverScoreText.text = (Mathf.Round(score)).ToString();
        GameOverRecordText.text = PlayerPrefs.GetInt("score").ToString();

    }
    public void Back()
    {
        score = 0;
       
        Pause();
        menuUi.SetActive(true);
        playButton.SetActive(true);
        shopButton.SetActive(true);
        setiingsButton.SetActive(true);
        LiderButton.SetActive(true);
        game.SetActive(false);
        shop.SetActive(false);
        gameover.SetActive(false);
        scoreText.gameObject.SetActive(true);
        scoreText.text = PlayerPrefs.GetInt("score").ToString();

    }
    public void Retry()
    {
       
        score = 0;
        player.transform.position = new Vector3(-0.85f,0);
        Play();
        gameover.SetActive(false);
        scoreText.gameObject.SetActive(true);

    }
    public void ShopBack()
    {
        menuUi.SetActive(true);
        shop.SetActive(false);
        game.SetActive(false);

    }
    public void ToShop()
    {
        menuUi.SetActive(false);
        game.SetActive(false);
        shop.SetActive(true);
    }

    public void LivseUpdate()
    {
        if (hp == 3) 
        {
            live1.sprite = live;
            live2.sprite = live;
            live3.sprite = live;
        }
        if (hp == 2)
        {
            live1.sprite = live;
            live2.sprite = live;
            live3.sprite =DeLive;
        }
        if (hp == 1)
        {
            live1.sprite = live;
            live2.sprite = DeLive;
            live3.sprite = DeLive;
        }
        if (hp == 0)
        {
            live1.sprite = DeLive;
            live2.sprite = DeLive;
            live3.sprite = DeLive;
        }
    }
    public void ToSettibgs()
    {
        menuUi.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }
    public void BackSettibgs()
    {
        menuUi.SetActive(true);
        shop.SetActive(false);
        game.SetActive(false);
        settings.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
    public void ToLider()
    {
        menuUi.SetActive(false);
        game.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(false);
        scoreText.gameObject.SetActive(false);
        liderboard.SetActive(true);
    }
    public void BackLider()
    {
        menuUi.SetActive(true);
        shop.SetActive(false);
        game.SetActive(false);
        settings.SetActive(false);
        scoreText.gameObject.SetActive(true);
        liderboard.SetActive(false);
    }
    public void ToSave()
    {
        savePanel.SetActive(true);
    }
    public void SaveRezults()
    {
        if (score> PlayerPrefs.GetInt("s1"))
        {
            PlayerPrefs.SetInt("s1", (int)Mathf.Round(score));
            PlayerPrefs.SetString("s1N",InpytName.text);
        }
        else if (score > PlayerPrefs.GetInt("s2"))
        {
            PlayerPrefs.SetInt("s2", (int)Mathf.Round(score));
            PlayerPrefs.SetString("s2N", InpytName.text);
        }
        else if (score > PlayerPrefs.GetInt("s3"))
        {
            PlayerPrefs.SetInt("s3", (int)Mathf.Round(score));
            PlayerPrefs.SetString("s3N", InpytName.text);
        }
        savePanel.SetActive(false);
    }
}
