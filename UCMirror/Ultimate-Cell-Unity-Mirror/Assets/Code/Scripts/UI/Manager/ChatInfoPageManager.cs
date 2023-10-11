using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChatInfoPageManager : MonoBehaviour
{
    // 页面关闭按钮
    public Button ClosePageButton;

    // 页面切换按钮-好友
    public Button FriendsButton;

    // 页面切换按钮-地区
    public Button ChannelButton;

    [Header("切换页面")]
    // 好友界面
    public GameObject FriendsInfo;

    // 地区界面
    public GameObject ChannelInfo;

    private void Start()
    {
        ClosePageButton.onClick.AddListener(() => { ClosePageStyle(); });

        FriendsButton.onClick.AddListener(() => { ChangePage("Friends"); });

        ChannelButton.onClick.AddListener(() => { ChangePage("Channel"); });
    }

    private void OnEnable()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(this.transform.DOMoveX(this.transform.position.x - 1306f, 0f));

        mySequence.Append(this.transform.DOMoveX(this.transform.position.x + 20f, 0.5f));

        mySequence.Append(this.transform.DOMoveX(this.transform.position.x, 0.5f));
    }

    private void OnDisable()
    {
    }

    // 页面关闭方法
    void ClosePageStyle()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(this.transform.DOMoveX(this.transform.position.x + 20f, 0.2f));

        mySequence.Append(this.transform.DOMoveX(this.transform.position.x - 1306f, 0.5f));

        mySequence.AppendCallback(ClosePage);
    }

    void ClosePage()
    {
        this.gameObject.SetActive(false);

        this.transform.DOMoveX(this.transform.position.x + 1306f, 0);
    }

    void ChangePage(string _page) 
    {
        switch (_page) 
        {
            case "Channel":
                ChannelInfo.SetActive(true);
                FriendsInfo.SetActive(false);
                break;
            case "Friends":
                ChannelInfo.SetActive(false);
                FriendsInfo.SetActive(true);
                break;
        }
    }

}