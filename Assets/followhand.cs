using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followhand : MonoBehaviour
{

    public Transform rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rightHand.position;
        transform.rotation = rightHand.rotation;
    }
}
