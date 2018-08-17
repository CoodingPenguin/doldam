using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScroll : MonoBehaviour {

    private GameManager gm;
    private SpriteRenderer sr;
    private float pixToUnit;
    private float width;
    private float height;
    private bool isHit;
    private bool isFlying;
    public Vector2 goToVec;
    public float flySpeed=50f;
	// Use this for initialization
	void Awake ()
    {
        sr = GetComponent<SpriteRenderer>();
        gm = GameManager.instance;
        pixToUnit = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        width = sr.sprite.rect.width / pixToUnit;
        height = sr.sprite.rect.height / pixToUnit;
        isHit = false;
        isFlying = false;
        flySpeed = 50f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.gameState == GameManager.GameState.PLAYING)
        {
            if (isFlying)
            {
                transform.Translate(goToVec * flySpeed*Time.deltaTime);
                if (transform.position.x + width / 2 < -10.8f / 2  ||
                    transform.position.x - width / 2 > 10.8f / 2 ||
                    transform.position.y - height / 2 > 19.2f / 2 )
                    Destroy(gameObject);
            }
            else
            {
                transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed()));
                if (transform.position.y + height / 2 < -19.2f / 2 )
                    Destroy(gameObject);
            }
        }
    }

    public void HitByPlayer()
    {
        isHit = true;
    }
    public bool GetIsHit()
    {
        return isHit;
    }
    public void HitAtFever()
    {
        float c = Random.Range(0, Mathf.PI * 2);
        goToVec = new Vector2(Mathf.Abs(Mathf.Cos(c)) * Mathf.Sign(transform.position.x), Mathf.Abs(Mathf.Sin(c)));
        isHit = true;
        isFlying = true;
    }
}
