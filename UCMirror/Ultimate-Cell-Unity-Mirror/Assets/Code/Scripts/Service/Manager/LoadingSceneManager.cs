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

    public GameObject SceneLoader;

    private void Start()
    {
        StartCoroutine(nameof(PlayDoTweenAC));
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
        var rightvec = RightStyle.transform.position;

        Sequence mySequence = DOTween.Sequence();

        Sequence mySequence2 = DOTween.Sequence();

        // 隐藏物体
        mySequence.Append(LeftStyle.transform.DOMoveX(this.transform.position.x - 5000f, 0f));

        mySequence2.Append(RightStyle.transform.DOMoveX(rightvec.x + 5000f, 0f));

        // 左侧物体效果
        mySequence.Append(LeftStyle.transform.DOMoveX(this.transform.position.x + 300f, 0.5f));

        mySequence.Append(LeftStyle.transform.DOMoveX(0, 0.5f).SetEase(Ease.OutBounce));

        // 右侧物体效果
        mySequence2.Append(RightStyle.transform.DOMoveX(rightvec.x - 300f, 0.5f));

        mySequence2.Append(RightStyle.transform.DOMoveX(rightvec.x, 0.5f).SetEase(Ease.OutBounce));

        // VS 效果
        mySequence.Append(VSStyle.transform.DOScale(Vector3.zero, 0.3f).From().SetEase(Ease.OutBounce));

        mySequence.Append(EffecctStyle.transform.DOScale(Vector3.zero, 0.3f).From()); 
        
        mySequence.AppendInterval(0.5f);

        mySequence.OnComplete(() => {

            // GameObject.Find("SceneLoader").gameObject.SetActive(true);

            this.transform.parent.gameObject.SetActive(false);

            Debug.Log("Battle Close");
        });

        Debug.Log(VSStyle.transform.position);
    }
}