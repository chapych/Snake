using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Apple : MonoBehaviour, ICollectable
{
    Collider2D collider;

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
