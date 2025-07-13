using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class ReligionTackController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ReligionTackData religionTackData;
    public Image outImage;
    public Image mainLineImage;
    public Image lineImage;
    public TackToolTip tackToolTip;

    public Sprite successLine;
    public bool isMain = false;

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

                mainLineImage.color = Color.blue;
                TackManager.Instance.currentReligionTack++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnTackSelect()
    {
        outImage.color = Color.blue;
    }

    public void OnTackDeSelect()
    {
        outImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.ShowToolTip(transform.position, religionTackData.Tack, religionTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.HideToolTip();
    }

    public void OnMainTackSelect()
    {
        tackToolTip.ShowMainToolTip(transform.position, "Á¾±³");
    }

    public void OnMainTachExit()
    {
        tackToolTip.HideToolTip();
    }
}
