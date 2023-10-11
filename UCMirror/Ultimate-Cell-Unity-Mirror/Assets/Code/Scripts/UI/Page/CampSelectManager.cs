using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static EventType;
using static TreeFruitPageManager;

public class CampSelectManager : MonoBehaviour
{
    public Sprite FruitFalseIcon;

    [Header("不要配置 -- 果实配置暂存区")]
    public CampSelectInfoTigger activeTigger;

    [Header("UI显示脚本")]
    public List<CampSelectInfoTigger> selectInfoTiggers;

    [Header("当前保存地址")]
    public FruitSelectInfoScriptObject nowSelectInfo;

    [Header("本地保存区")]
    [SerializeField]
    public List<FruitSelectInfoScriptObject> selectInfoList;

    private void Start()
    {
        foreach (CampSelectInfoTigger info in selectInfoTiggers) 
        {
            info.onChangeButton.onClick.AddListener(() => { ButtonClickType(info); });
        }

        if (selectInfoList.Count != 0) 
        {
            Debug.Log(selectInfoList[0].Name);
        }

        this.ReadStartNowSelectInfo();
    }

    public void OnCampChangeSelect(FruitTrees campInfo) 
    {
        foreach (FruitSelectInfoScriptObject info in selectInfoList) 
        {
            if (info.FruitSelectCamp == campInfo) 
            {
                info.FreelyCampFruit1 = nowSelectInfo.FreelyCampFruit1;

                info.FreelyCampFruit2 = nowSelectInfo.FreelyCampFruit2;

                info.FreelyCampFruit3 = nowSelectInfo.FreelyCampFruit3;

                var sprite = info.NecessaryCampFruit != null ? info.NecessaryCampFruit.FruitIconTiggered : FruitFalseIcon;

                selectInfoTiggers[0].gameObject.GetComponent<Image>().sprite = sprite;

                nowSelectInfo = info;

                break;
            }
        }
    }

    void ReadStartNowSelectInfo() 
    {
        foreach (CampSelectInfoTigger type in selectInfoTiggers)
        {
            FruitInfoScriptObject set = null;

            var location = type.UILocation;

            switch (location)
            {
                case 0:
                    set = nowSelectInfo.NecessaryCampFruit;
                    break;
                case 1:
                    set = nowSelectInfo.FreelyCampFruit1;
                    break;
                case 2:
                    set = nowSelectInfo.FreelyCampFruit2;
                    break;
                case 3:
                    set = nowSelectInfo.FreelyCampFruit3;
                    break;
            }

            if (set != null) 
            {
                if (set.isTigger)
                {
                    type.gameObject.GetComponent<Image>().sprite = set.FruitIconTiggered;
                }
                else 
                {
                    set = null;
                }
            }
        }
    }

    void ButtonClickType(CampSelectInfoTigger info) 
    {
        var active = !info.onChangeTiggerStyle.activeSelf;

        foreach (CampSelectInfoTigger type in selectInfoTiggers) 
        {
            type.onChangeTiggerStyle.SetActive(false);
        }

        info.onChangeTiggerStyle.SetActive(active);

        if (active)
        {
            activeTigger = info;
        }
        else 
        {
            activeTigger = null;
        }
    }

    public void ChangeImage(FruitInfoScriptObject fruitInfo) 
    {
        if (activeTigger != null) 
        {
            activeTigger.gameObject.GetComponent<Image>().sprite = fruitInfo.FruitIconTiggered;

            var location = activeTigger.UILocation;

            switch (location) 
            {
                case 0:
                    nowSelectInfo.NecessaryCampFruit = fruitInfo;
                    break;
                case 1:
                    nowSelectInfo.FreelyCampFruit1 = fruitInfo;
                    break;
                case 2:
                    nowSelectInfo.FreelyCampFruit2 = fruitInfo;
                    break;
                case 3:
                    nowSelectInfo.FreelyCampFruit3 = fruitInfo;
                    break;

            }
        }
    }

    public void SetTiggerFruitFalse(FruitInfoScriptObject fruitInfo) 
    {
        if (nowSelectInfo.NecessaryCampFruit == fruitInfo) 
        {
            selectInfoTiggers[0].gameObject.GetComponent<Image>().sprite = FruitFalseIcon;

            nowSelectInfo.NecessaryCampFruit = null;
        }
        if (nowSelectInfo.FreelyCampFruit1 == fruitInfo)
        {
            selectInfoTiggers[1].gameObject.GetComponent<Image>().sprite = FruitFalseIcon;

            nowSelectInfo.FreelyCampFruit1 = null;
        }
        if (nowSelectInfo.FreelyCampFruit2 == fruitInfo)
        {
            selectInfoTiggers[2].gameObject.GetComponent<Image>().sprite = FruitFalseIcon;

            nowSelectInfo.FreelyCampFruit2 = null;
        }
        if (nowSelectInfo.FreelyCampFruit3 == fruitInfo)
        {
            selectInfoTiggers[3].gameObject.GetComponent<Image>().sprite = FruitFalseIcon;

            nowSelectInfo.FreelyCampFruit3 = null;
        }
    }
}