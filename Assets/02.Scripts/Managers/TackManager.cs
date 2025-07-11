using System.Collections.Generic;
using UnityEngine;
using Utils.ClassUtility;

public class TackManager : MonoBehaviour
{
    private static TackManager instance;
    public static TackManager Instance {  get { return instance; } }

    private JSONParser parser;
    public List<LifeTackData> lifeTackData;
    private List<TechnologyTackData> technologyTackData;
    private List<ReligionTackData> religionTackData;
    private List<CultureTackData> cultureTackData;

    public List<LifeTackController> lifeTackControllers;

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

        LifeTechHandler();
    }

    public void LifeTechHandler()
    {
        for(int i = 0; i < lifeTackControllers.Count; i++)
        {
            lifeTackControllers[i].lifeTackData = lifeTackData[i];
        }
    }
}
