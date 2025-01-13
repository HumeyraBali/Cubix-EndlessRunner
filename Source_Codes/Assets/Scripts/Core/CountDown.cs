using UnityEngine;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    [SerializeField] private GameObject countdownParent; 
    private float delayBetweenSteps = 1.0f; 

    private Animator[] textAnimators;

    private void Start()
    {
        textAnimators = countdownParent.GetComponentsInChildren<Animator>(true);
        StartCoroutine(CountdownSequence());
    }

    private IEnumerator CountdownSequence()
    {
        yield return new WaitForSeconds(1f);
        foreach (Animator animator in textAnimators)
        {
            animator.gameObject.SetActive(true);
            animator.SetTrigger("Play");
            yield return new WaitForSeconds(delayBetweenSteps);
            animator.gameObject.SetActive(false);
        }
    }
}
