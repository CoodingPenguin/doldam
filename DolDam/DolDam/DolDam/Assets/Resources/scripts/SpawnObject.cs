using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public float objectspawn;
    private float objectEdis;
    public GameObject wall;
    public GameObject tree;
    public GameObject snowman;
    public bool isSnowTurn;

    private float screenWidth;
    private float screenHeight;
    private float pixToUnit;

	// Use this for initialization
	void Start () {
        pixToUnit = wall.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenHeight = 19.2f;
        screenWidth = 10.8f;
        objectEdis = 0f;
        isSnowTurn = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameState == GameManager.GameState.PLAYING)
        {
            objectEdis += Time.deltaTime*GameManager.instance.GetScrollSpeed();
            if (objectspawn <= objectEdis)
            {
                if (isSnowTurn)
                    SpawnObstacle(snowman);
                else
                {
                    float r = Random.Range(0f, 1f);
                    if (r < 0.5)
                        SpawnObstacle(wall);
                    else
                        SpawnObstacle(tree);
                }
                objectEdis -= objectspawn;
                isSnowTurn = !isSnowTurn;
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
