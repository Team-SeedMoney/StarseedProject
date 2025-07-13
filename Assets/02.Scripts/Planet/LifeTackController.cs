using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class LifeTackController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public LifeTackData lifeTackData;
    public Image outImage;
    public Image mainLineImage;
    public Image lineImage;
    public TackToolTip tackToolTip;
    public Sprite successLine;

    public bool isMain = false;

    public void OnNextTach()
    {
        Debug.Log(TackManager.Instance.currentLifeTach + " : " + lifeTackData.Index);
        if (TackManager.Instance.currentLifeTach == lifeTackData.Index)
        {
            if (lifeTackData.Point <= GameManager.Instance.point)
            {
                JournalManager.Instance.OnContantCreate(lifeTackData.Tack, false);
                GameManager.Instance.point -= lifeTackData.Point;
                GameManager.Instance.point += lifeTackData.GetPoint;
                UIManager.Instance.ChangePointText();

                StatusManager.Instance.ChangeLifeStatus(lifeTackData.Life);
                StatusManager.Instance.ChangeTechnologyStatus(lifeTackData.Technology);
                StatusManager.Instance.ChangeReligionStatus(lifeTackData.Religion);
                StatusManager.Instance.ChangeCultureStatus(lifeTackData.Culture);

                mainLineImage.color = Color.green;
                TackManager.Instance.currentLifeTach++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnTackSelect()
    {
        outImage.color = Color.green;
    }

    public void OnTackDeSelect()
    {
        outImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.ShowToolTip(transform.position, lifeTackData.Tack, lifeTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMain)
            return;

        tackToolTip.HideToolTip();
    }

    public void OnMainTackSelect()
    {
        tackToolTip.ShowMainToolTip(transform.position, "»ý¸í");
    }
    
    public void OnMainTachExit()
    {
        tackToolTip.HideToolTip();
    }
}