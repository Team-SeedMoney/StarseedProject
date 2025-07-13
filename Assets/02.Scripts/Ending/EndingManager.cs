using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    private static EndingManager instance;
    public static EndingManager Instance {  get { return instance; } }

    public int endingNum;
    public string[] endingTitles;
    public string[] endingDescriptions;
    public Sprite[] endingPlanetSprites;

    public GameObject endingObject;
    public Text endingTitleText;
    public Text endingDescriptionText;
    public Image planetImage;

    public GameObject tackObject;
    public GameObject jounalyObject;
    public GameObject DescriptionObject;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.isEnding)
            return;

        if (StatusManager.Instance.Life >= 70 &&
            StatusManager.Instance.Technology >= 40 && 
            StatusManager.Instance.Religion >= 40 && 
            StatusManager.Instance.Culture >= 40)
        {
            // 1. 생명의 낙원
            endingNum = 0;
            OnEnding();
        }
        else if(StatusManager.Instance.Life >= 70 && StatusManager.Instance.Technology <= 40)
        {
            // 2. 유기 대재앙
            endingNum = 1;
            OnEnding();
        }
        else if(StatusManager.Instance.Technology >= 50 && 
            StatusManager.Instance.Life < 10 &&
            StatusManager.Instance.Religion < 10 &&
            StatusManager.Instance.Culture < 10)
        {
            // 3. 기계의 폭주
            endingNum = 2;
            OnEnding();
        }
        else if(StatusManager.Instance.Technology >= 50 && StatusManager.Instance.Religion >= 50)
        {
            // 4. 디지털 신화
            endingNum = 3;
            OnEnding();
        }
        else if(StatusManager.Instance.Technology >= 90)
        {
            // 5. 우주 개척
            endingNum = 4;
            OnEnding();
        }
        else if(StatusManager.Instance.Religion >= 70 && 
            StatusManager.Instance.Life >= 40 && 
            StatusManager.Instance.Culture >= 40)
        {
            // 6. 신의 출현
            endingNum = 5;
            OnEnding();
        }
        else if(StatusManager.Instance.Religion >= 40 &&
            StatusManager.Instance.Culture >= 60 &&
            StatusManager.Instance.Technology >= 50)
        {
            // 7. 거짓 선지자
            endingNum = 6;
            OnEnding();
        }
        else if(StatusManager.Instance.Culture >= 70 && StatusManager.Instance.Life <= 30)
        {
            // 8. 기억의 박물관
            endingNum = 7;
            OnEnding();
        }
        else if(StatusManager.Instance.Culture >= 50 && 
            StatusManager.Instance.Life >= 40 && 
            StatusManager.Instance.Technology >= 40 &&
            StatusManager.Instance.Religion >= 40)
        {
            // 9. 문화 황금기
            endingNum = 8;
            OnEnding();
        }
    }

    public void OnEnding()
    {
        tackObject.SetActive(false);
        jounalyObject.SetActive(false);
        DescriptionObject.SetActive(false);

        endingObject.SetActive(true);
        planetImage.sprite = endingPlanetSprites[endingNum];
        endingTitleText.text = endingTitles[endingNum];
        endingDescriptionText.text = endingDescriptions[endingNum];
        GameManager.Instance.isEnding = true;
    }
}