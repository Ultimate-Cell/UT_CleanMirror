using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FriendsInfoPageManager : MonoBehaviour
{
    // 页面关闭按钮
    public Button ClosePageButton;

    private void Start()
    {
        ClosePageButton.onClick.AddListener(() => { ClosePage(); });
    }

    // 页面关闭方法
    void ClosePage()
    {
        this.gameObject.SetActive(false);

        // FriendsInfoPageCloseAction("FriendsInfoPage");
    }

    // 好友详情界面触发方法
    void TiggerFriendsDetail() 
    {
        
    }

}