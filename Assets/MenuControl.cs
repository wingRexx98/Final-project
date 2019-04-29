using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Let's begin");
        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
