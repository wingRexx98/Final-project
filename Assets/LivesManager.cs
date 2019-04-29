using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public static int livesCounter;
    public static int livesAtStart = 3;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        livesCounter = livesAtStart;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "x " + livesCounter;
    }

    public static void loseLife()
    {
        if (livesAtStart > 0)
        {
            livesAtStart--;
        }
        else if(livesAtStart == 0)
        {
            Debug.Log("dead");
            SceneManager.LoadScene(0);
            livesAtStart = 3;
        }
    }
}
