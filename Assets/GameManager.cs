using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject start;
    bool gameOver = false;
    public float restarttime = 2f;
    public GameObject completeLevelUI;

    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<CharacterController>();
    }

    public void Restart()
    {
        if(gameOver == false)
        {
            gameOver = true;
            Invoke("SceneRestart", restarttime);
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("Complete");
        completeLevelUI.SetActive(true);
    }

    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
