using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_player : MonoBehaviour
{
    public float moveSpeed = 0.3f;
    public float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnGUI()
	{
        if(GUILayout.Button("START AGAIN"))
		{
            transform.position = new Vector3 (45.2f, 3.8f, 31.8f);
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
            transform.position -= new Vector3(0, 0, moveSpeed);
            transform.Rotate(turnSpeed, 0, 0);
		}
		if (Input.GetKey(KeyCode.S))
		{
            transform.position += new Vector3(0, 0, moveSpeed);
            transform.Rotate(-turnSpeed, 0, 0);
        }
		if (Input.GetKey(KeyCode.A))
		{
            transform.position += new Vector3(moveSpeed, 0, 0);
            transform.Rotate(0, 0, turnSpeed);
		}
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(moveSpeed, 0, 0);
            transform.Rotate(0, 0, -turnSpeed);
        }
    }
}
