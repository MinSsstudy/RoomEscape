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

    protected Collider collider;
    // Upcasting : �θ� Ŭ������ ȣ��
    //            ��) BoxCollider, SphereCollider -> Collider 
    // Downcasting : �ڽ� Ŭ������ ����ȯ
    //            �� ) (BoxCollider)collider


    protected virtual void Start()
    {
        collider = GetComponent<Collider>();

        // ���ӿ�����Ʈ �ν��Ͻ� �����ϴ� ���
        //GameObject g = new GameObject(); ����Ƽ���� �������� X
        //Instantiate(gameObject); ����Ƽ���� ����
    }

    public void TurnOnCollider(bool isOn)
    {
        collider.enabled = isOn;
    }
}
