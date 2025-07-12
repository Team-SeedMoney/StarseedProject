using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    private static JournalManager instance;
    public static JournalManager Instance {  get { return instance; } }

    public GameObject contantPrefab;
    public GameObject spawnParent;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void OnContantCreate(string _text, bool _isEvent)
    {
        GameObject _contant = Instantiate(contantPrefab, spawnParent.transform);

        if (_isEvent )
        {
            _contant.transform.GetChild(0).GetComponent<Text>().text = "";
            _contant.transform.GetChild(1).GetComponent<Text>().text = _text;
            _contant.transform.GetChild(1).GetComponent<Text>().color = Color.red;
        }
        else
        {
            _contant.transform.GetChild(0).GetComponent<Text>().text = GameManager.Instance.days + " ÀÏÂ÷";
            _contant.transform.GetChild(1).GetComponent<Text>().text = _text;
        }
    }
}