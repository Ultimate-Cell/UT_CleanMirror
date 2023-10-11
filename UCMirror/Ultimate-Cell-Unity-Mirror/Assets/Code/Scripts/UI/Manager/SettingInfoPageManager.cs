using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingInfoPageManager : MonoBehaviour 
{

    // 页面关闭按钮
    public Button ClosePageButton;

    // 退出登录按钮
    public Button LogOutButton;

    private MainSceneControlManager sceneManager;

    // 页面关闭发送事件
    public UnityAction<string> SettingInfoPageCloseAction;

    private void Start()
    {
        // TODO 暂时获取方式
        var sceneLoader = GameObject.Find("SceneLoader").gameObject;

        // 场景管理类
        sceneManager = sceneLoader.GetComponent<MainSceneControlManager>();

        ClosePageButton.onClick.AddListener(() => { ClosrPage(); });

        LogOutButton.onClick.AddListener(() => { Logout(); });
    }

    // 页面关闭方法
    void ClosrPage()
    {
        this.gameObject.SetActive(false);

        SettingInfoPageCloseAction("SettingInfo");
    }

    void Logout() 
    {
        sceneManager.LoadLoginScene();
    }
}