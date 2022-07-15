using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLoader : MonoBehaviour
{
    private const int _gameScene = 0;

    public void LoadGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_gameScene);
    }
}
