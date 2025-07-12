using UnityEngine;

public class StatusManager : MonoBehaviour
{
    private static StatusManager instance;
    public static StatusManager Instance { get { return instance; } }

    public float Life = 0.0f;
    public float Technology = 0.0f;
    public float Religion = 0.0f;
    public float Culture = 0.0f;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    public void ChangeLifeStatus(float _status)
    {
        if (_status + Life >= 100)
            Life = 100;
        else if (_status + Life <= 0)
            Life = 0;
        else
            Life += _status;

        UIManager.Instance.ChangeStatusText();
        UIManager.Instance.ChangeStatusSlider();
    }

    public void ChangeTechnologyStatus(float _status)
    {
        if (_status + Technology >= 100)
            Technology = 100;
        else if (_status + Life <= 0)
            Technology = 0;
        else
            Technology += _status;

        UIManager.Instance.ChangeStatusText();
        UIManager.Instance.ChangeStatusSlider();
    }

    public void ChangeReligionStatus(float _status)
    {
        if (_status + Religion >= 100)
            Religion = 100;
        else if (_status + Life <= 0)
            Religion = 0;
        else
            Religion += _status;

        UIManager.Instance.ChangeStatusText();
        UIManager.Instance.ChangeStatusSlider();
    }

    public void ChangeCultureStatus(float _status)
    {
        if (_status + Culture >= 100)
            Culture = 100;
        else if (_status + Life <= 0)
            Culture = 0;
        else
            Culture += _status;

        UIManager.Instance.ChangeStatusText();
        UIManager.Instance.ChangeStatusSlider();
    }
}