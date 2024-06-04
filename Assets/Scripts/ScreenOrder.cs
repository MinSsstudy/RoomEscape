using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScreenOrder
{
    public ViewType cameraView;
    public InteractableObject focusingObject;

    public ScreenOrder(ViewType cameraView)
    {
        this.cameraView = cameraView;
        focusingObject = null;
    }

    public ScreenOrder(InteractableObject focusing)
    {
        cameraView = focusing.CameraView;
        focusingObject = focusing;
    }
}