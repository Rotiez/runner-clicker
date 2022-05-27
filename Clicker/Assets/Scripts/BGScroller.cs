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
        transform.position += new Vector3(-100 * Time.deltaTime, 0);

        if(transform.position.x<-5891)
        {
            transform.position = new Vector3(15429f, transform.position.y);
        }
    }
}
