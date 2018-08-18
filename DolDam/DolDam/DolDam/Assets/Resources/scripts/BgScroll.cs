using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour {

    private GameManager gm;
    private float pixToUnit;
    private float screenHeight;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject wall1;
    public GameObject wall2;


    // Use this for initialization
    void Start () {
        gm=GameManager.instance;
        pixToUnit = bg1.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenHeight = 19.2f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gm.gameState == GameManager.GameState.PLAYING)
        {
            bg1.transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed()));
            bg2.transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed()));
            wall1.transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed()));
            wall2.transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed()));
            if (bg1.transform.position.y < -screenHeight)
                bg1.transform.Translate(new Vector2(0, screenHeight * 2));
            if (bg2.transform.position.y < -screenHeight)
                bg2.transform.Translate(new Vector2(0, screenHeight * 2));
            if (wall1.transform.position.y < -screenHeight)
                wall1.transform.Translate(new Vector2(0, screenHeight * 2));
            if (wall2.transform.position.y < -screenHeight)
                wall2.transform.Translate(new Vector2(0, screenHeight * 2));
        }
    }
}
