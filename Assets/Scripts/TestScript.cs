using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GererateObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator GererateObject()
    {
        for (int i = 3; i < 3; i++)
        {
            Debug.Log("Objet got generated here :" + i);
            yield return new WaitForSeconds(3f);
        }
    }
}
