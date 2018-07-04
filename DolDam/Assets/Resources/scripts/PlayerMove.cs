using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour {

    private float moveSpeed = 5f;
    private float rotSpeed = 90f;
    private float scaleSpeed = 0.1f;
    private float rollSpeed = 1f;
    private float ballScale = 1f;
    public int dir;
    public int beforeDir;

    

	// Use this for initialization
	void Start () {
        dir = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            dir = 0;
            GameManager.instance.SetScrollSpeed(GameManager.instance.GetScrollSpeed() + rollSpeed * Time.deltaTime);
            SetScale(ballScale + scaleSpeed * Time.deltaTime * GameManager.instance.GetScrollSpeed() / 10f);
            if (Input.GetMouseButton(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (Input.mousePosition.x < Screen.width / 2)
                    {
                        transform.position += new Vector3(-moveSpeed, 0) * Time.deltaTime;
                        dir = -1;
                        //if (beforeDir == 0)
                        beforeDir = -1;
                        if (transform.rotation.z <= 0.2 && transform.rotation.z >= -0.2)
                            transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position += new Vector3(moveSpeed, 0) * Time.deltaTime;
                        dir = 1;
                        //if(beforeDir==0)
                        beforeDir = 1;
                        if (transform.rotation.z <= 0.2 && transform.rotation.z >= -0.2)
                            transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (Input.mousePosition.y > Screen.height / 3 * 2)
                    {
                        GameManager.instance.SetScrollSpeed(GameManager.instance.GetScrollSpeed() + 1f);
                    }
                    else if (Input.mousePosition.y < Screen.height / 4)
                    {
                        bool suceedBoost;
                        suceedBoost = GameManager.instance.SetScrollSpeed(GameManager.instance.GetScrollSpeed() - 1f);
                        if (suceedBoost)
                        {
                            SetScale(ballScale - 0.1f);

                        }
                    }
                }
            }

            if (dir == 0)
                transform.Rotate(new Vector3(0, 0, rotSpeed / 1.5f * beforeDir) * Time.deltaTime);
            if (beforeDir * transform.rotation.z > 0)
            {
                transform.rotation = Quaternion.identity;
                beforeDir = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D");
        ObstacleScroll os = col.gameObject.GetComponent<ObstacleScroll>();
        if(os!=null)
        {
            if (os.GetIsHit() == false)
            {
                os.HitByPlayer();
                SetScale(ballScale - 0.5f);
                GameManager.instance.SetScrollSpeed(GameManager.instance.GetScrollSpeed() - 5f);
            }
        }
    }

    void SetScale(float scale)
    {
        if (scale <= 0.1)
            return;
        ballScale = scale;
        transform.localScale = new Vector2(ballScale, ballScale);
    }
    
}
