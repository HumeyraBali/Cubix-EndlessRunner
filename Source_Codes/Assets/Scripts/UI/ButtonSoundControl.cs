using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundEffects : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource audioSource; // Assign the AudioSource component
    public AudioClip highlightSound; // Assign your highlight sound
    public AudioClip clickSound; // Assign your click sound

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySound(highlightSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlaySound(clickSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
