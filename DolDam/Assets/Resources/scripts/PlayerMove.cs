using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotSpeed = 90f;
    public float scaleSpeed = 0.2f;
    public float rollSpeed = 2f;
    public float ballScale = 5f;
    public float feverScale = 14f;
    public int dir;
    public int beforeDir;

    private float width;
    private float ScreenWidth;

    public GameObject SnowParticle;


    // Use this for initialization
    void Start()
    {
        dir = 0;
        moveSpeed = 7f;
        rotSpeed = 90f;
        scaleSpeed = 0.2f;
        rollSpeed = 2f;
        ballScale = 5f;
        width = GetComponent<SpriteRenderer>().sprite.rect.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        ScreenWidth = Screen.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            SetScale(ballScale + scaleSpeed * Time.deltaTime);
            GameManager.instance.SetScrollSpeed(ballScale * rollSpeed);
            MoveAndRotate();
            KeepInScreen();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        ObstacleScroll os = col.gameObject.GetComponent<ObstacleScroll>();
        if (os != null)
        {
            if (os.GetIsHit() == false)
            {
                if (col.tag == "Snowman")
                {
                    os.HitByPlayer();
                    SetScale(ballScale + 1f);
                    Destroy(col.gameObject);
                }
                else if (col.tag == "Wall")
                {   
                    GameObject p = Instantiate(SnowParticle, col.transform.position, Quaternion.identity);
                    p.transform.localScale = p.transform.localScale * ballScale / 2;
                    Destroy(p, 2f);
                    os.HitByPlayer();
                    SetScale(ballScale/2f);
                }
            }
        }
    }

    void SetScale(float scale)
    {
        if (scale <= 2f)
            return;
        ballScale = scale;
        transform.localScale = new Vector2(ballScale, ballScale);
    }
    
    void MoveAndRotate()
    {
        dir = 0;
        if (InputLeftPC())
        {
            transform.position += new Vector3(-moveSpeed + ballScale / 5, 0) * Time.deltaTime;
            dir = -1;
            beforeDir = -1;
            if (transform.rotation.z <= 0.2 && transform.rotation.z >= -0.2)
                transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }
        if (InputRightPC())
        {
            transform.position += new Vector3(moveSpeed + ballScale / 5, 0) * Time.deltaTime;
            dir = 1;
            beforeDir = 1;
            if (transform.rotation.z <= 0.2 && transform.rotation.z >= -0.2)
                transform.Rotate(Vector3.forward * -rotSpeed * Time.deltaTime);
        }
        if (dir == 0)
            transform.Rotate(new Vector3(0, 0, rotSpeed / 1.5f * beforeDir) * Time.deltaTime);
        if (beforeDir * transform.rotation.z > 0)
        {
            transform.rotation = Quaternion.identity;
            beforeDir = 0;
        }
    }

    void KeepInScreen()
    {
        Debug.Log(ScreenWidth);
        if (transform.position.x - width * ballScale / 2 < -ScreenWidth / 2)
            transform.position = new Vector2(width * ballScale / 2 - ScreenWidth / 2, transform.position.y);
        else if (transform.position.x + width * ballScale / 2 > ScreenWidth / 2)
            transform.position = new Vector2(ScreenWidth / 2 - width * ballScale / 2, transform.position.y);
    }



    bool InputLeftPC()
    {
        if (Input.GetKey(KeyCode.A))
            return true;
        return false;
    }
    bool InputRightPC()
    {
        if (Input.GetKey(KeyCode.D))
            return true;
        return false;
    }

    bool InputLeft()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return true;
        }
        return false;
    }
    bool InputRight()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return true;
        }
        return false;
    }
}
