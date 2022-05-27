using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float MovemntSpeed;
    private float hor;

    public Rigidbody Rigidbody;
    bool sag;
    bool sol;
    float speed = 14f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Vector3 sag_git = new Vector3(-8.80f, transform.position.y, transform.position.z);
        Vector3 sol_git = new Vector3(-10.80f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.x > 50f)
            {
                sag = true;
                sol = false;
            }
            if (touch.deltaPosition.x < -50f)
            {
                sag = false;
                sol = true;
            }
            if (sag == true)
            {
                transform.position = Vector3.Lerp(transform.position, sag_git, 4f * Time.deltaTime);
            }
            if (sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, sol_git, 4f * Time.deltaTime);
            }
        }
    }
}
    
