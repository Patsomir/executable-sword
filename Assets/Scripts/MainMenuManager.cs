using System;
using System.Collections;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject controlsMenu = null;

    [SerializeField]
    private GameObject creditsMenu = null;

    [SerializeField]
    private string initialScene = "TileSampleScene";

    private GameObject currentMenu = null;

    public Action OnTransitionStart;

    public void Play()
    {
        StartCoroutine(StartGameCoroutine(0.5f));
    }

    public void Controls()
    {
        StartCoroutine(TransitionCoroutine(controlsMenu, 0.5f));
    }

    public void Credits()
    {
        StartCoroutine(TransitionCoroutine(creditsMenu, 0.5f));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        StartCoroutine(ReturnCoroutine(0.5f));
    }

    private IEnumerator TransitionCoroutine(GameObject menu, float delay)
    {
        OnTransitionStart?.Invoke();
        currentMenu = menu;
        yield return new WaitForSeconds(delay/2);
        menu.SetActive(true);
    }

    private IEnumerator StartGameCoroutine(float delay)
    {
        OnTransitionStart?.Invoke();
        yield return new WaitForSeconds(delay / 2);
        SceneTransitionManager.LoadScene(initialScene);
    }

    private IEnumerator ReturnCoroutine(float delay)
    {
        OnTransitionStart?.Invoke();
        yield return new WaitForSeconds(delay/2);
        currentMenu.SetActive(false);
        currentMenu = null;
    }
}
