using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data
{
    int sceneIndex;
    public Health[] units;

    public void CreateData()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        units = Resources.FindObjectsOfTypeAll<Health>();
    }
}
