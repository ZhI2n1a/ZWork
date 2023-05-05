using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectManager : MonoBehaviour
{
    public void SelectScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
}