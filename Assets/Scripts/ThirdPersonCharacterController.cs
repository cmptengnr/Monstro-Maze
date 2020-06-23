using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

    public float Speed;
    
    void Update()
    {
        PlayerMovement();
        
    }

    
    void PlayerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(h, 0f, v) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

    }
}
