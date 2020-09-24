using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewdragBasket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
          Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          //print(touchPosition);
          touchPosition.z = 0f;
          gameObject.transform.position = touchPosition;
    }
}
