using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    public static SceneController Instance {  get { return instance; } }

    public Image gameStartButton;
    public Image gameOverButton;

    public Sprite[] gameButtonSprites;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    public void OnGameStartButton(bool isOn)
    {
        if (isOn)
            gameStartButton.sprite = gameButtonSprites[0];
        else
            gameStartButton.sprite = gameButtonSprites[1];
    }

    public void OnGameOverButton(bool isOn)
    {
        if (isOn)
            gameOverButton.sprite = gameButtonSprites[2];
        else
            gameOverButton.sprite = gameButtonSprites[3];
    }

    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void GameOver()
    {
        Application.Quit();
    }
}
