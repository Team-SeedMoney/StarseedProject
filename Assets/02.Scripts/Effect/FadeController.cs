using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    // �ν����Ϳ��� ������ ��.
    [SerializeField] private Image blackBack;
    [SerializeField] private float time = 1.0f;

    // ���� Static �޼ҵ忡�� ����� ��.
    static private Image BlackBack;
    static private float Time;

    private void Start()
    {
        BlackBack.DOFade(0, 2.0f);
    }
}