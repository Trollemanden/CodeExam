using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SceneChangetoNewScene()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneChangetoHomePage()
    {
        SceneManager.LoadScene(0);

    }
}

