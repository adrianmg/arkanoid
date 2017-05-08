using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public const int INIT_LIFES = 2;
    public const int BlockHitsBase = 1;
    public const int BlockScoreBase = 50;

    public static int Lifes { get; private set; }
    public static int Score { get; private set; }
    public static int Level { get; private set; }


    static GameManager()
    {
        Lifes = INIT_LIFES;
        Score = 0;
    }

    private void Start()
    {
        Level = GetLevel();
    }

    public void InitGame()
    {
        Lifes = INIT_LIFES;
        Score = 0;
        Level = GetLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            if (SceneManager.GetActiveScene().name == "GameOver")
            {
                SceneManager.LoadScene("Level1");

                instance.InitGame();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public static int GetLifes()
    {
        return Lifes;
    }

    public static void GetExtraLife()
    {
        Lifes++;
    }

    public static void LoseLife()
    {
        if (Lifes > 0)
        {
            Lifes--;

            Debug.Log("Lifes: " + Lifes);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("*** GAME OVER ***");
            SceneManager.LoadScene("GameOver");
        }
    }

    public static int GetScore()
    {
        return Score;
    }

    public static void UpdateScore(int score)
    {
        Score += score;

        Debug.Log("Score: " + Score);
    }

    private static void ResetScore()
    {
        Score = 0;
    }

    private static int GetLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.Contains("Level"))
        {
            Level = int.Parse(sceneName.Replace("Level", ""));
        }

        return Level;
    }
}
