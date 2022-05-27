using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float MovemntSpeed;
    private float hor;

    public float xSpeed;
    public float _currentRunningSpeed;
    public float limitX;

    public void Start()
    {
       Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, true);
    }

    void Update()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _currentRunningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
    public void ChangeSpeed(float value)
    {
        _currentRunningSpeed = value;
    }
}
