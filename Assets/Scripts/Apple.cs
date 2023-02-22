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

   
}
