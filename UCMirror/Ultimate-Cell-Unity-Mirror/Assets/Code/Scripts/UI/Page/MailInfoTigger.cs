using UnityEngine;
using UnityEngine.UI;

public class MailInfoTigger : MonoBehaviour 
{
    public Button tiggerButton;

    public GameObject OpenType;

    public GameObject CloseType;

    public MailInfoPageManager pageManager;

    private void Start()
    {
        tiggerButton.onClick.AddListener(() => 
        {
            ChangeType("Open");

            pageManager.MiddleShowPage.SetActive(true);
        });
    }

    void ChangeType(string _page)
    {
        switch (_page)
        {
            case "Open":
                OpenType.SetActive(true);
                CloseType.SetActive(false);
                break;
        }

    }
}