using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderShower : MonoBehaviour
{
    public GameObject screenc;

    public void Update()
    {
        ShowAndHide();
    }

    public void ShowAndHide()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            screenc.SetActive(!screenc.activeSelf);
        }
    }
}
