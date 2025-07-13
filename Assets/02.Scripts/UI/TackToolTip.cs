using UnityEngine;
using UnityEngine.UI;

public class TackToolTip : MonoBehaviour
{
    public GameObject toolTipBase;
    public Text descriptionText;
    public Text pointText;

    public void ShowToolTip(Vector3 _pos, string _des, string _point)
    {
        toolTipBase.SetActive(true);

        _pos += new Vector3(toolTipBase.GetComponent<RectTransform>().rect.width * 0.45f,
                            -toolTipBase.GetComponent<RectTransform>().rect.height * 0.45f,
                            0);

        toolTipBase.transform.position = _pos;
        descriptionText.fontSize = 30;
        descriptionText.text = _des;
        pointText.text = _point + " Point";
    }

    public void ShowMainToolTip(Vector3 _pos, string _des)
    {
        toolTipBase.SetActive(true);

        _pos += new Vector3(toolTipBase.GetComponent<RectTransform>().rect.width * 0.45f,
                            -toolTipBase.GetComponent<RectTransform>().rect.height * 0.45f,
                            0);

        toolTipBase.transform.position = _pos;
        descriptionText.fontSize = 50;
        descriptionText.text = _des;
        pointText.text = "";
    }

    public void HideToolTip()
    {
        toolTipBase.SetActive(false);
    }
}