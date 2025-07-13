using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class TechnologyTackController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TechnologyTackData technologyTackData;
    public Image outImage;
    public Image mainLineImage;
    public Image lineImage;
    public TackToolTip tackToolTip;

    public Sprite successLine;
    public bool isMain = false;

    public void OnNextTach()
    {
        if (TackManager.Instance.currentTechnologyTach == technologyTackData.Index)
        {
            if (technologyTackData.Point <= GameManager.Instance.point)
            {
                JournalManager.Instance.OnContantCreate(technologyTackData.Tack, false);
                GameManager.Instance.point -= technologyTackData.Point;
                GameManager.Instance.point += technologyTackData.GetPoint;
                UIManager.Instance.ChangePointText();

                StatusManager.Instance.ChangeLifeStatus(technologyTackData.Life);
                StatusManager.Instance.ChangeTechnologyStatus(technologyTackData.Technology);
                StatusManager.Instance.ChangeReligionStatus(technologyTackData.Religion);
                StatusManager.Instance.ChangeCultureStatus(technologyTackData.Culture);

                mainLineImage.color = Color.red;
                TackManager.Instance.currentTechnologyTach++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnTackSelect()
    {
        outImage.color = Color.red;
    }

    public void OnTackDeSelect()
    {
        outImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.ShowToolTip(transform.position, technologyTackData.Tack, technologyTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.HideToolTip();
    }

    public void OnMainTackSelect()
    {
        tackToolTip.ShowMainToolTip(transform.position, "±â¼ú");
    }

    public void OnMainTachExit()
    {
        tackToolTip.HideToolTip();
    }
}
