﻿using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{

    public bool isDead;

    public float moveSpeed;
    public float rotSpeed;
    public float rollSpeed;
    public float ballScale;
    public float minScale;
    public float scaleSpeed;
    private int dir;
    private int beforeDir;

    private float width;
    private float ScreenWidth;

    public float feverDuration;
    public float scaleAtFever;
    public float goToFeverScale;
    private float feverETime = 0f;

    public float snowManScale;
    public float obstacleScale;

    public GameObject SnowParticle;
    public GameObject feverParticle;
    public GameObject crashParticle;
    public GameObject snowmanParticle;

    public AudioClip bgmSound;

    public AudioClip colliSnow1;
    public AudioClip colliSnow2;
    public AudioClip colliSnow3;
    public AudioClip colliWall1;
    public AudioClip colliWall2;
    public AudioClip colliWall3;
    public AudioClip colliFever;
    public AudioClip feverStart;
    public AudioClip feverEnd;


    // Use this for initialization
    void Start()
    {
        isDead = false;

        width = GetComponent<SpriteRenderer>().sprite.rect.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
 
        ScreenWidth = 10.8f;
        SoundManager.instance.PlayBgm(bgmSound, true);
        Debug.Log("width:" + width);
        Debug.Log("swidth:" + ScreenWidth);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            if(isDead)
            {
                //게임오버
                //return;

            }
            GameManager.instance.SetScrollSpeed(ballScale * rollSpeed);
            if (GameManager.instance.feverState == 0) //평상시
            {
                SetScale(ballScale + scaleSpeed * Time.deltaTime);
                MoveAndRotate();
                if (ballScale >= goToFeverScale)
                {
                    SoundManager.instance.PlaySingle(feverStart);
                    GameManager.instance.feverState = 1;
                    SetScale(goToFeverScale);
                    GameObject p = Instantiate(feverParticle, transform.position, Quaternion.identity);
                    p.transform.localScale = p.transform.localScale * ballScale / 2;
                    Destroy(p, 2f);
                }
            }
            else if (GameManager.instance.feverState == 1)    //평상시->피버모드로 전환
            {
                
                transform.position = Vector2.Lerp(transform.position, new Vector2(0, transform.position.y), 7 * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 7 * Time.deltaTime);
                transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(scaleAtFever, scaleAtFever), 7 * Time.deltaTime);
                if (transform.localScale.x >= scaleAtFever - 1)
                {
                    GameManager.instance.feverState = 2;
                    transform.position = new Vector2(0, transform.position.y);
                    transform.rotation = Quaternion.identity;
                }
                GameManager.instance.SetScrollSpeed(5);
            }
            else if (GameManager.instance.feverState == 2) //피버모드
            {
                MoveAndRotate();
                SetScale(scaleAtFever);
                feverETime += Time.deltaTime;
                if (feverETime > feverDuration) //피버모드 종료
                {
                    SoundManager.instance.PlaySingle(feverEnd);
                    GameObject p = Instantiate(SnowParticle, transform.position, Quaternion.identity);
                    p.transform.localScale = p.transform.localScale * ballScale / 2.5f;
                    Destroy(p, 2f);
                    SetScale(6);
                    GameManager.instance.feverState = 0;
                    feverETime = 0;
                }
            }
            KeepInScreen();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            ObstacleScroll os = col.gameObject.GetComponent<ObstacleScroll>();
            if (os != null)
            {
                if (os.GetIsHit() == false)
                {
                    if (GameManager.instance.feverState == 0)
                    {
                        if (col.tag == "Snowman")
                        {
                            SoundManager.instance.RandomizeSfx(colliSnow1, colliSnow2, colliSnow3);
                            GameObject p = Instantiate(snowmanParticle, col.transform.position, Quaternion.identity);
                            Destroy(p, 2f);
                            os.HitByPlayer();
                            SetScale(ballScale + snowManScale);
                            Destroy(col.gameObject);
                        } 
                        else if (col.tag == "Wall" || col.tag == "Tree")
                        {
                            SoundManager.instance.RandomizeSfx(colliWall1, colliWall2, colliWall3);
                            GameObject p = Instantiate(SnowParticle, col.transform.position, Quaternion.identity);
                            p.transform.localScale = p.transform.localScale * ballScale / 4;
                            Destroy(p, 2f);
                            os.HitByPlayer();
                            SetScale(ballScale - obstacleScale);
                        } 
                    }
                    if (GameManager.instance.feverState == 2)
                    {
                        SoundManager.instance.RandomizeSfx(colliFever);
                        os.HitAtFever();
                        GameObject p = Instantiate(crashParticle, col.transform.position, Quaternion.identity);
                        p.transform.localScale = p.transform.localScale *2;
                        Destroy(p, 2f);
                    }
                }
            }
        }
    }

    void SetScale(float scale)
    {
        if (scale <= minScale)
        {
            scale = minScale;
            isDead = true;
            return;
        }
        ballScale = scale;
        transform.localScale = new Vector2(ballScale, ballScale);
    }

    void MoveAndRotate()
    {
        dir = 0;
        if (InputLeft())
        {
            transform.position += new Vector3(-moveSpeed - ballScale / 5, 0) * Time.deltaTime;
            dir = -1;
            beforeDir = -1;
            if (transform.rotation.z <= 0.2 && transform.rotation.z >= -0.2)
                transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }
        if (InputRight())
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
        if (transform.position.x - width * ballScale / 2 < -ScreenWidth / 2)
            transform.position = new Vector2(width * ballScale / 2 - ScreenWidth / 2, transform.position.y);
        else if (transform.position.x + width * ballScale / 2 > ScreenWidth / 2)
            transform.position = new Vector2(ScreenWidth / 2 - width * ballScale / 2, transform.position.y);
    }


    bool InputLeft()
    {
        if (GameManager.instance.testEnvironment == GameManager.TestEnvironment.MOBILE)
        {
            if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    return true;
            }
            return false;
        }
        else if(GameManager.instance.testEnvironment == GameManager.TestEnvironment.PC)
        {
            if (Input.GetKey(KeyCode.A))
                return true;
            return false;
        }
        return false;
    }
    bool InputRight()
    {
        if (GameManager.instance.testEnvironment == GameManager.TestEnvironment.MOBILE)
        {
            if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    return true;
            }
            return false;
        }
        else if (GameManager.instance.testEnvironment == GameManager.TestEnvironment.PC)
        {
            if (Input.GetKey(KeyCode.D))
                return true;
            return false;
        }

        return false;
    }
}
