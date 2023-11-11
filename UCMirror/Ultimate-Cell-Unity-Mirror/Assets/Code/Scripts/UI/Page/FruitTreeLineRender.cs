using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitTreeLineRender : MonoBehaviour 
{
    public List<GameObject> ToUIObjects= new List<GameObject>();

    public GameObject Line_True;

    public GameObject Line_False;

    private bool shakeOnce = false;

    private void Start()
    {
    }

    private void Update()
    {
        var fill = Line_True.GetComponent<Image>().fillAmount;

        if (!(fill < 1) && !shakeOnce)
        {
            foreach (GameObject go in ToUIObjects)
            {
                go.transform.DOShakePosition(0.5f, 10f, 10);

                var gocom = go.GetComponent<FruitTreeUITigger>();

                gocom.remainingPoints.SetShowTextCost(gocom.CostPointsInfo);

                shakeOnce = true;
            }
        }
    }

    /// <summary>
    /// 点亮果实UI
    /// </summary>
    public void SetToUIObjects()
    {
        this.gameObject.SetActive(true);

        Line_True.SetActive(true);

        Line_False.SetActive(false);

        foreach (GameObject go in ToUIObjects) 
        {
            go.GetComponent<FruitTreeUITigger>().SetFruitTypeReady();
        }
    }

    public void SetToUIObjectsFalse()
    {
        this.gameObject.SetActive(false);

        Line_True.SetActive(false);

        Line_False.SetActive(true);

        foreach (GameObject go in ToUIObjects)
        {
            go.GetComponent<FruitTreeUITigger>().SetLineTypeFalse();

            go.GetComponent<FruitTreeUITigger>().SetFruitTypeInPreparation();
        }

    }

}