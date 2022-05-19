using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float MovemntSpeed;
    float hor;



    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor * Time.deltaTime, 0, MovemntSpeed * Time.deltaTime));
    }
}
