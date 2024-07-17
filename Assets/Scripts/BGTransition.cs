using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGTransition : MonoBehaviour
{
    private Image bg;
    private Color originalColor;

    private void Awake()
    {
        bg = GetComponent<Image>();
        originalColor = bg.color; // Guardar el color original
    }

    public void Transition(Sprite newSprite)
    {
        // Iniciar la transición a negro, cambiar el sprite y volver a la nueva imagen
        StartCoroutine(TransitionCoroutine(newSprite));
    }

    private IEnumerator TransitionCoroutine(Sprite newSprite)
    {
        // Cambiar el color a negro
        yield return StartCoroutine(ChangeColorImg(true, 1f));

        // Cambiar el sprite
        bg.sprite = newSprite;

        // Volver al color original
        yield return StartCoroutine(ChangeColorImg(false, 0.8f));
    }

    private IEnumerator ChangeColorImg(bool toBlack, float speed)
    {
        Color targetColor = toBlack ? Color.black : originalColor;
        Color startColor = bg.color;

        float elapsedTime = 0f;
        while (elapsedTime < speed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / speed);
            bg.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        // Asegurarse de que el color final es el esperado
        bg.color = targetColor;
    }
}
