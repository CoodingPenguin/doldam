using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public float spawnTime = 1f;
    public GameObject obstacle1;

    private float eTime = 0f;
    private float screenWidth;
    private float screenHeight;
    private float pixToUnit;

	// Use this for initialization
	void Start () {
        pixToUnit = obstacle1.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenHeight = Screen.height / pixToUnit;
        screenWidth = Screen.width / pixToUnit;
    }
	
	// Update is called once per frame
	void Update () {
        eTime += Time.deltaTime;
        if(spawnTime<=eTime)
        {
            eTime -= spawnTime;
            SpawnObstacle(obstacle1);
        }
	}
    void SpawnObstacle(GameObject ob)
    {
        SpriteRenderer sr = ob.GetComponent<SpriteRenderer>();
        float pixToUnit = sr.sprite.pixelsPerUnit;
        float width = sr.sprite.rect.width / pixToUnit;
        float height = sr.sprite.rect.height / pixToUnit;
        Debug.Log(-screenWidth / 2 + width / 2);
        GameObject spOb= Instantiate(ob,
            new Vector2(Random.Range(-screenWidth / 2 + width/2, screenWidth / 2 - width / 2), screenHeight/2+height / 2), 
            Quaternion.identity);
    }
}
