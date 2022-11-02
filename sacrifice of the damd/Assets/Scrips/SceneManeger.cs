using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    [SerializeField]
    string startScene;

    public static int playerHealth;

    private void Awake()
    {
        if (SceneManager.GetSceneByName(startScene) == SceneManager.GetActiveScene())
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().maxHealth;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(startScene);
    }

    public void NextLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
