using System.Collections.Generic;
using UnityEngine;

namespace Utils.ClassUtility
{
    public class LifeTackDataList
    {
        public List<LifeTackData> Life;
    }

    [System.Serializable]
    public class LifeTackData
    {
        public int Index;
        public string Tack;
        public int Point;
        public int GetPoint;
        public int Life;
        public int Technology;
        public int Religion;
        public int Culture;
    }

    public class TechnologyTackDataList
    {
        public List<TechnologyTackData> Technology;
    }

    [System.Serializable]
    public class TechnologyTackData
    {
        public int Index;
        public string Tack;
        public int Point;
        public int GetPoint;
        public int Life;
        public int Technology;
        public int Religion;
        public int Culture;
    }

    public class ReligionTackDataList
    {
        public List<ReligionTackData> Religion;
    }

    [System.Serializable]
    public class ReligionTackData
    {
        public int Index;
        public string Tack;
        public int Point;
        public int GetPoint;
        public int Life;
        public int Technology;
        public int Religion;
        public int Culture;
    }

    public class CultureTackDataList
    {
        public List<CultureTackData> Culture;
    }

    public class CultureTackData
    {
        public int Index;
        public string Tack;
        public int Point;
        public int GetPoint;
        public int Life;
        public int Technology;
        public int Religion;
        public int Culture;
    }
}
