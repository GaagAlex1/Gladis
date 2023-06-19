using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;
using UnityEditor;

public class HelpOpen : MonoBehaviour
{
    public void clickHelp()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Gladis Руководство Пользователя.chm");
        System.Diagnostics.Process.Start(filePath);
    }
}
