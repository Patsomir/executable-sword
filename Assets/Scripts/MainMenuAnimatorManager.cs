using UnityEngine;

public class MainMenuAnimatorManager : MonoBehaviour
{
    private Animator animator = null;
    private MainMenuManager manager = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        manager = GetComponent<MainMenuManager>();
    }

    private void SetTransition()
    {
        animator.SetTrigger("Transition");
    }

    private void OnEnable()
    {
        manager.OnTransitionStart += SetTransition;
    }

    private void OnDisable()
    {
        manager.OnTransitionStart -= SetTransition;
    }
}
