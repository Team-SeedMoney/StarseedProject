using System.Collections.Generic;
using UnityEngine;
using Utils.ClassUtility;

public class JSONParser : MonoBehaviour
{
    private string lifeTackDataPath = "JSON/Life";
    private string technologyTackDataPath = "JSON/Technology";
    private string religionTackDataPath = "JSON/Religion";
    private string cultureTackDataPath = "JSON/Culture";

    public List<LifeTackData> LoadLifeDataFromJSON()
    {
        TextAsset loadJson = Resources.Load<TextAsset>(lifeTackDataPath);
        LifeTackDataList tack = JsonUtility.FromJson<LifeTackDataList>(loadJson.text);
        return tack.Life;
    }

    public List<TechnologyTackData> LoadTechnologyDataFromJSON()
    {
        TextAsset loadJson = Resources.Load<TextAsset>(technologyTackDataPath);
        TechnologyTackDataList tack = JsonUtility.FromJson<TechnologyTackDataList>(loadJson.text);
        return tack.Technology;
    }

    public List<ReligionTackData> LoadReligionDataFromJSON()
    {
        TextAsset loadJson = Resources.Load<TextAsset>(religionTackDataPath);
        ReligionTackDataList tack = JsonUtility.FromJson<ReligionTackDataList>(loadJson.text);
        return tack.Religion;
    }

    public List<CultureTackData> LoadCultureDataFromJSON()
    {
        TextAsset loadJson = Resources.Load<TextAsset>(cultureTackDataPath);
        CultureTackDataList tack = JsonUtility.FromJson<CultureTackDataList>(loadJson.text);
        return tack.Culture;
    }
}