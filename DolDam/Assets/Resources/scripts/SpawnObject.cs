﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public float wallSpawnDis = 50f;
    private float wallEDis = 0f;
    public GameObject wall;
    public float snowmanSpawnDis = 30f;
    private float snowmanEDis = 15f;
    public GameObject snowman;

    private float screenWidth;
    private float screenHeight;
    private float pixToUnit;

	// Use this for initialization
	void Start () {
        pixToUnit = wall.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenHeight = Screen.height / pixToUnit;
        screenWidth = Screen.width / pixToUnit;
        snowmanSpawnDis = 30f;
        wallSpawnDis = 30f;
}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            wallEDis += Time.deltaTime*GameManager.instance.GetScrollSpeed();
            Debug.Log(wallEDis);
            if (wallSpawnDis <= wallEDis)
            {
                wallEDis -= wallSpawnDis;
                SpawnObstacle(wall);
            }
            snowmanEDis += Time.deltaTime * GameManager.instance.GetScrollSpeed();
            if (snowmanSpawnDis <= snowmanEDis)
            {
                snowmanEDis -= snowmanSpawnDis;
                SpawnObstacle(snowman);
            }
        }
	}
    void SpawnObstacle(GameObject ob)
    {
        SpriteRenderer sr = ob.GetComponent<SpriteRenderer>();
        float pixToUnit = sr.sprite.pixelsPerUnit;
        float width = sr.sprite.rect.width / pixToUnit;
        float height = sr.sprite.rect.height / pixToUnit;
        GameObject spOb= Instantiate(ob,
            new Vector2(Random.Range(-screenWidth / 2 + width/2, screenWidth / 2 - width / 2), screenHeight/2+height / 2), 
            Quaternion.identity);
    }
}
