using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class ReStartScene : MonoBehaviour
{
    public GameTimer gameTimer;
    public void RestartScene()
    {
        RestartGame();
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        StopAllCoroutines();
        gameTimer.elapsedTime = 0f;
        gameTimer.timerStarted = false;
        gameTimer.countdownCoroutine = null;
    }
}
