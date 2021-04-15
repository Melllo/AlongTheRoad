using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class RightPositionChecker : MonoBehaviour
{
    public GameObject panel;
    bool finished = false;
    bool isGo = false;
    Transform[] tilesTransforms;
    int tilesInRightPosition = 0;
    public Transform[] pathPoints;
    public Transform hero;
    public GameObject button;

    float speed = 2;
    int pointIndex = 1;
    void Start()
    {
        if (pathPoints != null)
        {
            hero.transform.position = pathPoints[0].transform.position;
        }
        tilesTransforms = panel.GetComponentsInChildren<Transform>().Skip(1).ToArray();
        Debug.Log(tilesTransforms.Length);
    }

    public void Click()
    {
        CheckFinished();
        if (finished)
        {
            isGo = true;
            Debug.Log("finished");
        }
        else {
            Debug.Log("Wrong");
        }
    }
    void Update() 
    {
        if (isGo)
        {
            hero.transform.position = Vector2.MoveTowards(hero.transform.position, pathPoints[pointIndex].position, speed * Time.deltaTime);

            Vector3 dir = pathPoints[pointIndex].position - hero.transform.position;
            if (Vector2.Distance(hero.transform.position, pathPoints[pointIndex].position) < 0.1f)
            {
                if (pointIndex < pathPoints.Length - 1)
                {
                    pointIndex++;
                }
                else
                {
                    Destroy(this);
                }
            }
        }
    }

    void CheckFinished() 
    {
        if (!finished)
        {
            foreach (Transform tile in tilesTransforms)
            {
                if (tile.transform.rotation.z == 0)
                {
                    tilesInRightPosition += 1;
                }
            }
        }
        if (tilesInRightPosition == tilesTransforms.Length)
        {
            finished = true;
        }
    }
}

