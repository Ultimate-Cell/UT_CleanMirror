using UnityEngine;
using static EventType;
using static TreeFruitPageManager;

public class NavigationItem : MonoBehaviour 
{
    public GameObject BigTigger;

    public GameObject SmallTigger;

    public FruitTrees fruitInfo;

    public TreeFruitPageManager treeManager;

    public void TiggerBigObject() 
    {
        BigTigger.SetActive(true);

        SmallTigger.SetActive(false);

        if (treeManager.FruitTreeTiggerAction != null)
        {
            treeManager.FruitTreeTiggerAction(fruitInfo);
        }
    }

    public void TiggerSmallObject()
    {
        BigTigger.SetActive(false);

        SmallTigger.SetActive(true);
    }
}