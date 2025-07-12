using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils.ClassUtility;

public class LifeTackController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public LifeTackData lifeTackData;
    public Image lineImage;
    public TackToolTip tackToolTip;

    public Sprite successLine;

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

                TackManager.Instance.currentLifeTach++;
                lineImage.sprite = successLine;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tackToolTip.ShowToolTip(transform.position, lifeTackData.Tack, lifeTackData.Point.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tackToolTip.HideToolTip();
    }
}