using System.Collections;
using UnityEngine;

public class SceneTransitionAnimation : MonoBehaviour
{
    [SerializeField]
    private float transitionDuration = 0.5f;

    private void OnEnable()
    {
        SceneTransitionManager.OnLoadSchedule += PlayTransitionAnimation;
    }

    private void OnDisable()
    {
        SceneTransitionManager.OnLoadSchedule -= PlayTransitionAnimation;
    }

    private void PlayTransitionAnimation(float delay)
    {
        StartCoroutine(TransitionCoroutine(delay - transitionDuration));
    }

    private IEnumerator TransitionCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Animator>().SetTrigger("Exit");
    }

}
