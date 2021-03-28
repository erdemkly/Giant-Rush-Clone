using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    public CinemachineVirtualCamera[] virtualCameras;


    public void SetCamera(int index)
    {
        virtualCameras[index].gameObject.SetActive(true);
    }

    public void DeactiveCameraWithDelay(int index, float delay)
    {
        StartCoroutine(DeactiveCameraIE(index, delay));
    }

    IEnumerator DeactiveCameraIE(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactiveCamera(index);
    }

    public void DeactiveCamera(int index)
    {
        virtualCameras[index].gameObject.SetActive(false);
    }
}
