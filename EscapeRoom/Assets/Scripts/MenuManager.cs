using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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
}
