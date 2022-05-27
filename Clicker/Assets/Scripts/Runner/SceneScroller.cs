using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-500 * Time.deltaTime, 0);

        if(transform.position.x<-2615)
        {
            transform.position = new Vector3(2654f, transform.position.y);
        }
    }
}
