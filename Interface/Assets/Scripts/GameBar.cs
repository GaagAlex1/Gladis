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

            GUI.Label(new Rect(55, -5, 100, 30), "Меню:", GUI.skin.label);
            if (GUI.Button(new Rect(0, 20, 150, 30), "Продолжить"))
            {
                pause = false;
            }
            if (GUI.Button(new Rect(0, 60, 150, 30), "Настройки"))
            {
                inSettings = true;
            }
            if (GUI.Button(new Rect(0, 100, 150, 30), "Управление"))
            {
                inControl = true;
            }
            if (GUI.Button(new Rect(0, 140, 150, 30), "Выход"))
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
            GUI.Label(new Rect(40, -5, 200, 50), "Настройки", GUI.skin.label);
            if (GUI.Button(new Rect(0, 20, 150, 30), "Настройки звука"))
            {
                inSoundSettings = true;
            }
            if (GUI.Button(new Rect(0, 60, 150, 30), "Настройки графики?"))
            {
                inGraphicSettings = true;
            }
            if (GUI.Button(new Rect(0, 100, 150, 30), "Назад"))
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
            GUI.Label(new Rect(512, 100, 150, 30), "Настройки звука", GUI.skin.label);
            GUI.Label(new Rect(440, 144, 150, 30), "Общая громкость", GUI.skin.label);
            sliderGeneralSounds = GUI.HorizontalSlider(new Rect(568, 150, 150, 30), sliderGeneralSounds, 0.0F, 10.0F);

            GUI.Label(new Rect(440, 194, 150, 30), "Звуки", GUI.skin.label);
            sliderSounds = GUI.HorizontalSlider(new Rect(568, 200, 150, 30), sliderSounds, 0.0F, 10.0F);

            GUI.Label(new Rect(440, 244, 150, 30), "Музыка", GUI.skin.label);
            sliderMusic = GUI.HorizontalSlider(new Rect(568, 250, 150, 30), sliderMusic, 0.0F, 10.0F);

            GUI.Label(new Rect(440, 294, 150, 30), "Голоса", GUI.skin.label);
            sliderVoices = GUI.HorizontalSlider(new Rect(568, 300, 150, 30), sliderVoices, 0.0F, 10.0F);

            if (GUI.Button(new Rect(500, 350, 150, 30), "Назад"))
            {
                inSoundSettings = false;
            }
        }
        if (inQuit)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(512, 100, 100, 30), "Выход", GUI.skin.label);
            GUI.Label(new Rect(512, 150, 150, 30), "Вы уверены?", GUI.skin.label);
            if (GUI.Button(new Rect(500, 200, 150, 30), "Да"))
            {
                inQuitYes = true;
            }
            if (GUI.Button(new Rect(500, 300, 150, 30), "Нет"))
            {
                inQuit = false;
            }

        }
        if (inGraphicSettings)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(512, 100, 150, 30), "Настройки графики", GUI.skin.label);
            GUI.Label(new Rect(440, 144, 150, 30), "Разрешение экрана", GUI.skin.label);
            GUI.Label(new Rect(440, 194, 150, 30), "Качество графики", GUI.skin.label);
            if (GUI.Button(new Rect(500, 250, 150, 30), "Назад"))
            {
                inGraphicSettings = false;
            }
        }
        if (inControl)
        {
            GUI.depth = numDepth;
            GUI.skin = mainUI;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", GUI.skin.GetStyle("Menu"));
            GUI.Label(new Rect(496, 100, 170, 40), "Настройки горячих клавиш", GUI.skin.label);


            if (GUI.Button(new Rect(500, 425, 150, 30), "Назад"))
            {
                
                inControl = false;
            }
        }


    }
}
