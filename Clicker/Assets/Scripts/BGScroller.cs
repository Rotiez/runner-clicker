using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-50 * Time.deltaTime, 0);

        if(transform.position.x<-1928)
        {
            transform.position = new Vector3(4990f, transform.position.y);
        }
    }
}
