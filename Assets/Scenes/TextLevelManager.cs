using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = GameApplicationManager.Instance.DIFFICULTY_LEVEL_NAMES[GameApplicationManager.Instance.DifficultyLevel];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
