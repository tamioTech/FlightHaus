using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propell : MonoBehaviour
{
    public float rotateAmount;
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.EulerRotation(0, -90, 90);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePropeller();

    }

    private void RotatePropeller()
    {
        rotateAmount += 1;
        transform.localRotation = Quaternion.EulerRotation(rotateAmount, -90, 90);
        if (rotateAmount > 360) { rotateAmount = 0; }
    }
}
