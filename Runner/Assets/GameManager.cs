using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject objects;

    void Start()
    {
        InvokeRepeating("CreateObjects", 1,1);
    }

    void CreateObjects()
    {
        Instantiate(objects, new Vector3(12.35f, 2.8f, 0), Quaternion.identity);
    }
}
