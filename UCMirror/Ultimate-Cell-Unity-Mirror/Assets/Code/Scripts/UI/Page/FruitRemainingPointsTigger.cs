using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitRemainingPointsTigger : MonoBehaviour 
{
    public int StartPoint;

    public TextMeshProUGUI ShowText;

    public Button ResetTiggerButton;

    public FruitTreeUITigger MainRootTigger;

    private void Start()
    {
        this.SetShowText(StartPoint);

        ResetTiggerButton.onClick.AddListener(() => { MainRootTigger.SetLineTypeFalse(); });
    }

    private void SetShowText(int points)
    {
        ShowText.text = points + "";

    }

    public bool FruitUITiggerCheck(int Cost) 
    {
        var residue = StartPoint - Cost;

        if (residue < 0)
        {
            return false;
        }
        else 
        {
            StartPoint = residue;

            this.SetShowText(residue);

            return true;
        }
    }

    public void FruitUITiggerForget(int Cost) 
    {
        StartPoint = StartPoint + Cost;

        this.SetShowText(StartPoint);
    }
}