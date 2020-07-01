using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class VisualPerception : MonoBehaviour
{
    Transform player = null;
    int playerLayer = 8;
    int groundLayer = 9;

    [SerializeField]
    private float sightDistance = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public bool CanSeePlayer()
    {
        if ((player.position.x - transform.root.position.x) * transform.root.localScale.x < 0)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             player.position - transform.position,
                                             sightDistance, 1 << playerLayer | 1 << groundLayer);
        if (hit.collider != null)
        {
            if (hit.collider.transform.root.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
