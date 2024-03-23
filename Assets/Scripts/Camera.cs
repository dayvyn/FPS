using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    Gun gunScript;
    // Start is called before the first frame update
    void Start()
    {
        gunScript = FindObjectOfType<Gun>().GetComponent<Gun>();
        gunScript.onShoot += ScreenShake;
    }

    void StartScreenShake()
    {
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 5;
    }
    void EndScreenShake()
    {
        vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    IEnumerator CameraShakeTime()
    {
        StartScreenShake();
        yield return new WaitForSeconds(.1f);
        EndScreenShake();
    }

    void ScreenShake()
    {
        StartCoroutine(CameraShakeTime());
    }
}
