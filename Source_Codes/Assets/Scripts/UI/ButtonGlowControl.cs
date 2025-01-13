using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonGlowController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text buttonText; // Assign your TextMeshPro text here
    public float normalGlow = 0.1f;
    public float highlightedGlow = 0.6f;
    public float clickedGlow = 0.5f;

    private Material buttonMaterial;

    void Start()
    {
        if (buttonText != null)
        {
            buttonMaterial = buttonText.fontSharedMaterial;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetGlowIntensity(highlightedGlow);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetGlowIntensity(normalGlow);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetGlowIntensity(clickedGlow);
        SetGlowIntensity(normalGlow);
    }

    private void SetGlowIntensity(float intensity)
    {
        if (buttonMaterial != null)
        {
            buttonMaterial.SetFloat("_GlowPower", intensity);
        }
    }

}
