using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajaTexto : MonoBehaviour
{
    public string TextoActual;
    public Text textaco;
    public bool ShowingText;
    public Color CloseColor;
    public Color OpenColor;
    public Transform transformer;
    public Image Transition;

    public void Start()
    {
        transformer.localScale = new Vector3(0, 0, 0);
        transformer.GetComponent<Image>().color = CloseColor;
        CloseText();
    }

    public void OpenText(string TextoAmostrar, float velocidadLetras, float DesirezSize, float initialSize)
    {
        StartCoroutine(AddText(TextoAmostrar, velocidadLetras, DesirezSize, initialSize));
        StartCoroutine(ChangeSize(1, CloseColor, OpenColor, 1, transformer.localScale.magnitude, 0));
    }
    public void CloseText()
    {
        StopAllCoroutines(); 
        StartCoroutine(ChangeSize(0, OpenColor, CloseColor, 1, transformer.localScale.magnitude, 0));
        textaco.text = ""; 
    }


    public IEnumerator AddText(string Texte, float TextoSpeed, float DesiredSize, float InitialSize)
    {
        TextoActual = Texte;
        textaco.text = "";

        foreach (char c in TextoActual.ToCharArray())
        {
            textaco.text += c;
            yield return new WaitForSeconds(TextoSpeed);
        }

        ShowingText = false;
        StopCoroutine(ChangeSize(DesiredSize, CloseColor, OpenColor, 5, InitialSize, 0));
        yield return null;
    }

    public IEnumerator ChangeSize(float Size, Color ColorFrom, Color Color, float duration, float InitialSize, float actualDuration)
    {
        actualDuration = 0;
        for (actualDuration = 0; actualDuration < duration; actualDuration += Time.deltaTime*2)
        {
            transformer.localScale = Vector3.Lerp(new Vector3(InitialSize, InitialSize, InitialSize), new Vector3(Size, Size, Size), actualDuration);
            transformer.GetComponent<Image>().color = Color.Lerp(ColorFrom, Color, actualDuration);
            yield return null;
        }
    }

    public IEnumerator DoTransition(Color ColorFrom, Color Color, float duration)
    {
        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            Transition.GetComponent<Image>().color = Color.Lerp(ColorFrom, Color, i);
            yield return null;
        }
    }
}
