using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{

    public GUISkin mainUI;
    public int numDepth = 0;
    public int gold;
    public int lumber;
    public bool inGame = true;
    public string nameWindow;
    public Texture2D objectSelection, defaultPicture;
    public RenderTexture map;
    public Material plug;
    public bool pause = false;
    private GameBar GameBar;


    void Start()
    {
        GameBar = gameObject.GetComponent<GameBar>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameBar.pause = true;
        }
    }

    void OnGUI()
    {
        GUI.depth = numDepth;
        GUI.skin = mainUI;
        #region LEFTBOX
        GUI.Box(new Rect(0, Screen.height - 192, 192, 192), "", GUI.skin.GetStyle("Stripe"));
        if (Event.current.type.Equals(EventType.Repaint))
            Graphics.DrawTexture(new Rect(0, Screen.height - 192, 192, 192), map, plug);
        GUI.Box(new Rect(0, Screen.height - 192, 192, 192), "", GUI.skin.GetStyle("Frame"));
        #endregion

        #region LINE
        GUI.Box(new Rect(192, Screen.height - 150, Screen.width - 384, 150), "", GUI.skin.GetStyle("Stripe"));
        #endregion

        #region RIGHTBOX
        if (objectSelection != null) GUI.DrawTexture(new Rect(Screen.width - 192, Screen.height - 192, 192, 192), objectSelection);
        else GUI.DrawTexture(new Rect(Screen.width - 192, Screen.height - 192, 192, 192), defaultPicture);

        GUI.Box(new Rect(Screen.width - 192, Screen.height - 192, 192, 192), "", GUI.skin.GetStyle("Frame"));
        #endregion

        #region UPPERBLOCK
        GUI.Box(new Rect(Screen.width - 200, 0, 200, 30), "");
        GUI.Label(new Rect(Screen.width - 125, 5, 200, 30), "Золото " + gold.ToString(), GUI.skin.label);
        GUI.Box(new Rect(Screen.width - 200, 30, 200, 30), "");
        GUI.Label(new Rect(Screen.width - 125, 35, 200, 30), "Дерево " + lumber.ToString(), GUI.skin.label);

        if (GUI.Button(new Rect(0, 0, 100, 25), "Меню"))
        {
            GameBar.pause = true;
        }
        if (GameBar.inQuitYes == true)
        {
            Application.Quit();
            Debug.Log("Exit");
        }
        #endregion
    }
}
