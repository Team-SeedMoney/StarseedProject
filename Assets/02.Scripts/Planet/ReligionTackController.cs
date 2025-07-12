using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class ReligionTackController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ReligionTackData religionTackData;
    public Image lineImage;
    public TackToolTip tackToolTip;

    public Sprite successLine;

    public void OnNextTach()
    {
        if (TackManager.Instance.currentReligionTack == religionTackData.Index)
        {
            if (religionTackData.Point <= GameManager.Instance.point)
            {
                JournalManager.Instance.OnContantCreate(religionTackData.Tack, false);
                GameManager.Instance.point -= religionTackData.Point;
                GameManager.Instance.point += religionTackData.GetPoint;
                UIManager.Instance.ChangePointText();

                StatusManager.Instance.ChangeLifeStatus(religionTackData.Life);
                StatusManager.Instance.ChangeTechnologyStatus(religionTackData.Technology);
                StatusManager.Instance.ChangeReligionStatus(religionTackData.Religion);
                StatusManager.Instance.ChangeCultureStatus(religionTackData.Culture);

                TackManager.Instance.currentReligionTack++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tackToolTip.ShowToolTip(transform.position, religionTackData.Tack, religionTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tackToolTip.HideToolTip();
    }
}
