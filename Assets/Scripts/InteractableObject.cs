using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    // 마우스 클릭하면 해당 오브젝트 방향으로 카메라 확대되거나,
    // 대화 UI를 보여줌

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
    // Upcasting : 부모 클래스로 호출
    //            예) BoxCollider, SphereCollider -> Collider 
    // Downcasting : 자식 클래스로 형변환
    //            예 ) (BoxCollider)collider


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
