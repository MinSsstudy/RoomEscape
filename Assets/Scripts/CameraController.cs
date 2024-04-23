using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 cameraPos;
    float cameraSize;
    InteractableObject curZoomObj = null;


    private void Start()
    {
        cameraPos = transform.position;
        cameraSize = GetComponent<Camera>().orthographicSize;
    }

    public void ZoomIn(InteractableObject zoomObj)
    {
        if (curZoomObj != null) return;

        curZoomObj = zoomObj;
        Vector3 cameraZoomPos = zoomObj.CameraZoomPos;
        float cameraZoomSize = zoomObj.CameraZoomSize;

        if (cameraAniCoroutin != null)
        {
            StopCoroutine(cameraAniCoroutin);
        }
        cameraAniCoroutin = IECameraZoomAni(cameraZoomPos, cameraZoomSize);
        StartCoroutine(cameraAniCoroutin);

        //Camera.main.transform.position = cameraZoomPos;
        //Camera.main.orthographicSize = cameraZoomSize;
    }

    public void ZoomOut()
    {
        curZoomObj = null;
        if (cameraAniCoroutin != null)
        {
            StopCoroutine(cameraAniCoroutin);
        }
        cameraAniCoroutin = IECameraZoomAni(cameraPos, cameraSize);
        StartCoroutine(cameraAniCoroutin);

        //Camera.main.transform.position = cameraPos;
        //Camera.main.orthographicSize = cameraSize;
    }

    IEnumerator cameraAniCoroutin = null;
    IEnumerator IECameraZoomAni(Vector3 zoomPos, float zoomSize)
    {
        bool isZooming = true;
        while (isZooming)
        {
            var pos = Vector3.Lerp(Camera.main.transform.position, zoomPos, 0.2f);
            var size = Mathf.Lerp(Camera.main.orthographicSize, zoomSize, 0.2f);
            Camera.main.transform.position = pos;
            Camera.main.orthographicSize = size;

            yield return new WaitForSeconds(0.02f);

            if (Vector3.Distance(zoomPos, pos) < 0.1f
                && Mathf.Abs(zoomSize - size) < 0.1f)
            {
                isZooming = false;
            }
        }
    }
}
