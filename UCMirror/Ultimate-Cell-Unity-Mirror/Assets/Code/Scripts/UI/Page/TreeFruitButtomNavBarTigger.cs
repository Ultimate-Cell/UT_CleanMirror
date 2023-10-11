using UnityEngine;
using UnityEngine.UI;

public class TreeFruitButtomNavBarTigger : MonoBehaviour 
{
    public Button LeftButton;

    public Button RightButton;

    public GameObject Light1;

    public GameObject Light2;

    public GameObject TreePage;

    public GameObject CampPage;

    private void Start()
    {
        LeftButton.onClick.AddListener(() => { LeftButtonClick(); });

        RightButton.onClick.AddListener(() => { RightButtonClick(); });
    }

    void LeftButtonClick() 
    {
        TreePage.SetActive(false);

        CampPage.SetActive(true);

        Light1.SetActive(true);

        Light2.SetActive(false);
    }

    void RightButtonClick()
    {
        TreePage.SetActive(true);

        CampPage.SetActive(false);

        Light1.SetActive(false);

        Light2.SetActive(true);

    }
}