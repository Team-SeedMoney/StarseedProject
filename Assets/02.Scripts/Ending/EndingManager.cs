using UnityEngine;

public class EndingManager : MonoBehaviour
{
    private static EndingManager instance;
    public static EndingManager Instance {  get { return instance; } }

    public int endingNum;
    public string[] endingTitles;
    public string[] endingDescriptions;

    public GameObject endingObject;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Update()
    {
        if(StatusManager.Instance.Life >= 70 &&
            StatusManager.Instance.Technology >= 40 && 
            StatusManager.Instance.Religion >= 40 && 
            StatusManager.Instance.Culture >= 40)
        {
            // 1. 생명의 낙원
            endingNum = 1;
        }
        else if(StatusManager.Instance.Life >= 70 && StatusManager.Instance.Technology <= 40)
        {
            // 2. 유기 대재앙
            endingNum = 2;
        }
        else if(StatusManager.Instance.Technology >= 50 && 
            StatusManager.Instance.Life < 10 &&
            StatusManager.Instance.Religion < 10 &&
            StatusManager.Instance.Culture < 10)
        {
            // 3. 기계의 폭주
            endingNum = 3;
        }
        else if(StatusManager.Instance.Technology >= 50 && StatusManager.Instance.Religion >= 50)
        {
            // 4. 디지털 신화
            endingNum = 4;
        }
        else if(StatusManager.Instance.Technology >= 90)
        {
            // 5. 우주 개척
            endingNum = 5;
        }
        else if(StatusManager.Instance.Religion >= 70 && 
            StatusManager.Instance.Life >= 40 && 
            StatusManager.Instance.Culture >= 40)
        {
            // 6. 신의 출현
            endingNum = 6;
        }
        else if(StatusManager.Instance.Religion >= 40 &&
            StatusManager.Instance.Culture >= 60 &&
            StatusManager.Instance.Technology >= 50)
        {
            // 7. 거짓 선지자
            endingNum = 7;
        }
        else if(StatusManager.Instance.Culture >= 70 && StatusManager.Instance.Life <= 30)
        {
            // 8. 기억의 박물관
            endingNum = 8;
        }
        else if(StatusManager.Instance.Culture >= 50 && 
            StatusManager.Instance.Life >= 40 && 
            StatusManager.Instance.Technology >= 40 &&
            StatusManager.Instance.Religion >= 40)
        {
            // 9. 문화 황금기
            endingNum = 9;
        }
    }

    public void OnEnding()
    {
        endingObject.SetActive(true);
        GameManager.Instance.isEnding = true;
    }
}
