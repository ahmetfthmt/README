using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game Settings")]
    public int currentLevel = 1;
    public bool[] levelsCompleted;
    public int totalLevels = 10;
    
    [Header("Player Settings")]
    public Transform playerSpawnPoint;
    public float playerHealth = 100f;
    public float playerMaxHealth = 100f;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void InitializeGame()
    {
        levelsCompleted = new bool[totalLevels];
        for (int i = 0; i < totalLevels; i++)
        {
            levelsCompleted[i] = false;
        }
    }
    
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 1 && levelIndex <= totalLevels)
        {
            currentLevel = levelIndex;
            SceneManager.LoadScene("Level_" + levelIndex);
        }
    }
    
    public void CompleteLevel(int levelIndex)
    {
        if (levelIndex >= 1 && levelIndex <= totalLevels)
        {
            levelsCompleted[levelIndex - 1] = true;
        }
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void NextLevel()
    {
        if (currentLevel < totalLevels)
        {
            LoadLevel(currentLevel + 1);
        }
        else
        {
            // Game completed
            Debug.Log("Tebrikler! Oyunu tamamladınız!");
        }
    }
    
    public void UpdatePlayerHealth(float amount)
    {
        playerHealth += amount;
        if (playerHealth > playerMaxHealth)
            playerHealth = playerMaxHealth;
        if (playerHealth < 0)
            playerHealth = 0;
            
        if (playerHealth <= 0)
        {
            PlayerDeath();
        }
    }
    
    void PlayerDeath()
    {
        Debug.Log("Oyuncu öldü! Yeniden başlatılıyor...");
        RestartLevel();
    }
}