using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public float wallSpawnTime = 2f;
    private float wallETime = 0f;
    public GameObject wall;
    public float snowmanSpawnTime = 2f;
    private float snowmanETime = 1f;
    public GameObject snowman;

    private float screenWidth;
    private float screenHeight;
    private float pixToUnit;

	// Use this for initialization
	void Start () {
        pixToUnit = wall.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenHeight = Screen.height / pixToUnit;
        screenWidth = Screen.width / pixToUnit;
        snowmanSpawnTime = 2f;
        wallSpawnTime = 2f;
}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            wallETime += Time.deltaTime;
            if (wallSpawnTime <= wallETime)
            {
                wallETime -= wallSpawnTime;
                SpawnObstacle(wall);
            }
            snowmanETime += Time.deltaTime;
            if (snowmanSpawnTime <= snowmanETime)
            {
                snowmanETime -= snowmanSpawnTime;
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
