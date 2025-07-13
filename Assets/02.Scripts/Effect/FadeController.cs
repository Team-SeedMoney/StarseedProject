using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    // 인스펙터에서 수정할 값.
    [SerializeField] private Image blackBack;
    [SerializeField] private float time = 1.0f;

    // 실제 Static 메소드에서 사용할 값.
    static private Image BlackBack;
    static private float Time;

    private void Start()
    {
        BlackBack.DOFade(0, 2.0f);
    }
}