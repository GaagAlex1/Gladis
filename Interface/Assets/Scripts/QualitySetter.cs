using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySetter : MonoBehaviour
{
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
