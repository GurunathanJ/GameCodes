using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f,0.5f)]
    private float fireRate=0.5f;

    [SerializeField]
    [Range(1,10)]
    private int damage=1;

    // [SerializeField]
    // private Transform FirePt;

    [SerializeField]
    private ParticleSystem MuzzleFire;

    private float timer;


    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>=fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer=0f;
                RayGun();
            }
        }
    }

    private void RayGun()
    {
        //Debug.DrawRay(FirePt.position, FirePt.forward*100, Color.red, 2f);
        MuzzleFire.Play();

        //Ray ray=new Ray(FirePt.position, FirePt.forward);
        Ray ray=Camera.main.ViewportPointToRay(Vector3.one*0.5f);
        Debug.DrawRay(ray.origin, ray.direction*100, Color.red, 2f);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<EnemyHealth>();

            if(health!=null)
            health.TakeDamage(damage);
        }
    }
}
