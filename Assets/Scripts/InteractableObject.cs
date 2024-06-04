using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    // ���콺 Ŭ���ϸ� �ش� ������Ʈ �������� ī�޶� Ȯ��ǰų�,
    // ��ȭ UI�� ������

    [SerializeField] protected Vector3 cameraZoomPos;
    public Vector3 CameraZoomPos
    {
        get { return cameraZoomPos; }
    }

    [SerializeField] protected float cameraZoomSize = 6f;
    public float CameraZoomSize
    {
        get { return cameraZoomSize; }
    }

    [SerializeField] protected ViewType cameraView;
    public ViewType CameraView
    {
        get { return cameraView; }
    }
    
    protected Collider collider;
    // Upcasting : �θ� Ŭ������ ȣ��
    //            ��) BoxCollider, SphereCollider -> Collider 
    // Downcasting : �ڽ� Ŭ������ ����ȯ
    //            �� ) (BoxCollider)collider


    protected virtual void Start()
    {
        collider = GetComponent<Collider>();
    }

    public virtual void Interact() { }

    public void SwitchCollider(bool isOn)
    {
        collider.enabled = isOn;
    }
}
