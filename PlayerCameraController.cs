using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour
{
    private CinemachineComposer composer;
    [SerializeField]
    private float senstivity=1f;
    private void Start()
    {
        composer=GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical=Input.GetAxis("Mouse Y")*senstivity;
        composer.m_TrackedObjectOffset.y+=vertical;
        composer.m_TrackedObjectOffset.y =Mathf.Clamp(composer.m_TrackedObjectOffset.y, -5, 5);
    }
}
