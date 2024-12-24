using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularOscillator : MonoBehaviour
{
    [SerializeField] GameObject targetPoint;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] string rotatingPath;
    
    void Update()
    {
        transform.RotateAround(targetPoint.transform.position, RotatingPosition(rotatingPath), rotationSpeed * Time.deltaTime);
    }

    Vector3 RotatingPosition(string rotation){

        if(rotation == "up")
            return Vector3.up;
        else if(rotation == "down")
            return Vector3.down;
        else if(rotation == "forward")
            return Vector3.forward;
        else if(rotation == "back")
            return Vector3.back;
        else if(rotation == "left")
            return Vector3.left;
        
        return Vector3.right;
    }
}
