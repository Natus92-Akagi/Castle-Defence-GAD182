using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject playerScore;
    Text playerScoreText;
    public static int playerCurrentScore;

    void Start()
    {
        //UI Elements
        playerScoreText = playerScore.GetComponent<Text>();
        playerCurrentScore = 0;
    }

    void Update()
    {
        playerScoreText.text = "SCORE: " + playerCurrentScore;
    }
}
