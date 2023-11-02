using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class LocalSettingManager : MonoBehaviour 
{
    public SettingsInfo settingInfo;

    public TMP_InputField input;

    public Button button;

    private bool textInfo = false;

    private void Start()
    {
        button.onClick.AddListener( () => { ShowHideInput(); });
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
            settingInfo.localhost = input.text;

            textInfo = false;

            input.gameObject.SetActive(false);
        }
    }
}