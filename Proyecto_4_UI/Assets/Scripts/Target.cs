using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float destroyTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        { Destroy(gameObject); }

        else if (gameObject.CompareTag("Bad"))
        {
            
        }
    }
}
