using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public GameObject target;
    private Transform t;



    //private void Awake()
    //{
    //    player = FindObjectOfType<PlayerManager>().transform;
    //}
    private void Start()
    {
        t = target.transform;
    }
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(t.position.x, t.position.y, transform.position.z);
        }
    }
}
