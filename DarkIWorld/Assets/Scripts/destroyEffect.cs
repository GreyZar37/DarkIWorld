using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEffect : MonoBehaviour
{
    public float timer = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, timer);
    }

   
}
