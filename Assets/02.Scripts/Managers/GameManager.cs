using System.Collections.Generic;
using UnityEngine;
using Utils.ClassUtility;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private JSONParser parser;
    public List<PepolePointData> pointDatas;

    public int days = 1;
    public int point = 100;
    public int pepole = 1000;

    private float currentDayTime = 0;
    private float dayTimeLimit = 20.0f;
    private float currentPepoleTime = 0;
    private float pepoleTimeLimit = 10.0f;
    private float currentPointTime = 0;
    private float getPointTime = 2.0f;

    public bool isEnding = false;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        Application.targetFrameRate = 65;
    }

    private void Start()
    {
        parser = GameObject.Find("JSONParser").GetComponent<JSONParser>();
        pointDatas = parser.LoadPepolePpointFromJSON();
    }

    private void Update()
    {
        if (!isEnding)
            return;

        DayHandler();
        PepoleHandler();
        GetPoint();
    }

    public void DayHandler()
    {
        if(currentDayTime >= dayTimeLimit)
        {
            currentDayTime = 0;
            days += 1;
            UIManager.Instance.ChangeDayText();
        }
        else
        {
            currentDayTime += Time.deltaTime;
        }
    }

    public void PepoleHandler()
    {
        if (currentPepoleTime >= pepoleTimeLimit)
        {
            for (int i = 1; i < pointDatas.Count; i++)
            {
                if (pepole < pointDatas[i].Pepole)
                {
                    if(pointDatas[i].Life <= StatusManager.Instance.Life)
                    {
                        currentPepoleTime = 0;
                        pepole += 10000;
                        UIManager.Instance.ChangePepoleText();
                        return;
                    }
                }
            }
            currentPepoleTime = 0;
        }
        else
        {
            currentPepoleTime += Time.deltaTime;
        }
    }

    public void GetPoint()
    {
        if(currentPointTime >= getPointTime)
        {
            currentPointTime = 0;

            for(int i = 1; i < pointDatas.Count; i++)
            {
                if(pepole < pointDatas[i].Pepole)
                {
                    point += pointDatas[i - 1].GetPoint;
                    UIManager.Instance.ChangePointText();
                    return;
                }            
            }
        }
        else
        {
            currentPointTime += Time.deltaTime;
        }
    }
}