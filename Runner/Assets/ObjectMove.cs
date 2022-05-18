using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectMove : MonoBehaviour
{
    public float s;

    private void Start()
    {
        s = 0.13f;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - s, transform.position.y, 0);

        if (transform.position.x <= -17.5f)
        {
            //то уничтожение обьекта
            //Destroy(gameObject);-1.30712
        }
    }
}
