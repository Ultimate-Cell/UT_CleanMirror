using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserInfoPageManager : MonoBehaviour 
{
    // 页面关闭按钮
    public Button ClosePageButton;

    // 页面关闭发送事件
    public UnityAction<string> UserInfoPageCloseAction;

    private void Start()
    {
        ClosePageButton.onClick.AddListener(() => { ClosrPage(); });
    }

    // 页面关闭方法
    void ClosrPage() 
    {
        this.gameObject.SetActive(false);

        UserInfoPageCloseAction("UserInfoPage");
    }
}