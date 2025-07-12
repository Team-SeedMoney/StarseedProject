using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class CultureController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CultureTackData cultureTackData;
    public Image lineImage;
    public TackToolTip tackToolTip;

    public Sprite successLine;

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

                TackManager.Instance.currentCultureTack++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tackToolTip.ShowToolTip(transform.position, cultureTackData.Tack, cultureTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tackToolTip.HideToolTip();
    }
}
