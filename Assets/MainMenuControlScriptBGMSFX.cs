using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuControlScriptBGMSFX : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _exitButton;
    [SerializeField] Button _howtoButton;
    [SerializeField] Button _QButton;
    // Start is called before the first frame update

    AudioSource audiosourceButtonUI;
    [SerializeField] AudioClip audioclipHoldOver;
    void Start()
    {
        this.audiosourceButtonUI = this.gameObject.AddComponent<AudioSource>();
        this.audiosourceButtonUI.outputAudioMixerGroup = SingletonSoundManager.Instance.Mixer.FindMatchingGroups("UI")[0];
        SetupButtonsDelegate();

        if (!SingletonSoundManager.Instance.BGMSource.isPlaying)
            SingletonSoundManager.Instance.BGMSource.Play();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audiosourceButtonUI.isPlaying)
            audiosourceButtonUI.Stop();

        audiosourceButtonUI.PlayOneShot(audioclipHoldOver);
    }
    void SetupButtonsDelegate()
    {
        _startButton.onClick.AddListener(delegate { StartButtonClick(_startButton); });
        _optionsButton.onClick.AddListener(delegate { OptionsButtonClick(_optionsButton); });
        _exitButton.onClick.AddListener(delegate { ExitButtonClick(_exitButton); });
        _howtoButton.onClick.AddListener(delegate { HowtoButtonClick(_howtoButton); });
        _QButton.onClick.AddListener(delegate { QButtonClick(_QButton); });
    }

    public void StartButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneGameplay");
    }
    public void OptionsButtonClick(Button button)
    {
        if (!SingletonGameApplicationManager.Instance.IsOptionMenuActive)
        {
            SceneManager.LoadScene("SceneOptions", LoadSceneMode.Additive);
            SingletonGameApplicationManager.Instance.IsOptionMenuActive = true;
        }
    }
    public void ExitButtonClick(Button button)
    {
        Application.Quit();
    }
    public void HowtoButtonClick(Button button)
    {
        if (!SingletonGameApplicationManager.Instance.IsHowtoActive)
        {
            SceneManager.LoadScene("SceneHowto", LoadSceneMode.Additive);
            SingletonGameApplicationManager.Instance.IsHowtoActive = true;
        }
    }
    public void QButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneQ");
    }
}
