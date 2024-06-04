using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] CameraController cameraCtr;

    Stack<ScreenOrder> prevOrders;
    ScreenOrder curOrder;


    protected override void Awake()
    {
        base.Awake();

        prevOrders = new Stack<ScreenOrder>();
        curOrder = new ScreenOrder(ViewType.RoomView);
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
                var interactObj
                    = hit.collider.GetComponent<InteractableObject>();
                if (interactObj != null)
                {
                    interactObj.Interact();

                    prevOrders.Push(curOrder);
                    curOrder = new ScreenOrder(interactObj);
                    ShowView(curOrder);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GoBack();
        }
    }

    void ShowView(ScreenOrder order)
    {
        if (order.cameraView == ViewType.RoomView)
        {
            cameraCtr.ZoomOut();
        }
        else
        {
            cameraCtr.ZoomIn(order.focusingObject);
            order.focusingObject.SwitchCollider(false);
        }

        UIManager.Instance.ShowScreenUI(order);
    }

    public void GoBack()
    {
        if (curOrder.cameraView != ViewType.RoomView)
            curOrder.focusingObject.SwitchCollider(true);

        if (prevOrders.Count > 0)
            curOrder = prevOrders.Pop();
        else
            curOrder = new ScreenOrder(ViewType.RoomView);

        ShowView(curOrder);
    }

    public void GoBackRoom()
    {
        for (int i = prevOrders.Count; i > 0; --i)
        {
            var order = prevOrders.Pop();
            if (order.cameraView != ViewType.RoomView)
                order.focusingObject.SwitchCollider(true);
        }

        curOrder = new ScreenOrder(ViewType.RoomView);
        ShowView(curOrder);
    }
}
