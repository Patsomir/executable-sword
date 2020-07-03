using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton = null;
    void Start()
    {
        playButton.onClick.AddListener(Play);
    }

    void Play()
    {
        SceneManager.LoadScene("TileSampleScene");
    }
}
