using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        GetComponent<Head>().OnRotateSprite += HandleRotate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleRotate(Vector3Int newDirection)
    {
        var angle = -Mathf.Atan2(newDirection.x,newDirection.y) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360;

        transform.eulerAngles = new Vector3(0, 0,  angle);
    }
}
