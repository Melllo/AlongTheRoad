using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TilesController : MonoBehaviour
{
    void Start() 
    {
        SetRandomPosition();
    }
    void OnMouseDown()
    {
        if (transform.rotation.z != 0)
        {
            transform.Rotate(0, 0, -90);
        }
    }
    void Rotate(GameObject s)
    {
        s.transform.Rotate(0, 0, -90);
    }

    void SetRandomPosition() 
    {
        transform.Rotate(0,0, 90 * Random.Range(-1, 2));
    }
}
