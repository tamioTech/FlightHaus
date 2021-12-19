using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitfire_Movement : MonoBehaviour
{
    [Header("kdkf")]
    [Tooltip("Move shift left and right")]
    [SerializeField] float xMovSp = 10f;
    [SerializeField] float yMovSp = 10f;
    [SerializeField] float zMovSp = 10f;
    [Tooltip("Min and max movement (x,y)")]
    [SerializeField] float xMin = -10f;
    [SerializeField] float xMax = 10f;
    [SerializeField] float yMin = -7f;
    [SerializeField] float yMax = 10f;
    [SerializeField] float zMin = -45f;
    [SerializeField] float zMax = 45f;
    [SerializeField] float rollMultiplier = 1f;
    [SerializeField] float pitchMultiplier = 1f;
    [SerializeField] float yawMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
    }

    private void ProcessTranslation()
    {
        
        float xThrow = Input.GetAxis("Yaw");
        float yThrow = Input.GetAxis("Pitch");
        float zThrow = Input.GetAxis("Roll");
        float xOffset = xThrow * Time.deltaTime * xMovSp;
        float yOffset = yThrow * Time.deltaTime * yMovSp;
        float zOffset = zThrow * Time.deltaTime * zMovSp;
        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;
        float zRawPos = transform.localPosition.z + zOffset;
        float xClamp = Mathf.Clamp(xRawPos, xMin, xMax);
        float yClamp = Mathf.Clamp(yRawPos, yMin, yMax);
        float zClamp = Mathf.Clamp(zOffset, zMin, zMax);

        transform.localPosition = new Vector3(xClamp, yClamp, transform.localPosition.z);

        float xRoll = yThrow * -pitchMultiplier;
       // float xRollClamp = Mathf.Clamp(xRoll, zMin, zMax);
        float yRoll = xThrow * yawMultiplier;
        //float yRollClamp = Mathf.Clamp(yRoll, y)
        float zRoll = xThrow * -rollMultiplier;
       //float zRollClamp = Mathf.Clamp(zRoll, zMin, zMax);

        transform.localRotation = Quaternion.Euler(xRoll, yRoll, zRoll);
    }

    //private void ProcessRotation()
    //{
    //    

    //    float zRoll = zThrow * rollMultiplier;
    //    
    //    transform.localRotation = Quaternion.Euler(0, 0, zRoll);
    //}
}


