using System.Collections;
using UnityEngine;

public class FadingBlock : MonoBehaviour
{
    public float timer = 3.0f;
    public float fadeDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Collider2D blockCollider;
    private Color baseColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        blockCollider = GetComponent<Collider2D>();
        baseColor = spriteRenderer.color;
        StartCoroutine(LifecycleRoutine());
    }

    private IEnumerator LifecycleRoutine()
    {
        while (true)
        {
            // 显示
            SetAlpha(1f);
            if (blockCollider) blockCollider.enabled = true;
            yield return new WaitForSeconds(timer);

            // 淡出
            yield return FadeTo(0f);
            if (blockCollider) blockCollider.enabled = false;

            // 隐形
            yield return new WaitForSeconds(timer);

            // 淡入
            yield return FadeTo(1f);
        }
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = spriteRenderer.color.a;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SetAlpha(targetAlpha);
    }

    private void SetAlpha(float alpha)
    {
        Color c = baseColor;
        c.a = alpha;
        spriteRenderer.color = c;
    }
}
