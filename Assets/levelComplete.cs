using UnityEngine;
using UnityEngine.SceneManagement;

public class levelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //load the scene with the next build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
