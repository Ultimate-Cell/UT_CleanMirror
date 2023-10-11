using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MailInfoPageManager : MonoBehaviour
{
    // 页面关闭按钮
    public Button ClosePageButton;

    // 邮件详情界面
    public GameObject MiddleShowPage;

    // 页面关闭发送事件
    public UnityAction<string> MailInfoPageCloseAction;

    private void Start()
    {
        ClosePageButton.onClick.AddListener(() => { ClosrPage(); });
    }

    // 页面关闭方法
    void ClosrPage()
    {
        this.gameObject.SetActive(false);

        MailInfoPageCloseAction("MailInfoPage");
    }

}