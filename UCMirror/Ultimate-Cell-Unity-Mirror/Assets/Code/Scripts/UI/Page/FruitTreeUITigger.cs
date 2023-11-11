using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static TreeFruitPageManager;
using static EventType;
using GameFrameWork;

public class FruitTreeUITigger : BaseUI 
{
    public List<GameObject> ToObject = new List<GameObject>();

    public List<GameObject> FromObjects = new List<GameObject>();

    public bool isRootFruit;

    public bool isCampFruit;

    public int CostPointsInfo;

    public bool _isTigger = false;

    public bool isTigger
    {
        get { return _isTigger; }
        set
        {
            if (_isTigger != value)
            {
                _isTigger = value;

                this.OnBoolValueChanged(_isTigger); // 每当值发生变化时调用函数
            }
        }
    }

    public FruitTrees FruitCamp = FruitTrees.nullCamp;

    public GameObject UITypeTrue;

    public GameObject UITypeFalse;

    public Button SelectButton;

    public FruitRemainingPointsTigger remainingPoints;

    [SerializeField]
    public FruitInfoScriptObject fruitInfo;

    private void Awake()
    {
    }

    private float currentFillAmount = 0f;

    private bool onPicShow = false;

    public bool onPicHide = false;

    void Start()
    {
        var button = this.gameObject.GetComponent<Button>();

        button.targetGraphic = UITypeTrue.GetComponent<Image>();

        BtnEvent.RigisterButtonDownEvent(button.transform.gameObject, p => 
        {
            onPicShow = true;
            onPicHide = false;
        });

        BtnEvent.RigisterButtonUpEvent(button.transform.gameObject, p =>
        {
            onPicHide = true;
            onPicShow = false;
        });

        this.AfterStart();
    }

    private void Update()
    {
        if (onPicShow)
        {
            if (currentFillAmount < 1f)
            {
                currentFillAmount += 0.5f * Time.deltaTime;

                UITypeTrue.GetComponent<Image>().fillAmount = currentFillAmount;

                foreach (GameObject obj in FromObjects)
                {
                    obj.GetComponent<FruitTreeLineRender>().Line_True.GetComponent<Image>().fillAmount = currentFillAmount; ;
                }
            }
        }
        if (onPicHide)
        {
            if (currentFillAmount < 1f)
            {
                currentFillAmount -= 0.5f * Time.deltaTime;

                UITypeTrue.GetComponent<Image>().fillAmount = currentFillAmount;

                foreach (GameObject obj in FromObjects)
                {
                    obj.GetComponent<FruitTreeLineRender>().Line_True.GetComponent<Image>().fillAmount = currentFillAmount; ;
                }
            }
        }
    }

    void AfterStart()
    {
        this.ReadFruitInfo();

        // this.SetFruitStyle();

    }

    /// <summary>
    /// 读取完果实信息后设置果实状态
    /// </summary>
    void SetFruitStyle() 
    {
        Debug.Log(this.gameObject.name);

        if (fruitInfo == null) return;

        if (isTigger && remainingPoints.FruitUITiggerCheck(CostPointsInfo))
        {
            UITypeFalse.SetActive(false);

            UITypeTrue.SetActive(true);

            foreach (GameObject obj in ToObject)
            {
                obj.SetActive(true);

                obj.GetComponent<FruitTreeLineRender>().SetToUIObjects();
            }

            isTigger = true;
        }
        else
        {
            foreach (GameObject obj in ToObject)
            {
                obj.SetActive(true);

                obj.GetComponent<FruitTreeLineRender>().SetToUIObjectsFalse();
            }
        }
    }

    /// <summary>
    /// 当果实状态发生改变时，保存果实状态至本地
    /// </summary>
    /// <param name="_isTigger"></param>
    void OnBoolValueChanged(bool _isTigger)
    {
        if (fruitInfo == null) return;

        if (fruitInfo.isTigger && !_isTigger)
        {
            GameObject.FindObjectOfType<CampSelectManager>().SetTiggerFruitFalse(fruitInfo);
        }

        fruitInfo.isTigger = _isTigger;
    }

    /// <summary>
    /// 初始化时读取果实本地保存信息
    /// </summary>
    void ReadFruitInfo()
    {
        if (fruitInfo == null) return;

        isTigger = fruitInfo.isTigger;

        isRootFruit = fruitInfo.isRootFruit;

        isCampFruit = fruitInfo.isCampFruit;

        CostPointsInfo = fruitInfo.CostPointsInfo;

        FruitCamp = fruitInfo.FruitCamp;

        UITypeTrue.GetComponent<Image>().sprite = fruitInfo.FruitIconTiggered;

        UITypeFalse.GetComponent<Image>().sprite = fruitInfo.FruitIconNotTiggered;

    }

    /// <summary>
    /// 设置UI点亮状态
    /// </summary>
    public void SetLineTypeTrue() 
    {
        if (!isTigger && remainingPoints.FruitUITiggerCheck(CostPointsInfo))
        {
            UITypeFalse.SetActive(false);

            UITypeTrue.SetActive(true);

            foreach (GameObject obj in ToObject)
            {
                obj.SetActive(true);

                obj.GetComponent<FruitTreeLineRender>().SetToUIObjects();
            }

            isTigger = true;
        }
        else 
        {
            this.transform.DOShakePosition(0.5f, 10f, 10);
        }

    }

    /// <summary>
    /// 果实准备事件
    /// </summary>
    public void SetFruitTypeReady() 
    {
        this.gameObject.SetActive(true);

        SelectButton.onClick.AddListener(() => { SetSelectUIChange(); });
    }

    /// <summary>
    /// 设置UI关闭状态
    /// </summary>
    public void SetLineTypeFalse()
    {
        if (isTigger)
        {
            if (!isRootFruit && !isCampFruit)
            {
                UITypeFalse.SetActive(true);

                UITypeTrue.SetActive(false);
            }

            remainingPoints.FruitUITiggerForget(CostPointsInfo);

            foreach (GameObject obj in ToObject)
            {
                obj.GetComponent<FruitTreeLineRender>().SetToUIObjectsFalse();
            }

            isTigger = false;
        }
    }

    /// <summary>
    /// 果实尚未准备完成事件
    /// </summary>
    public void SetFruitTypeInPreparation()
    {
        if (!isRootFruit && !isCampFruit)
        {
            this.gameObject.SetActive(false);
            
        }
    }

    /// <summary>
    /// 设置果实交换图片
    /// </summary>
    private void SetSelectUIChange() 
    {
        Image image = UITypeTrue.GetComponent<Image>();

        if (fruitInfo == null || !fruitInfo.isTigger)
        {
            this.transform.DOShakePosition(0.5f, 10f, 10);

            return;
        }

        GameObject.FindObjectOfType<CampSelectManager>().ChangeImage(fruitInfo);
    }

    public override UIType GetUIType()
    {
        return UIType.None;
    }
}