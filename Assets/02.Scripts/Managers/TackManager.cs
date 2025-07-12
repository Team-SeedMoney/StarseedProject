using System.Collections.Generic;
using UnityEngine;
using Utils.ClassUtility;

public class TackManager : MonoBehaviour
{
    private static TackManager instance;
    public static TackManager Instance {  get { return instance; } }

    private JSONParser parser;
    public List<LifeTackData> lifeTackData;
    public List<TechnologyTackData> technologyTackData;
    public List<ReligionTackData> religionTackData;
    public List<CultureTackData> cultureTackData;

    public List<LifeTackController> lifeTackControllers;
    public List<TechnologyTackController> technologyTackControllers;
    public List<ReligionTackController> religionTackControllers;
    public List<CultureController> cultureTackControllers;

    public int currentLifeTach = 1;
    public int currentTechnologyTach = 1;
    public int currentReligionTack = 1;
    public int currentCultureTack = 1;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        parser = GameObject.Find("JSONParser").GetComponent<JSONParser>();
        lifeTackData = parser.LoadLifeDataFromJSON();
        technologyTackData = parser.LoadTechnologyDataFromJSON();
        religionTackData = parser.LoadReligionDataFromJSON();
        cultureTackData = parser.LoadCultureDataFromJSON();

        LifeTachHandler();
        TechnologyTackHandler();
        ReligionTachHandler();
        CultureTackHandler();
    }

    public void LifeTachHandler()
    {
        for(int i = 0; i < lifeTackControllers.Count; i++)
        {
            lifeTackControllers[i].lifeTackData = lifeTackData[i];
        }
    }

    public void TechnologyTackHandler()
    {
        for (int i = 0; i < technologyTackControllers.Count; i++)
        {
            technologyTackControllers[i].technologyTackData = technologyTackData[i];
        }
    }

    public void ReligionTachHandler()
    {
        for(int i = 0; i  < religionTackControllers.Count; i++)
        {
            religionTackControllers[i].religionTackData = religionTackData[i];
        }
    }

    public void CultureTackHandler()
    {
        for(int i = 0; i < cultureTackControllers.Count; i++)
        {
            cultureTackControllers[i].cultureTackData = cultureTackData[i];
        }
    }
}