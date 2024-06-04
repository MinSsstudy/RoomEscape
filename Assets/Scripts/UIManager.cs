using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewType
{
    RoomView,
    FurnitureView,
    ItemView,
}

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] UIInventory uiInventory;
    public UIInventory InvenUI
    {
        get { return uiInventory; }
    }

    [SerializeField] GameObject uiFurnitureView;
    [SerializeField] UIItemDescription uiItemDescription;


    public void ShowScreenUI(ScreenOrder order)
    {
        switch (order.cameraView)
        {
            case ViewType.RoomView:
                uiFurnitureView.SetActive(false);
                uiItemDescription.gameObject.SetActive(false);
                break;

            case ViewType.FurnitureView:
                uiFurnitureView.SetActive(true);
                uiItemDescription.gameObject.SetActive(false);
                break;

            case ViewType.ItemView:
                var itemObj = order.focusingObject as ItemObject;
                uiFurnitureView.SetActive(false);
                uiItemDescription.gameObject.SetActive(true);
                uiItemDescription.ShowDescription(itemObj.Item.Descrition);
                break;
        }
    }
}
