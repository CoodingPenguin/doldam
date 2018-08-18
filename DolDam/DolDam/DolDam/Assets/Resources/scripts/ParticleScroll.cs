using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScroll : MonoBehaviour {

    GameManager gm;
	// Use this for initialization
	void Start ()
    {
        gm = GameManager.instance;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gm.gameState == GameManager.GameState.PLAYING)
        {
            transform.Translate(new Vector2(0, -Time.deltaTime * gm.GetScrollSpeed())/2);
        }
    }
}
