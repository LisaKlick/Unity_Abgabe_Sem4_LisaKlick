using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            //win level
            Debug.Log("Won Level");
        }
    }
}
