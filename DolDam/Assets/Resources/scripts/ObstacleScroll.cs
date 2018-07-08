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
	// Use this for initialization
	void Awake ()
    {
        sr = GetComponent<SpriteRenderer>();
        gm = GameManager.instance;
        pixToUnit = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        width = sr.sprite.rect.width / pixToUnit;
        height = sr.sprite.rect.height / pixToUnit;
        isHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.gameState == GameManager.GameState.PLAYING)
        {
            transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed()));
            if (transform.position.y + height / 2 < -Screen.height / 2 / pixToUnit)
                Destroy(gameObject);
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
}
