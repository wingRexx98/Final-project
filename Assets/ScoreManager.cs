using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int points;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (points < 0)
            points = 0;
        text.text = "" + points;
    }

    public static void AddPoints( int score)
    {
        points += score;
    }

    public static void Reset()
    {
        points = 0;
    }

}
