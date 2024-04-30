using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public enum CameraView
{
    RoomView,
    FurnitureView,
    ItemView
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] CameraController cameraCtr;
    [SerializeField] GameObject uiFurnitureView;
    [SerializeField] UIItemDescription uiItemDescription;

    CameraView curView = CameraView.RoomView;
    InteractableObject curFurniture;

    Inventory inventory;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        inventory = new Inventory();
    }

    private void Update()
    {
        // 마우스 왼쪽 키를 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            var origin = Camera.main.ScreenToWorldPoint(mousePos);
            var dir = Camera.main.transform.forward;
            Ray ray = new Ray(origin, dir);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, Camera.main.farClipPlane);
            if (hit.collider != null)
            {
                ShowView(hit.collider.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            HideItemDescrition();
        }
    }

    void ShowView(GameObject colliderObject)
    {
        switch(curView)
        {
            case CameraView.RoomView:
                var interactObj
                    = colliderObject.GetComponent<InteractableObject>();
                if (interactObj != null)
                {
                    curView = CameraView.FurnitureView;
                    cameraCtr.ZoomIn(interactObj);
                    uiFurnitureView.SetActive(true);
                    curFurniture = interactObj;
                    curFurniture.TurnOnCollider(false);
                }
                break;

            case CameraView.FurnitureView:
            case CameraView.ItemView:
                var itemObj = colliderObject.GetComponent<ItemObject>();
                if (itemObj != null)
                {
                    curView = CameraView.ItemView;
                    cameraCtr.ZoomIn(itemObj);
                    ShowItemDescrition(itemObj.Item.Descrition);
                    if (itemObj.Item.IsOwnable)
                    {
                        itemObj.TakeItem();
                        inventory.InsertItem(itemObj.Item);
                    }
                }
                break;
        }
    }

    public void ShowItemDescrition(string descrition)
    {
        uiFurnitureView.SetActive(false);
        uiItemDescription.gameObject.SetActive(true);
        uiItemDescription.ShowDescription(descrition);
    }

    public void HideItemDescrition()
    {
        GoBackRoom();
        uiItemDescription.gameObject.SetActive(false);
    }

    public void GoBackRoom()
    {
        cameraCtr.ZoomOut();
        uiFurnitureView.SetActive(false);
        curView = CameraView.RoomView;
        curFurniture.TurnOnCollider(true);
        curFurniture = null;
    }
}
