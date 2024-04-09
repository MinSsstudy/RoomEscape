using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass
{
    public void Test()
    {
        Debug.Log("테스트 함수!");
    }
}

public class InteractableObject : MonoBehaviour
{
    // 마우스 클릭하면 해당 오브젝트 방향으로 카메라 확대되거나,
    // 대화 UI를 보여줌

    [SerializeField] private Vector3 cameraZoomPos;
    [SerializeField] private int cameraZoomSize = 6;
    Collider collider;


    private void Start()
    {
        collider = GetComponent<Collider>();

        //TestClass t = new TestClass();
        //t.Test();

        // 게임오브젝트 인스턴스 생성하는 방법
        //GameObject g = new GameObject(); 유니티에서 권장하지 X
        //Instantiate(gameObject); 유니티에서 권장
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = ;
            ZoomIn();
        }
    }

    void ZoomIn()
    {
        Camera.main.transform.position = cameraZoomPos;
        Camera.main.orthographicSize = cameraZoomSize;
    }

}
