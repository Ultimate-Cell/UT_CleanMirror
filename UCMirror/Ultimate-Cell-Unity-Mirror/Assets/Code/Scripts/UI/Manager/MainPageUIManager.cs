using Common;
using DG.Tweening;
using GameFrameWork;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UIManager;
using Button = UnityEngine.UI.Button;

public class MainPageUIManager : BaseUI
{
    public override UIType GetUIType()
    {
        throw new System.NotImplementedException();
    }

    [Header("主页面")]
    public GameObject Canvas;

    public GameObject ScientistImage;

    public GameObject CellsInfo_1;

    public GameObject CellsInfo_2;

    public GameObject ScenetistGameObjectInfo;

    public GameObject Flask_Style;

    [Header("屏幕遮罩")]
    // 屏幕遮罩
    public GameObject ScreenMask;

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

    // 科学家果实树按钮
    public Button ScinetistBUtton;

    // 细胞按钮
    public Button CellsButton;

    [Header("联网 - 不设置")]
    public NetWorkMatchingBehaviour behaviour;

    public SettingsInfo host;

    private void Start()
    {
        StartMatchingButton.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("Button_GameStart_Click");

            StartMatching(); 
        });

        UserInfoButton.onClick.AddListener(() => 
        {
            AudioSystemManager.Instance.PlaySound("UI_Change"); 

            DisplaySecondaryPage("UserInfoPage"); 
        });

        MailInfoButton.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("UI_Change");

            DisplaySecondaryPage("MailInfoPage"); 
        });

        FriendsInfoButton.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("UI_Change");

            DisplaySecondaryPage("FriendsInfoPage"); 
        });

        SettingInfoButton.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("UI_Change");

            DisplaySecondaryPage("SettingInfo"); 
        });

        ChatInfoButton.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("UI_Change");

            DisplaySecondaryPage("ChatInfo"); 
        });

        FruitTreeButton.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("UI_Change");

            DisplaySecondaryPage("FruitPageInfo"); 
        });

        BtnEvent.RigisterButtonDownEvent(ScinetistBUtton.transform.gameObject, p => { this.OnScButtonDown(); });

        BtnEvent.RigisterButtonUpEvent(ScinetistBUtton.transform.gameObject, p => { this.OnScButtonUp(); });

        BtnEvent.RigisterButtonDownEvent(CellsButton.transform.gameObject, p => { this.OnCeButtonDown(); });

        BtnEvent.RigisterButtonUpEvent(CellsButton.transform.gameObject, p => { this.OnCeButtonUp(); });

        // 二级页面事件注册
        this.LevelTwoPageAction();

        this.MusicPlayer();

        // 动效播放
        // Invoke("PlayEffet", 1f);
    }

    private void MusicPlayer()
    {
        // Play Music
        AudioSystemManager.Instance.PlaySound("Bubble_Music");

        AudioSystemManager.Instance.PlayMusic("MianBackGround_Music", 99);
    }

    private Tween SceneTween;

    private void PlayEffet() 
    {
        // 科学家上下移动
        SceneTween = this.SetScenetistTween();
    }

    private Tween SetScenetistTween() 
    {
        return ScenetistGameObjectInfo.transform.DOMoveY(Mathf.PingPong(Time.deltaTime * 1f, 80f) - 40f + ScenetistGameObjectInfo.transform.position.y, 2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }

    /// <summary>
    /// 科学家按钮压下
    /// </summary>
    private void OnScButtonDown()
    {
        AudioSystemManager.Instance.PlaySound("UI_Change");

        ScientistImage.gameObject?.SetActive(true);
    }

    /// <summary>
    /// 科学家按钮抬起
    /// </summary>
    private void OnScButtonUp()
    {
        AudioSystemManager.Instance.PlaySound("Button_Click_one");

        ScientistImage.gameObject?.SetActive(false);

        FruitTreePage.SetActive(true);
    }

    /// <summary>
    /// 细胞按钮压下
    /// </summary>
    private void OnCeButtonDown()
    {
        CellsInfo_1.gameObject?.SetActive(true);

        CellsInfo_2.gameObject?.SetActive(true);
    }

    /// <summary>
    /// 细胞按钮抬起
    /// </summary>
    private void OnCeButtonUp()
    {

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