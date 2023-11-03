using Common;
using GameFrameWork;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UIManager;

public class MainPageUIManager : MonoBehaviour 
{
    [Header("屏幕遮罩")]

    // 屏幕遮罩
    public GameObject ScreenMask;

    [Header("主页面按钮")]

    // 开始游戏按钮
    public Button StartMatchingButton;

    // 个人信息页面Button
    public Button UserInfoButton;

    // 邮件页面打开Button
    public Button MailInfoButton;

    // 好友页面打开Button
    public Button FriendsInfoButton;

    // 设置页面打开Button
    public Button SettingInfoButton;

    // 聊天页面打开Button
    public Button ChatInfoButton;

    // 果实树页面打开Button
    public Button FruitTreeButton;

    [Header("二级页面")]

    // 用户信息页面
    public GameObject UserInfoPage;

    // 邮件页面
    public GameObject MailInfoPage;

    // 好友页面
    public GameObject FriendsInfoPage;

    // 设置界面Button
    public GameObject SettingInfoPage;

    // 聊天页面
    public GameObject ChatInfoPage;

    // 果实树页面
    public GameObject FruitTreePage;

    [Header("联网")]
    public NetWorkMatchingBehaviour behaviour;

    public SettingsInfo host;

    private void Start()
    {
        StartMatchingButton.onClick.AddListener(() => { StartMatching(); });

        UserInfoButton.onClick.AddListener(() => { DisplaySecondaryPage("UserInfoPage"); });

        MailInfoButton.onClick.AddListener(() => { DisplaySecondaryPage("MailInfoPage"); });

        FriendsInfoButton.onClick.AddListener(() => { DisplaySecondaryPage("FriendsInfoPage"); });

        SettingInfoButton.onClick.AddListener(() => { DisplaySecondaryPage("SettingInfo"); });

        ChatInfoButton.onClick.AddListener(() => { DisplaySecondaryPage("ChatInfo"); });

        FruitTreeButton.onClick.AddListener(() => { DisplaySecondaryPage("FruitPageInfo"); });

        // 二级页面事件注册
        this.LevelTwoPageAction();
    }

    /// <summary>
    /// 二级页面事件注册
    /// </summary>
    void LevelTwoPageAction() 
    {
        UserInfoPage.GetComponent<UserInfoPageManager>().UserInfoPageCloseAction += CloseMask;

        MailInfoPage.GetComponent<MailInfoPageManager>().MailInfoPageCloseAction += CloseMask;

        SettingInfoPage.GetComponent<SettingInfoPageManager>().SettingInfoPageCloseAction += CloseMask;
    }

    /// <summary>
    /// 开始游戏 - 匹配功能启动
    /// </summary>
    void StartMatching()
    {
        GameObject.Find("NetWorkMatchingBehaviour").GetComponent<NetWorkMatchingBehaviour>().OnJoinServer();
    }

    /// <summary>
    /// 单机启动
    /// </summary>
    void StartMatchingSingle() 
    {
        var sceneLoader = GameObject.Find("SceneLoader").gameObject.GetComponent<MainSceneControlManager>();

        sceneLoader.LoadMainFightScene();
    }

    /// <summary>
    /// Ping pong Test
    /// </summary>
    void StartMatchingPongTest()
    {
        var sceneLoader = GameObject.Find("SceneLoader").gameObject.GetComponent<MainSceneControlManager>();

        sceneLoader.LoadPingPongScene();
    }

    /// <summary>
    /// 显示二级页面
    /// </summary>
    void DisplaySecondaryPage(string _pageName) 
    {
        // var _prefab = ABManager.Instance.LoadResource<GameObject>("uipage", _pageName);

        // var _uiObj = GameObject.Instantiate(_prefab);

        switch ( _pageName ) 
        {
            case "UserInfoPage":
                ScreenMask.SetActive(true);
                UserInfoPage.SetActive(true);
                break;
            case "MailInfoPage":
                ScreenMask.SetActive(true);
                MailInfoPage.SetActive(true);
                break;
            case "SettingInfo":
                ScreenMask.SetActive(true);
                SettingInfoPage.SetActive(true);
                break;
            case "ChatInfo":
                ChatInfoPage.SetActive(true);
                break;
            case "FriendsInfoPage":
                FriendsInfoPage.SetActive(true);
                break;
            case "FruitPageInfo":
                FruitTreePage.SetActive(true);
                break;
        }
    }


    /// <summary>
    /// 关闭屏幕遮罩事件
    /// </summary>
    void CloseMask(string info)
    {
        ScreenMask.SetActive(false);
    }
}