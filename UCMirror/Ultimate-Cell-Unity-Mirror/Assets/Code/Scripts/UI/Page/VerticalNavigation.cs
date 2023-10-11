using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VerticalNavigation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform Content;

    public List<NavigationItem> Items = new List<NavigationItem>();

    private Vector3 lastPosition;

    private float offset;

    private float size;

    private float index0Y;

    private void Start()
    {
        size = Items[0].GetComponent<RectTransform>().rect.size.y;

        index0Y = Items[0].transform.localPosition.y;

        Items[1].TiggerBigObject();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        offset = eventData.position.y - lastPosition.y;

        lastPosition = eventData.position;

        for (int i = 0; i < Items.Count; i++)
        {
            Items[i].transform.localPosition += Vector3.up * offset;
        }

        if (offset > 0)
        {

            if (Items[0].transform.localPosition.y >= index0Y)
            {
                Items[Items.Count - 1].transform.localPosition = Items[Items.Count - 2].transform.localPosition - Vector3.up * size;
            }

            if (Items[0].transform.localPosition.y >= index0Y + size)
            {
                NavigationItem item = Items[0];

                item.transform.localPosition = Items[Items.Count - 1].transform.localPosition - Vector3.up * size;

                for (int i = 1; i < Items.Count; i++)
                {
                    Items[i - 1] = Items[i];
                }

                Items[Items.Count - 1] = item;

                for (int i = 1; i < Items.Count; i++)
                {
                    NavigationItem itemTigger = Items[i];

                    if (i == 2)
                    {
                        itemTigger.TiggerBigObject();

                    }
                    else
                    {
                        itemTigger.TiggerSmallObject();

                    }
                }
            }
        }

        if (offset < 0)
        {

            if (Items[0].transform.localPosition.y <= index0Y)
            {
                Items[Items.Count - 1].transform.localPosition = Items[0].transform.localPosition + Vector3.up * size;
            }

            if (Items[0].transform.localPosition.y <= index0Y - size)
            {
                NavigationItem item = Items[Items.Count - 1];

                item.transform.localPosition = Items[0].transform.localPosition + Vector3.up * size;

                for (int i = Items.Count - 1; i >= 1; i--)
                {
                    Items[i] = Items[i - 1];
                }

                Items[0] = item;

                for (int i = 1; i < Items.Count; i++)
                {
                    NavigationItem itemTigger = Items[i];

                    if (i == 2)
                    {
                        itemTigger.TiggerBigObject();

                    }
                    else
                    {
                        itemTigger.TiggerSmallObject();

                    }
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
