using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_follow : MonoBehaviour
{
    public GameObject obj;
    public float y = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = obj.transform.position.x;
        float z = obj.transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
