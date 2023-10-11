using UC_PlayerData;
using UnityEngine;
using DG.Tweening;

public class LoadingSceneManager : MonoBehaviour 
{
    public GameObject LeftStyle;

    public GameObject RightStyle;

    public GameObject TopStyle;

    public GameObject VSStyle;

    public GameObject EffecctStyle;

    private void Start()
    {
        this.PlayDoTweenAC();
    }

    /// <summary>
    /// 获取当前启动状态 
    /// </summary>
    /// <returns></returns>
    RunMode GetRunMode()
    {
        return RunModeData.CurrentRunMode;
    }

    /// <summary>
    /// 播放加载初始化DoTween动画
    /// </summary>
    void PlayDoTweenAC() 
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(LeftStyle.transform.DOMoveX(this.transform.position.x - 5000f, 0f));

        mySequence.Append(LeftStyle.transform.DOMoveX(this.transform.position.x + 20f, 0.5f));

        mySequence.Append(LeftStyle.transform.DOMoveX(this.transform.position.x - 408f, 1f));

        Sequence mySequence2 = DOTween.Sequence();

        mySequence2.Append(RightStyle.transform.DOMoveX(this.transform.position.x + 5000f, 0f));

        mySequence2.Append(RightStyle.transform.DOMoveX(this.transform.position.x - 20f, 0.5f));

        mySequence2.Append(RightStyle.transform.DOMoveX(this.transform.position.x + 406f, 1f));

        VSStyle.transform.DOScale(Vector3.zero, 2f).From();

        Debug.Log(VSStyle.transform.position);
    }
}