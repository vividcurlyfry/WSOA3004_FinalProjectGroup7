using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator transition;
    public int transitionTime = 1;

    /*private void Update()
    {
        if((Input.GetKeyDown(KeyCode.Alpha6)))
        {
            TransitionToScene("DayOver");
        }
    }*/

    public void TransitionToScene (string SceneName)
    {
        StartCoroutine(Transition(SceneName));
    }

    IEnumerator Transition(string SceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneName);
    }
}
