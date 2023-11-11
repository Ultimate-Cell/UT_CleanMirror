using System.Globalization;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class LocalSettingManager : MonoBehaviour 
{
    public SettingsInfo LocalSettings;

    public string settingInfo;

    public TMP_InputField input;

    public Button button;

    private bool textInfo = false;

    public GameObject LeafGif;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        button.onClick.AddListener( () => { ShowHideInput(); });

        settingInfo = LocalSettings.localhost;

        input.text = settingInfo;

        // 获取屏幕分辨率
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        Debug.Log("屏幕分辨率：" + screenWidth + "x" + screenHeight);
    }

    void ShowHideInput() 
    {
        Debug.Log("button Click");

        if (!textInfo)
        {
            input.gameObject.SetActive(true);

            textInfo = true;
        }
        else 
        {
            settingInfo = input.text;

            LocalSettings.localhost = input.text;

            textInfo = false;

            input.gameObject.SetActive(false);
        }
    }
}