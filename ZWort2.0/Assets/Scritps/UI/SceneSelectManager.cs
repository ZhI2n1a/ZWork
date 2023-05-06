using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectManager : MonoBehaviour
{
    public static void SelectScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}