using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitInfoTigger : MonoBehaviour 
{
    public List<Button> TiggerButtons;

    public List<GameObject> TiggerObjects;

    private void Start()
    {
        for (int i = 0; i < TiggerButtons.Count; i++) 
        {
            var gameobj = TiggerObjects[i];

            TiggerButtons[i].onClick.AddListener(() => 
            {
                ButtonTiggerStyle(gameobj);
            });
        }
    }

    void ButtonTiggerStyle(GameObject obj) 
    {
        foreach (var gameObj in TiggerObjects) 
        {
            if (gameObj != obj)
            {
                gameObj.SetActive(false);
            }
        }

        obj.SetActive(!obj.activeSelf);
    }
}