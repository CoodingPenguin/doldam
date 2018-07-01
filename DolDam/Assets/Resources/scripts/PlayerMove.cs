using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private float moveSpeed = 5f;
    private float rotSpeed = 90f;
    public int dir;
    public int beforeDir;

    

	// Use this for initialization
	void Start () {
        dir = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        dir = 0;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed, 0) * Time.deltaTime;
            dir = -1;
            //if (beforeDir == 0)
                beforeDir = -1;
            if (transform.rotation.z <= 0.2 && transform.rotation.z >= -0.2)
                transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0) * Time.deltaTime;
            dir = 1;
            //if(beforeDir==0)
                beforeDir = 1;
            if (transform.rotation.z <=0.2 && transform.rotation.z >= -0.2)
                transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
        }
        if(dir==0)
            transform.Rotate(new Vector3(0, 0, rotSpeed/1.5f * beforeDir)*Time.deltaTime);
        if (beforeDir * transform.rotation.z > 0)
        {
            transform.rotation = Quaternion.identity;
            beforeDir = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D");
    }
}
