using System.Collections;
using UnityEngine;

public class UIPopUpMovement : MonoBehaviour
{
    public RectTransform rectTransform;
    public Vector2 targetPosition;
    public float duration = 1.0f;
    private void Start()
    {
        StartMovement();
    }
    public void StartMovement()
    {
        StartCoroutine(MoveUI());
    }

    IEnumerator MoveUI()
    {
        yield return new WaitForSeconds(5f);
        Vector2 startPos = rectTransform.anchoredPosition;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, targetPosition, timeElapsed / duration);
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
    }
}
