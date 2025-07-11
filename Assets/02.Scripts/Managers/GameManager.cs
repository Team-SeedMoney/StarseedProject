using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int days = 1;
    public int point = 100;
    public int pepole = 10;

    private float currentTime = 0;
    private float timeLimit = 20.0f;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        Application.targetFrameRate = 65;
    }

    private void Update()
    {
        DayHandler();
    }

    public void DayHandler()
    {
        if(currentTime >= timeLimit)
        {
            currentTime = 0;
            days += 1;
            UIManager.Instance.ChangeDayText();
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }
}