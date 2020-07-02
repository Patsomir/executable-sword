using System.Collections;
using UnityEngine;

public class SwordLifetime : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 3;

    private void Start()
    {
        StartCoroutine(DisappearCoroutine());
    }
    private IEnumerator DisappearCoroutine()
    {
        yield return new WaitForSeconds(lifetime);

        GetComponentInChildren<VFXEvaporation>().Evaporate();
    }
}
