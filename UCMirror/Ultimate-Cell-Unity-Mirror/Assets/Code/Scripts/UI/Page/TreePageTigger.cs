using UnityEngine;
using static EventType;
using static TreeFruitPageManager;

public class TreePageTigger : MonoBehaviour 
{
    public FruitTrees fruitInfo;

    public void TiggerPage(FruitTrees item) 
    {
        if (item == fruitInfo)
        {
            SetPageOpen();
        }
        else 
        {
            SetPageClose();
        }
    }

    public void SetPageClose() 
    {
        this.gameObject.SetActive(false);
    }

    public void SetPageOpen()
    {
        this.gameObject.SetActive(true);
    }
}