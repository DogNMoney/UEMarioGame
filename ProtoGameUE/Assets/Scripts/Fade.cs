using System.Collections;
using UnityEngine;
using UnityEngine.UI;
class Fade : MonoBehaviour
{

    public float fadeOutTime = 1000;
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        Text text = GetComponent<Text>();
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }

    private void Start()
    {
        FadeOut();
    }
}