using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TackToolTip : MonoBehaviour
{
    public GameObject toolTipBase;
    public Text descriptionText;
    public Text pointText;

    public void ShowToolTip(Vector3 _pos, string _des, string _point)
    {
        toolTipBase.SetActive(true);

        _pos += new Vector3(toolTipBase.GetComponent<RectTransform>().rect.width * 0.5f,
                            -toolTipBase.GetComponent<RectTransform>().rect.height * 0.5f,
                            0);
        toolTipBase.transform.position = _pos;
        descriptionText.text = _des;
        pointText.text = _point + " Point";
    }

    public void HideToolTip()
    {
        toolTipBase.SetActive(false);
    }
}
