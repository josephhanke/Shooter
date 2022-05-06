using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float width = 10;
    public float height = 5;
    public float speed = 0.1f;
    private float xmax;
    private float xmin;

    public bool movingRight = true;

      public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Start()
    {

        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        xmax = rightBoundary.x;
        xmin = leftBoundary.x;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }


    void Update()
    {

        if (movingRight)
        {
            transform.position += new Vector3(speed, 0);
        }

        else

        {
            transform.position += new Vector3(-speed, 0);
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if (rightEdgeOfFormation > xmax)
        {
            movingRight = false;
        }

        if (leftEdgeOfFormation < xmin)
        {
            movingRight = true;
        }
        
    }
}
