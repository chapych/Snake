using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Apple : MonoBehaviour, ICollectable
{

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        // Update is called once per frame
        void Update()
        {

        }
    }
}
