using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private static SceneTransitionManager instance = null;
    public static Action<float> OnLoadSchedule;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void ScheduleLoadScene(string name, float delay)
    {
        instance.StartCoroutine(ScheduleCoroutine(name, delay));
        OnLoadSchedule?.Invoke(delay);
    }

    private static IEnumerator ScheduleCoroutine(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(name);
    }
}
