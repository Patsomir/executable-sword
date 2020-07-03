using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string destination = null;

    [SerializeField]
    private float delay;

    private bool hasActivated = false;

    public Action OnActivation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (!hasActivated)
        {
            SceneTransitionManager.ScheduleLoadScene(destination, delay);
            hasActivated = true;
            GetComponent<CircleCollider2D>().enabled = false;
            OnActivation?.Invoke();
        }
    }
}
