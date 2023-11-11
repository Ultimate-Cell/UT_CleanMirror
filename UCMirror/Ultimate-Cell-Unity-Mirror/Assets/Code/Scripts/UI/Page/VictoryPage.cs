using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Spine.Unity;
using TMPro;

public class VictoryPage : MonoBehaviour
{
    #region 交互组件
    [Header("按钮")]
    public Button BackBtn;

    [Header("特效")]
    public ParticleSystem VictoryEffect;

    public Image image;

    private float Speed = 0.2f;

    public List<GameObject> Stars = new List<GameObject>();

    public List<SkeletonGraphic> Characters = new List<SkeletonGraphic>();

    public float brightness = 5f;

    [Header("Canvas")]
    public Canvas canvaspage;

    [Header("Other")]
    public GameObject Character;

    private Vector3 CharacterTarget;

    public GameObject VictoryTex;

    public GameObject RankTex;

    public GameObject RankStyle;

    public GameObject ButtomInfo;

    private Image[] images;

    private TextMeshProUGUI[] textmeshpros;

    #endregion

    #region 业务

    private void Start()
    {
        BackBtn.onClick.AddListener(() =>
        {
            AudioSystemManager.Instance.PlaySound("BUtton_Click_two");

            BackMainPage(); 
        });

        Character.transform.DOLocalMoveX(-1600f, 0f);

        VictoryTex.transform.DOLocalMoveX(-1600f, 0f);

        RankTex.transform.DOLocalMoveX(-1400f, 0f);

        RankStyle.transform.DOLocalMoveX(-1400f, 0f);

        images = ButtomInfo.GetComponentsInChildren<Image>();

        textmeshpros = ButtomInfo.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (var image in images)
        {
            image.DOColor(new Color(1f, 1f, 1f, 0f), 0f);

        }

        foreach (var mesh in textmeshpros)
        {
            mesh.DOColor(new Color(1f, 1f, 1f, 0f), 0f);

        }

        foreach (var obj in Stars)
        {
            obj.GetComponent<Image>().DOColor(new Color(1f, 1f, 1f, 0f), 0f);
        }

        //这里需要把UI设定为ScreenSpace
        Camera uiCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        canvaspage.renderMode = RenderMode.ScreenSpaceCamera;
        canvaspage.worldCamera = uiCam;
        canvaspage.sortingOrder = 200;
        canvaspage.sortingLayerName = "Flow";

        GameObject.Find("AvatarsUI(Clone)")?.gameObject.SetActive(false);

        GameObject.Find("BlocksUI(Clone)")?.gameObject.SetActive(false);

        Invoke("PlayEffect", 1f);
    }

    void PlayEffect()
    {
        var brightnessMaterial = image.material;

        brightnessMaterial.SetFloat("_Brightness", brightness);

        image.fillAmount = 0;

        AudioSystemManager.Instance.PlaySound("Page_Victory");

        image.DOFillAmount(1f, Speed).OnComplete( () =>
        {
            image.material = null;

            VictoryEffect.Play();

            VictoryTex.transform.DOLocalMoveX(200f, 0.3f).OnComplete(() =>
            {
                VictoryTex.transform.DOLocalMoveX(354f, 0.5f).SetEase(Ease.OutBounce);

                Vector3 targetScale = new Vector3(1.5f, 1.5f, 1.5f);

                foreach (var obj in Stars)
                {
                    obj.GetComponent<Image>().DOColor(new Color(1f, 1f, 1f, 1f), 0f);

                    obj.transform.DOScale(targetScale, 0.2f).SetLoops(-1, LoopType.Yoyo);
                }
            });

            RankTex.transform.DOLocalMoveX(223.1f, 1f).SetEase(Ease.OutBounce);

            RankStyle.transform.DOLocalMoveX(418.7f, 1f).SetEase(Ease.OutBounce);

            RankStyle.transform.DOLocalMoveY(RankStyle.transform.localPosition.y - 15f, 0.5f).SetLoops(-1, LoopType.Yoyo);

            foreach (var image in images)
            {
                image.DOColor(new Color(1f, 1f, 1f, 1f), 1f);

            }

            foreach (var mesh in textmeshpros)
            {
                mesh.DOColor(new Color(1f, 1f, 1f, 1f), 1f);

            }

            Character.transform.DOLocalMoveX(-300, 3f).OnComplete(() =>
            {

                foreach (var chat in Characters) 
                {
                    chat.AnimationState.SetAnimation(0, "idle", true);
                }
            });
        });
    }

    void BackMainPage() 
    {
        var sceneLoader = GameObject.Find("SceneLoader").gameObject.GetComponent<MainSceneControlManager>();

        // sceneLoader.ClearAllBroadCast();

        GameObject.Find("NetworkManager").GetComponent<NetworkManagerUC_PVP>().StopClient();

        sceneLoader.LoadMainBasicScene();
    }

    #endregion

}
