using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static EventType;

public class TreeFruitPageManager : MonoBehaviour 
{
    public Button ClosePageButton;

    public UnityAction<FruitTrees> FruitTreeTiggerAction;

    public List<TreePageTigger> TreePageInfos;

    public CampSelectManager campSelectManager;

    public CampChangeSpineTigger campCHangeSpine;

    private void Start()
    {
        ClosePageButton.onClick.AddListener( () => { ClosePage(); });

        foreach (TreePageTigger tigger in TreePageInfos) 
        {
            FruitTreeTiggerAction += tigger.TiggerPage;
        }

        FruitTreeTiggerAction += campSelectManager.OnCampChangeSelect;

        FruitTreeTiggerAction += campCHangeSpine.ChangeSpine;
    }

    void ClosePage() 
    {
        this.gameObject.SetActive(false);
    }

    void TiggerFuritTree(FruitTrees Item) 
    {
    }
}