using UnityEngine;

public class SceneSettings : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic = null;
    void Start()
    {
        backgroundMusic.Play();
    }
}
