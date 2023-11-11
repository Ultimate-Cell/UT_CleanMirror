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

    public void SetShowText(int points)
    {
        ShowText.text = points + "";

    }

    public bool SetShowTextCost(int Cost)
    {
        var residue = StartPoint - Cost;

        if (residue < 0)
        {
            return false;
        }
        else
        {
            StartPoint = residue;

            this.SetShowText(StartPoint);

            return true;
        }
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

            return true;
        }
    }

    public void FruitUITiggerForget(int Cost) 
    {
        StartPoint = StartPoint + Cost;

        this.SetShowText(StartPoint);
    }
}