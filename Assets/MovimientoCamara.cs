using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 9, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeRot(float rot)
    {
 
    }
}
