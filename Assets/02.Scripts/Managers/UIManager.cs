using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance {  get { return instance; } }

    public Text pepoleText;
    public Text pointText;
    private Text dayText;

    private Text lifeStatusText;
    private Text technologyStatusText;
    private Text religionStatusText;
    private Text cultureStatusText;

    public Slider lifeSlider;
    public Slider technologySlider;
    public Slider religionSlider;
    public Slider cultureSlider;

    public GameObject tackButton;
    public GameObject tackObject;
    public GameObject eventDialog;
    public Image eventImage;
    public Text eventTitle;
    public Text dialogText;

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
        lifeStatusText = lifeSlider.GetComponentInChildren<Text>();
        technologyStatusText = technologySlider.GetComponentInChildren<Text>();
        religionStatusText = religionSlider.GetComponentInChildren<Text>();
        cultureStatusText = cultureSlider.GetComponentInChildren<Text>();

        ChangePepoleText();
        ChangePointText();
        ChangeStatusText();
        ChangeStatusSlider();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            tackObject.SetActive(false);
        }
    }

    public void ChangeDayText()
    {
        dayText.text = GameManager.Instance.days + " ÀÏÂ÷";
    }

    public void ChangePepoleText()
    {
        pepoleText.text = string.Format("{0:#,###}", GameManager.Instance.pepole);
    }

    public void ChangePointText()
    {
        pointText.text = GameManager.Instance.point.ToString();
    }

    public void ChangeStatusText()
    {
        lifeStatusText.text = (StatusManager.Instance.Life).ToString() + "%";
        technologyStatusText.text = (StatusManager.Instance.Technology).ToString() + "%";
        religionStatusText.text = (StatusManager.Instance.Religion).ToString() + "%";
        cultureStatusText.text = (StatusManager.Instance.Culture).ToString() + "%";
    }

    public void ChangeStatusSlider()
    {
        lifeSlider.value = StatusManager.Instance.Life / 100;
        technologySlider.value = StatusManager.Instance.Technology / 100;
        religionSlider.value = StatusManager.Instance.Religion / 100;
        cultureSlider.value = StatusManager.Instance.Culture / 100;
    }

    public void ButtonAction(GameObject _object)
    {
        var seq = DOTween.Sequence();
        seq.Append(_object.transform.DOScale(0.95f, 0.1f));
        seq.Append(_object.transform.DOScale(1.05f, 0.1f));
        seq.Append(_object.transform.DOScale(1.0f, 0.1f));
    }

    public void OnEventActive()
    {
        EventManager.Instance.isEventFinish = false;
    }
}
