using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance {  get { return instance; } } 

    private Text dayText;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Start()
    {
        dayText = GameObject.Find("DayText").GetComponent<Text>();
    }

    public void ChangeDayText()
    {
        dayText.text = GameManager.Instance.days + " ÀÏÂ÷";
    }
}
