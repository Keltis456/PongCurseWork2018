using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text player01ScoreText;
    public Text player02ScoreText;

    private int playerScore01;
    private int playerScore02;

#region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
#endregion
    
    void Start () {
        player01ScoreText.text = playerScore01.ToString();
        player02ScoreText.text = playerScore02.ToString();
    }

    public void Score(string wallName)
    {
        if (wallName == "rightWall")
        {
            playerScore01++;
        }
        else
        {
            playerScore02++;
        }
        player01ScoreText.text = playerScore01.ToString();
        player02ScoreText.text = playerScore02.ToString();
    }
}
