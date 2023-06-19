using UnityEngine;
using System.Collections;

public class GameBar : MonoBehaviour
{
    public GUISkin mainUI;
    public int numDepth = 1;
    public bool pause = false;
    public bool inQuit = false;
    public bool inQuitYes = false;
    public bool inSettings = false;
    public bool inSoundSettings = false;
    public bool inGraphicSettings = false;
    public bool inControl = false;
    public float sliderGeneralSounds = 0.0F;
    public float sliderSounds = 0.0F;
    public float sliderMusic = 0.0F;
    public float sliderVoices = 0.0F;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (pause && inSettings == false && inControl == false && inQuit == false)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));

            GUI.BeginGroup(new Rect((Screen.width - 150) / 2, (Screen.height - 150) / 2, 200, 200));

            GUI.Label(new Rect(55, -5, 100, 30), "����:", GUI.skin.label);
            if (GUI.Button(new Rect(0, 20, 150, 30), "����������"))
            {
                pause = false;
            }
            if (GUI.Button(new Rect(0, 60, 150, 30), "���������"))
            {
                inSettings = true;
            }
            if (GUI.Button(new Rect(0, 100, 150, 30), "����������"))
            {
                inControl = true;
            }
            if (GUI.Button(new Rect(0, 140, 150, 30), "�����"))
            {
                inQuit = true;
            }
            GUI.EndGroup();
        }
        if (inSettings && inSoundSettings == false && inGraphicSettings == false)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.BeginGroup(new Rect((Screen.width - 150) / 2, (Screen.height - 150) / 2, 200, 200));
            GUI.Label(new Rect(40, -5, 200, 50), "���������", GUI.skin.label);
            if (GUI.Button(new Rect(0, 20, 150, 30), "��������� �����"))
            {
                inSoundSettings = true;
            }
            if (GUI.Button(new Rect(0, 60, 150, 30), "��������� �������?"))
            {
                inGraphicSettings = true;
            }
            if (GUI.Button(new Rect(0, 100, 150, 30), "�����"))
            {
                inSettings = false;
            }
            GUI.EndGroup();
        }
        if (inSoundSettings)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(512, 100, 150, 30), "��������� �����", GUI.skin.label);
            GUI.Label(new Rect(440, 144, 150, 30), "����� ���������", GUI.skin.label);
            sliderGeneralSounds = GUI.HorizontalSlider(new Rect(568, 150, 150, 30), sliderGeneralSounds, 0.0F, 10.0F);

            GUI.Label(new Rect(440, 194, 150, 30), "�����", GUI.skin.label);
            sliderSounds = GUI.HorizontalSlider(new Rect(568, 200, 150, 30), sliderSounds, 0.0F, 10.0F);

            GUI.Label(new Rect(440, 244, 150, 30), "������", GUI.skin.label);
            sliderMusic = GUI.HorizontalSlider(new Rect(568, 250, 150, 30), sliderMusic, 0.0F, 10.0F);

            GUI.Label(new Rect(440, 294, 150, 30), "������", GUI.skin.label);
            sliderVoices = GUI.HorizontalSlider(new Rect(568, 300, 150, 30), sliderVoices, 0.0F, 10.0F);

            if (GUI.Button(new Rect(500, 350, 150, 30), "�����"))
            {
                inSoundSettings = false;
            }
        }
        if (inQuit)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(512, 100, 100, 30), "�����", GUI.skin.label);
            GUI.Label(new Rect(512, 150, 150, 30), "�� �������?", GUI.skin.label);
            if (GUI.Button(new Rect(500, 200, 150, 30), "��"))
            {
                inQuitYes = true;
            }
            if (GUI.Button(new Rect(500, 300, 150, 30), "���"))
            {
                inQuit = false;
            }

        }
        if (inGraphicSettings)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(512, 100, 150, 30), "��������� �������", GUI.skin.label);
            GUI.Label(new Rect(440, 144, 150, 30), "���������� ������", GUI.skin.label);
            GUI.Label(new Rect(440, 194, 150, 30), "�������� �������", GUI.skin.label);
            if (GUI.Button(new Rect(500, 250, 150, 30), "�����"))
            {
                inGraphicSettings = false;
            }
        }
        if (inControl)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(496, 100, 170, 40), "��������� ������� ������", GUI.skin.label);


            if (GUI.Button(new Rect(500, 425, 150, 30), "�����"))
            {
                
                inControl = false;
            }
        }


    }
}
