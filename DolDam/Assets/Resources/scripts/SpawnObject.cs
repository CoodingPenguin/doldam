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
    private bool isSnowTurnFirst;
    private bool isSnowTurnSecond;

    private float screenWidth;
    private float screenHeight;
    private float pixToUnit;

	// Use this for initialization
	void Start () {
        pixToUnit = wall.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        screenHeight = 19.2f;
        screenWidth = 10.8f - GameObject.FindGameObjectWithTag("SideWall").GetComponent<SpriteRenderer>().sprite.rect.width / 100;
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
                float g = Random.Range(0.8f, 1.2f);
                if (GameManager.instance.score > 100000) g = Random.Range(0.5f, 1.2f);
                else if (GameManager.instance.score > 300000) g = Random.Range(0.5f, 0.8f);
                else if (GameManager.instance.score > 500000) g = Random.Range(0.6f, 1.0f);

                objectEdis -= objectspawn * g;

                isSnowTurnFirst = isSnowTurnSecond;
                isSnowTurnSecond = isSnowTurn;
                
                if(GameManager.instance.score > 300000)
                {
                    if (isSnowTurnFirst == true && isSnowTurnSecond == false) isSnowTurn = false;
                    else if (isSnowTurnFirst == false && isSnowTurnSecond == true) isSnowTurn = false;
                    else if (isSnowTurnFirst == false && isSnowTurnSecond == false) isSnowTurn = true;
                } else
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
