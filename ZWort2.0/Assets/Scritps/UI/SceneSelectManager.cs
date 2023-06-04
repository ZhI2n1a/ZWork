using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectManager : MonoBehaviour
{
    public static void SelectScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
        if (numberScene == 1)
            enemyCount.enemy = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}