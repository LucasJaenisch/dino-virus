using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject target;
    public Transform camTransform;

    private Camera cam;

    public float distance = 10.0f;
    public float currentX = 0.0f;
    public float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    private Vector3 offset;

    public const float y_angle_min = -50.0f;
    public const float y_angle_max = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
        //offset = transform.position - target.transform.position;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, y_angle_min, y_angle_max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = target.transform.position + rotation * dir;
        camTransform.LookAt(target.transform.position);

        //transform.position = target.transform.position + offset;
    }
}
