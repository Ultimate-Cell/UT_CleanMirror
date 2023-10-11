using UnityEngine;
using static EventType;
using static TreeFruitPageManager;

public class CampChangeSpineTigger : MonoBehaviour 
{
    public GameObject BaoSpine;
    public GameObject FinderSpine;
    public GameObject UltSpine;
    public GameObject WeakSpine;
    public GameObject VirusSpine;

    public void ChangeSpine(FruitTrees ChangeInfo) 
    {
        this.SetAllFalse();

        switch (ChangeInfo) 
        {
            case FruitTrees.nullCamp:
                UltSpine.SetActive(true);
                break;
            case FruitTrees.Technological:
                FinderSpine.SetActive(true);
                break;
            case FruitTrees.Environmentalism:
                UltSpine.SetActive(true);
                break;
            case FruitTrees.Socialism:
                BaoSpine.SetActive(true);
                break;
            case FruitTrees.FreeMarket:
                WeakSpine.SetActive(true);
                break;
            case FruitTrees.Mysticism:
                VirusSpine.SetActive(true);
                break;
        }
    }

    private void SetAllFalse() 
    {
        BaoSpine.SetActive(false);
        FinderSpine.SetActive(false);
        UltSpine.SetActive(false);
        WeakSpine.SetActive(false);
        VirusSpine.SetActive(false);
    }
}