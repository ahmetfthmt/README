using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Settings")]
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject settingsPanel;
    
    void Start()
    {
        ShowMainMenu();
    }
    
    public void PlayGame()
    {
        // Start from the first level
        GameManager.Instance.LoadLevel(1);
    }
    
    public void LevelSelect()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }
    
    public void Settings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    
    public void QuitGame()
    {
        Debug.Log("Oyun kapatılıyor...");
        Application.Quit();
    }
    
    public void BackToMainMenu()
    {
        if (levelSelectPanel != null) levelSelectPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
    }
    
    public void SelectLevel(int levelIndex)
    {
        GameManager.Instance.LoadLevel(levelIndex);
    }
    
    void ShowMainMenu()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (levelSelectPanel != null) levelSelectPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
    }
    
    // If the game is launched directly, show the main menu
    void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            // If GameManager doesn't exist, create one
            GameObject gmObj = new GameObject("GameManager");
            gmObj.AddComponent<GameManager>();
        }
    }
}