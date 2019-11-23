﻿using System;
using System.Collections;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;

    public float maxHealth = 100;
    private float currentHealth;
    private Animator animator;
    //private float delay = 0.5f;


    void Start()
    {
        bar = transform.Find("Bar");
        currentHealth = maxHealth;
        SetSize(1.0f);
        animator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    ChangeHealth();
    //}

    public void BeAttacked(float damage)
    {
        if (damage > 0)
        {
            bool characterDies = (currentHealth - damage) <= 0;
            currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        

            ChangeHealth();

            if (characterDies)
            {
                StartCoroutine(KillCharacter());
            }
        }
    }

    IEnumerator KillCharacter()
    {
        var aniLength = gameObject.GetComponent<Animation>()[AnimationName.IS_DYING].length;
        animator.SetTrigger(AnimationName.IS_DYING);
        AnimatorStateInfo currInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(currInfo.length);
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        Destroy(gameObject);
    }


    public void Recuperate(float blood)
    {
        if (blood > 0)
        {
            currentHealth += blood;
            ChangeHealth();
        }
    }

    private void ChangeHealth()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        float bloodPecent = currentHealth / maxHealth;
        SetSize(bloodPecent);
    }

    private void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }

    internal object Find(string v)
    {
        throw new NotImplementedException();
    }

    private void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }


}
