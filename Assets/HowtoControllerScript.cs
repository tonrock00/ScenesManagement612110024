using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowtoControllerScript : MonoBehaviour
{
    [SerializeField] Button _backButton;
    // Start is called before the first frame update
    void Start()
    {
        _backButton.onClick.AddListener(delegate { BackButtonClick(_backButton); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackButtonClick(Button button)
    {
        SceneManager.UnloadSceneAsync("SceneHowto");
        SingletonGameApplicationManager.Instance.IsHowtoActive = false;
    }
}
