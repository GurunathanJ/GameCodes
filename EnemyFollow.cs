using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private float speed=3.5f;
    [SerializeField]
    private GameObject target;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed",speed);
        transform.LookAt(target.gameObject.transform);
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }
}
