using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Spine.Unity;
using TMPro;
using System.Collections;
using System.Threading;

public class FailPageManager : MonoBehaviour 
{

    #region 交互组件
    [Header("按钮")]
    public Button BackBtn;

    public Image image;

    private float Speed = 0.2f;

    public List<SkeletonGraphic> Characters = new List<SkeletonGraphic>();

    public float brightness = 5f;

    [Header("Canvas")]
    public Canvas canvaspage;

    [Header("Other")]
    public GameObject Character;

    public GameObject VictoryTex;

    public GameObject RankStyle;

    public GameObject RankTex;

    public GameObject ButtomInfo;

    private Image[] images;

    private TextMeshProUGUI[] textmeshpros;

    private GameObject Leaf;

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

        RankStyle.transform.DOLocalMoveX(-1400f, 0f);

        RankTex.transform.DOLocalMoveX(-1400f, 0f);

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

        //这里需要把UI设定为ScreenSpace
        Camera uiCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        canvaspage.renderMode = RenderMode.ScreenSpaceCamera;
        canvaspage.planeDistance = 5f;
        canvaspage.worldCamera = uiCam;
        canvaspage.sortingOrder = 200;
        canvaspage.sortingLayerName = "Flow";

        // TODO ReWrie Code
        GameObject.Find("AvatarsUI(Clone)")?.gameObject.SetActive(false);

        GameObject.Find("BlocksUI(Clone)")?.gameObject.SetActive(false);

        Invoke("PlayEffect", 1f);

    }

    void PlayEffect()
    {
        var brightnessMaterial = image.material;

        brightnessMaterial.SetFloat("_Brightness", brightness);

        image.fillAmount = 0;

        AudioSystemManager.Instance.PlaySound("Page_Fail_2");

        image.DOFillAmount(1f, Speed).OnComplete(() =>
        {
            image.material = null;

            VictoryTex.transform.DOLocalMoveX(200f, 0.3f).OnComplete(() =>
            {
                VictoryTex.transform.DOLocalMoveX(354f, 0.5f).SetEase(Ease.OutBounce);
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

                this.LeafStyle();
            });
        });
    }

    private void LeafStyle()
    {
        Leaf = GameObject.Find("PhoneSettings")?.gameObject.GetComponent<LocalSettingManager>().LeafGif;

        if (Leaf != null)
        {
            Leaf.transform.SetParent(image.gameObject.transform);

            Leaf.gameObject.transform.localPosition = new Vector3(1118f, 0, 0);

            Leaf.gameObject.transform.localRotation = Quaternion.identity;

            Leaf.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 10);

        }
    }

    void BackMainPage()
    {
        DontDestroyOnLoad(Leaf);

        Leaf.transform.SetParent(GameObject.Find("PhoneSettings")?.gameObject.transform);

        GameObject.Find("PhoneSettings").GetComponent<LocalSettingManager>().LeafGif = Leaf;

        var sceneLoader = GameObject.Find("SceneLoader").gameObject.GetComponent<MainSceneControlManager>();

        // sceneLoader.ClearAllBroadCast();

        GameObject.Find("NetworkManager").GetComponent<NetworkManagerUC_PVP>().StopClient();

        sceneLoader.LoadMainBasicScene();
    }

    #endregion
}