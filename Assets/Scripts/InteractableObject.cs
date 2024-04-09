using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass
{
    public void Test()
    {
        Debug.Log("�׽�Ʈ �Լ�!");
    }
}

public class InteractableObject : MonoBehaviour
{
    // ���콺 Ŭ���ϸ� �ش� ������Ʈ �������� ī�޶� Ȯ��ǰų�,
    // ��ȭ UI�� ������

    [SerializeField] private Vector3 cameraZoomPos;
    [SerializeField] private int cameraZoomSize = 6;
    Collider collider;


    private void Start()
    {
        collider = GetComponent<Collider>();

        //TestClass t = new TestClass();
        //t.Test();

        // ���ӿ�����Ʈ �ν��Ͻ� �����ϴ� ���
        //GameObject g = new GameObject(); ����Ƽ���� �������� X
        //Instantiate(gameObject); ����Ƽ���� ����
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            var origin = Camera.main.ScreenToWorldPoint(mousePos);
            var dir = Camera.main.transform.forward;
            Ray ray = new Ray(origin, dir);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, Camera.main.farClipPlane);
            if (hit.collider == collider)
            {
                ZoomIn();
            }
        }
    }

    void ZoomIn()
    {
        Camera.main.transform.position = cameraZoomPos;
        Camera.main.orthographicSize = cameraZoomSize;
    }

}
