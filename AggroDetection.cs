using System;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate {};
    public bool detectionChk=false;

private void OnTriggerEnter(Collider Detect)
{
    var player=Detect.GetComponent<PlayerMovement>();
    if(player!=null && gameObject.activeSelf==true)
    {
        OnAggro(player.transform);
        detectionChk=true;
    }
}
private void OnTriggerExit(Collider Detect)
{
    detectionChk=false;
}
}
