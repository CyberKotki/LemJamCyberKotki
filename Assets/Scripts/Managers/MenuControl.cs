using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject settingsMenu;

    void Start()
    {
        CloseSettings(); // Make sure settings are closed on startup
    }
    
    void Update()
    {
        if (settingsMenu.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseSettings();
        }
    }
    
    
    // Method to load a new scene by id
    public void LoadScene(int sceneID)
    {
        Debug.Log("change to scene ID#" + sceneID);
        SceneManager.LoadScene(sceneID);
        
    }

    public void OpenSettings()
    {
        Debug.Log("Settings");
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ShowCredits()
    {
        Debug.Log("Credits");
    }
}
