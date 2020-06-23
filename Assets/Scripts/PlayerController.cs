using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float currentHp = 0;
    public float maxHp = 100f;

    public float moveSpeed = 1;

    public string horizontal = "Horizontal";
    public string vertical = "Vertical";
    public bool switchHV;

    public string speedParameter = "Speed";

    Animator animator;

    public Image hpUI;
    private AudioSource eatApple;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHp = maxHp;
        SetHp();
        eatApple = GetComponent<AudioSource>();
        eatApple.enabled = false;
    }

    void Update()
    {
        float h = Input.GetAxis(horizontal);
        float v = Input.GetAxis(vertical);
        Vector3 vec;
        if (switchHV) vec = new Vector3(v, 0, h);
        else vec = new Vector3(h, 0, v);

        if (h == 0 && v == 0)
        {
            animator.SetBool(speedParameter, false);
        }
        else
        {
            animator.SetBool(speedParameter, true);
        }
        transform.position += vec * moveSpeed * Time.deltaTime;
        if (vec != Vector3.zero)
        {
            transform.LookAt(transform.position + vec, Vector3.up);
        }
    }
    public void EatApple(float addHp)
    {
        if (!eatApple.enabled)
        {
            eatApple.enabled = true;
        }
        else
        {
            eatApple.Play();
        }
        AddHp(addHp);
    }

    public void SetHp()
    {
        hpUI.fillAmount = currentHp/maxHp;
    }

    public void AddHp(float addHp)
    {
        currentHp += addHp;
        SetHp();
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        SetHp();
    }

}
