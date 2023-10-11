using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FriendsDetailTigger : MonoBehaviour
{
    public GameObject FriendsDetailGameObject;

    public Button SelectButton;

    private bool DetailShow = false;

    private void Start()
    {
        SelectButton.onClick.AddListener(() => { OnDetailChange(DetailShow); });
    }

    /// <summary>
    /// 好友详情界面选择器
    /// </summary>
    void OnDetailChange(bool _detailShow) 
    {
        if (_detailShow)
        {
            OnDetailHide();
        }
        else 
        {
            OnDetailShow();
        }

        DetailShow = !DetailShow;
    }

    /// <summary>
    /// 显示好友详细信息
    /// </summary>
    public void OnDetailShow() 
    {
        FriendsDetailGameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭好友详细信息
    /// </summary>
    public void OnDetailHide()
    {
        FriendsDetailGameObject.SetActive(false);
    }
}