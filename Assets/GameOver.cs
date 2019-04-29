using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void ReturnToMenu()
    {
        //load the scene with the next build index
        Debug.Log("You lose");
        SceneManager.LoadScene(0);
        
    }
}
