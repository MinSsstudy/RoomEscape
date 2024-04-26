using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] CameraController cameraCtr;
    [SerializeField] UIItemDescription uiItemDescription;


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
                    = hit.collider.gameObject.GetComponent<InteractableObject>();
                if (interactObj != null)
                {
                    cameraCtr.ZoomIn(interactObj);
                    ShowItemDescrition(interactObj.Item.Descrition);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            HideItemDescrition();
        }
    }

    public void ShowItemDescrition(string descrition)
    {
        uiItemDescription.gameObject.SetActive(true);
        uiItemDescription.ShowDescription(descrition);
    }

    public void HideItemDescrition()
    {
        cameraCtr.ZoomOut();
        uiItemDescription.gameObject.SetActive(false);
    }
}
