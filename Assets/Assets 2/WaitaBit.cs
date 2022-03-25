using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitaBit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
     
     StartCoroutine(Text());

        IEnumerator Text()  //  <-  its a standalone method
        {
            Debug.Log("Hello");
            yield return new WaitForSeconds(0.1f);
            this.gameObject.tag = "Cutable";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
