using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginMainSceneManager : MonoBehaviour
{
    #region 交互组件
    [Header("页面切换组件")]
    // 登陆页面
    public GameObject MainPage;

    // 屏幕遮罩界面
    public GameObject MaskPage;

    [Header("按钮组件")]
    // 登陆按钮
    public Button LoginButton;

    // 新建账号界面切换按钮
    public Button CreateAccountButton;

    [Header("页面切换组件")]
    public MainSceneControlManager SceneLoad;
    #endregion

    #region 生命周期

    private void Start()
    {
        LoginButton.onClick.AddListener(() => { this.LoginButtonClick(); });

        CreateAccountButton.onClick.AddListener(() => { this.CreateButtonClick(); });

        Invoke(nameof(SetMask), 0.1f);

        Invoke(nameof(StopMask), 2f);

        AudioSystemManager.Instance.PlayMusic("FearsLeftHandMan", 99);

        AudioSystemManager.Instance.PlaySound("Bubble_Music");
    }
    #endregion

    #region 逻辑方法

    void SetMask()
    {
        // 加载屏幕遮罩
        MaskPage.SetActive(true);
    }

    void StopMask()
    {
        // 关闭屏幕遮罩
        MaskPage.SetActive(false);
    }

    #endregion

    #region 监听事件

    /// <summary>
    /// 登陆按钮点击事件
    /// </summary>
    void LoginButtonClick()
    {
        SceneLoad.LoadMainBasicScene();

        AudioSystemManager.Instance.PlaySound("Button_Click_one");
    }

    /// <summary>
    /// 注册按钮点击事件
    /// </summary>
    void CreateButtonClick()
    {
        SceneLoad.LoadMainBasicScene();

        AudioSystemManager.Instance.PlaySound("BUtton_Click_two");
    }
    #endregion
}