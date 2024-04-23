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

    // ��Ʈ����Ʈ ����
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

    // Upcasting : �θ� Ŭ������ ȣ��
    //            ��) BoxCollider, SphereCollider -> Collider 
    // Downcasting : �ڽ� Ŭ������ ����ȯ
    //            �� ) (BoxCollider)collider


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

        // ���ӿ�����Ʈ �ν��Ͻ� �����ϴ� ���
        //GameObject g = new GameObject(); ����Ƽ���� �������� X
        //Instantiate(gameObject); ����Ƽ���� ����
    }
}
