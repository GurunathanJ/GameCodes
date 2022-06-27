using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
[SerializeField]
private int startHealth = 5;
private int currentHealth;
private Animator animator;
public HealthBar healthBar;
public GameObject CanvasObj;

private void Awake()
{
    animator=GetComponentInChildren<Animator>();
}

void Start()
{
    healthBar.SliderMaxhealth(startHealth);
    CanvasObj=GetComponent<GameObject>();
}

private void OnEnable()
{
    currentHealth=startHealth;
}


public void TakeDamage(int damageAmount)
{
    currentHealth-=damageAmount;
    healthBar.SetHealth(currentHealth);
    if(currentHealth<=0)
    {
    healthBar.gameObject.SetActive(false);
    CharacterDie();
    }
}

private void CharacterDie()
{
    animator.SetBool("Dying",true);
    //gameObject.SetActive(false);
}
}
