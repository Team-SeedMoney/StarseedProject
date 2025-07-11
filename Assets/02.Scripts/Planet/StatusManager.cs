using UnityEngine;

public class StatusManager : MonoBehaviour
{
    private static StatusManager instance;
    public static StatusManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }
}