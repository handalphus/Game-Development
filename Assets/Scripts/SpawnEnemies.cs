using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject wolf;
    public GameObject bear;
    

    public int enemyNumber;
    public Terrain terrain;

    private int xPos, zPos;
    private float yPos;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropEnemies());
    }

   

    private IEnumerator DropEnemies()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                xPos = Random.Range(240, 910);
                zPos = Random.Range(130, 780);
                if(xPos <540 && xPos>381 && zPos<431 && zPos > 184)
                {

                }
                else
                {
                    isCorrect = true;
                }
            }
            yPos = terrain.SampleHeight(new Vector3(xPos,0 ,zPos));
            int k = Random.Range(0, 2);
            if (k == 0)
            {
                enemy = bear;
            }
            else
            {
                enemy = wolf;
            }
            Instantiate(enemy, new Vector3(xPos, yPos+2, zPos), Quaternion.identity);
        }
        yield return new WaitForEndOfFrame();
    }
}
