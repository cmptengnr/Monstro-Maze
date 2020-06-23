using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float currentHp = 0;
    public float maxHp = 100f;

    public float Speed = 1;

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
        PlayerMovement();

        
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

    void PlayerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(h, 0f, v) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

    }

}
