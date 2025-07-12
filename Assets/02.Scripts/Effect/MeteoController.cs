using Unity.VisualScripting;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    public Vector2 direction = new Vector2(1f, -1f); // �缱 ���� (������ �Ʒ�)
    public float speed = 100f;                       // �ӵ�
    private RectTransform rectTransform;
    private Vector2 startPos;
    public float resetY = -200f;                     // ������� ��ġ

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // �ð��� ���� �̵�
        rectTransform.anchoredPosition += direction.normalized * speed * Time.deltaTime;

        // ȭ�� �Ʒ��� �������� ����
        if (rectTransform.anchoredPosition.y < resetY)
        {
            rectTransform.anchoredPosition = startPos;
        }
    }
}
