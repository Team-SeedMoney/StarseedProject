using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class CultureController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CultureTackData cultureTackData;
    public Image outImage;
    public Image mainLineImage;
    public Image lineImage;
    public TackToolTip tackToolTip;

    public Sprite successLine;
    public bool isMain = false;

    public void OnNextTach()
    {
        if (TackManager.Instance.currentCultureTack == cultureTackData.Index)
        {
            if (cultureTackData.Point <= GameManager.Instance.point)
            {
                JournalManager.Instance.OnContantCreate(cultureTackData.Tack, false);
                GameManager.Instance.point -= cultureTackData.Point;
                GameManager.Instance.point += cultureTackData.GetPoint;
                UIManager.Instance.ChangePointText();

                StatusManager.Instance.ChangeLifeStatus(cultureTackData.Life);
                StatusManager.Instance.ChangeTechnologyStatus(cultureTackData.Technology);
                StatusManager.Instance.ChangeReligionStatus(cultureTackData.Religion);
                StatusManager.Instance.ChangeCultureStatus(cultureTackData.Culture);

                mainLineImage.color = new Color(255, 0, 245);
                TackManager.Instance.currentCultureTack++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnTackSelect()
    {
        outImage.color = new Color(255, 0, 245);
    }

    public void OnTackDeSelect()
    {
        outImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.ShowToolTip(transform.position, cultureTackData.Tack, cultureTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.HideToolTip();
    }

    public void OnMainTackSelect()
    {
        tackToolTip.ShowMainToolTip(transform.position, "¹®È­");
    }

    public void OnMainTachExit()
    {
        tackToolTip.HideToolTip();
    }
}