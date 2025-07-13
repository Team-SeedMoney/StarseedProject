using System.Collections.Generic;
using UnityEngine;
using Utils.ClassUtility;
using DG.Tweening;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance { get { return instance; } }

    private JSONParser parser;
    public List<EventData> eventData;
    public bool[] isExperience = new bool[20];

    public Sprite[] eventSprites;
    public GameObject eventImage;
    public Image eventSprite;
    public int currentEventIndex = 0;

    public CanvasGroup canvasGroup;
    public Button eventButton;

    public bool isEventFinish = false;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Start()
    {
        parser = GameObject.Find("JSONParser").GetComponent<JSONParser>();
        eventData = parser.LoadEventDataFromJSON();
    }

    private void Update()
    {
        if (UIManager.Instance.tackObject.activeSelf || GameManager.Instance.isEnding)
            return;

        EventHanlder();
    }

    public void EventHanlder()
    {
        if (StatusManager.Instance.Life >= 10 && !isEventFinish)
        {
            currentEventIndex = 0;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }          
        }
        if (StatusManager.Instance.Life >= 30 && !isEventFinish)
        {
            currentEventIndex = 1;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 50 && !isEventFinish)
        {
            currentEventIndex = 2;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 70 && !isEventFinish)
        {
            currentEventIndex = 3;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Technology >= 10 && !isEventFinish)
        {
            currentEventIndex = 4;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Technology >= 30 && !isEventFinish)
        {
            currentEventIndex = 5;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Technology >= 50 && !isEventFinish)
        {
            currentEventIndex = 6;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Technology >= 70 && !isEventFinish)
        {
            currentEventIndex = 7;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Religion >= 30 && !isEventFinish)
        {
            currentEventIndex = 8;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Religion >= 50 && !isEventFinish)
        {
            currentEventIndex = 9;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Culture >= 10 && !isEventFinish)
        {
            currentEventIndex = 10;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Culture >= 30 && !isEventFinish)
        {
            currentEventIndex = 11;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Culture >= 50 && !isEventFinish)
        {
            currentEventIndex = 12;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 30 && StatusManager.Instance.Technology >= 150 && !isEventFinish)
        {
            currentEventIndex = 13;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 70 && StatusManager.Instance.Technology >= 70 && !isEventFinish)
        {
            currentEventIndex = 14;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Technology >= 40 && StatusManager.Instance.Culture >= 20 && !isEventFinish)
        {
            currentEventIndex = 15;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Religion >= 40 && StatusManager.Instance.Culture >= 40 && !isEventFinish)
        {
            currentEventIndex = 16;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 20 && StatusManager.Instance.Religion >= 30 && !isEventFinish)
        {
            currentEventIndex = 17;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 20 && StatusManager.Instance.Technology >= 40 && !isEventFinish)
        {
            currentEventIndex = 18;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
        if (StatusManager.Instance.Life >= 10 && StatusManager.Instance.Technology >= 40 && StatusManager.Instance.Religion >= 30 && !isEventFinish)
        {
            currentEventIndex = 19;
            if (!isExperience[currentEventIndex])
            {
                StartEvent();
                Debug.Log(currentEventIndex);
                return;
            }
        }
    }

    public void StartEvent()
    {
        isEventFinish = true;
        isExperience[currentEventIndex] = true;
        AudioManager.Instance.PlayBGM(currentEventIndex+1);

        eventSprite.sprite = eventSprites[currentEventIndex];
        UIManager.Instance.eventTitle.text = eventData[currentEventIndex].Title;
        UIManager.Instance.dialogText.text = eventData[currentEventIndex].Dialog;
        JournalManager.Instance.OnContantCreate(UIManager.Instance.eventTitle.text, true);
        EventEnable();
    }

    public void OnEvent()
    {
        var seq = DOTween.Sequence();
        seq.Append(eventImage.transform.DOScale(0.95f, 0.1f));
        seq.Append(eventImage.transform.DOScale(1.05f, 0.1f));
        seq.Append(eventImage.transform.DOScale(1.0f, 0.1f));
    }

    public void EventEnable()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void EventDisable()
    {
        Debug.Log("Disable");
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        AudioManager.Instance.PlayBGM(0);
    }
}