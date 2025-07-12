using Unity.VisualScripting;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    public Vector2 direction = new Vector2(1f, -1f); // 사선 방향 (오른쪽 아래)
    public float speed = 100f;                       // 속도
    private RectTransform rectTransform;
    private Vector2 startPos;
    public float resetY = -200f;                     // 사라지는 위치

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // 시간에 따라 이동
        rectTransform.anchoredPosition += direction.normalized * speed * Time.deltaTime;

        // 화면 아래로 떨어지면 리셋
        if (rectTransform.anchoredPosition.y < resetY)
        {
            rectTransform.anchoredPosition = startPos;
        }
    }
}
