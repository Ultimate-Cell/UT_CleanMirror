using System.Collections.Generic;
using UnityEngine;

public class FruitTreeLineRender : MonoBehaviour 
{
    public List<GameObject> ToUIObjects= new List<GameObject>();

    public GameObject Line_True;

    public GameObject Line_False;

    private void Start()
    {
        this.gameObject.SetActive(false);
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