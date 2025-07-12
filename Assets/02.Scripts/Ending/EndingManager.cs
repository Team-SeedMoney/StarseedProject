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
            // 1. ������ ����
            endingNum = 1;
        }
        else if(StatusManager.Instance.Life >= 70 && StatusManager.Instance.Technology <= 40)
        {
            // 2. ���� �����
            endingNum = 2;
        }
        else if(StatusManager.Instance.Technology >= 50 && 
            StatusManager.Instance.Life < 10 &&
            StatusManager.Instance.Religion < 10 &&
            StatusManager.Instance.Culture < 10)
        {
            // 3. ����� ����
            endingNum = 3;
        }
        else if(StatusManager.Instance.Technology >= 50 && StatusManager.Instance.Religion >= 50)
        {
            // 4. ������ ��ȭ
            endingNum = 4;
        }
        else if(StatusManager.Instance.Technology >= 90)
        {
            // 5. ���� ��ô
            endingNum = 5;
        }
        else if(StatusManager.Instance.Religion >= 70 && 
            StatusManager.Instance.Life >= 40 && 
            StatusManager.Instance.Culture >= 40)
        {
            // 6. ���� ����
            endingNum = 6;
        }
        else if(StatusManager.Instance.Religion >= 40 &&
            StatusManager.Instance.Culture >= 60 &&
            StatusManager.Instance.Technology >= 50)
        {
            // 7. ���� ������
            endingNum = 7;
        }
        else if(StatusManager.Instance.Culture >= 70 && StatusManager.Instance.Life <= 30)
        {
            // 8. ����� �ڹ���
            endingNum = 8;
        }
        else if(StatusManager.Instance.Culture >= 50 && 
            StatusManager.Instance.Life >= 40 && 
            StatusManager.Instance.Technology >= 40 &&
            StatusManager.Instance.Religion >= 40)
        {
            // 9. ��ȭ Ȳ�ݱ�
            endingNum = 9;
        }
    }

    public void OnEnding()
    {
        endingObject.SetActive(true);
        GameManager.Instance.isEnding = true;
    }
}
