using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject CharacterController;
    bool isPaused = false;
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void Salir()
    {
        #if UNITY_EDITOR
               UnityEditor.EditorApplication.isPlaying = false;
        #else
               Application.Quit();
        #endif
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);
        CharacterController.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
