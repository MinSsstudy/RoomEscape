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

    // 어트리뷰트 문법
    [SerializeField] protected ItemData itemData;
    public ItemData Item
    {
        get
        {
            return itemData;
        }
    }
    [SerializeField] protected Vector3 cameraZoomPos;
    public Vector3 CameraZoomPos
    {
        get
        {
            return cameraZoomPos;
        }
    }
    [SerializeField] protected float cameraZoomSize = 6f;
    public float CameraZoomSize
    {
        get
        {
            return cameraZoomSize;
        }
    }

    // Upcasting : 부모 클래스로 호출
    //            예) BoxCollider, SphereCollider -> Collider 
    // Downcasting : 자식 클래스로 형변환
    //            예 ) (BoxCollider)collider


    protected void Start()
    {
        /*
        if (cameraCtr == null)
        {
            cameraCtr = FindObjectOfType<CameraController>();
        }*/
        //collider = GetComponent<Collider>();

        //TestClass t = new TestClass();
        //t.Test();

        // 게임오브젝트 인스턴스 생성하는 방법
        //GameObject g = new GameObject(); 유니티에서 권장하지 X
        //Instantiate(gameObject); 유니티에서 권장
    }
}
