using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameApplicationManager : Singleton<SingletonGameApplicationManager>
{
    public string[] DIFFICULTY_LEVEL_NAMES = { "Easy", "Normal", "Hard", "Extreme" };

    public bool IsOptionMenuActive
    {
        get { return _isOptionMenuActive; }
        set { _isOptionMenuActive = value; }
    }
    protected bool _isOptionMenuActive = false;

    public bool IsHowtoActive
    {
        get { return _isHowtoActive; }
        set { _isHowtoActive = value; }
    }
    protected bool _isHowtoActive = false;

    public int DifficultyLevel{get;set;}
    public bool MusicEnabled { get; set; }
    public bool SFXEnabled { get; set; }
}
