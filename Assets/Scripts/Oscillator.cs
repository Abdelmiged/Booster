using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float wavePeriod = 2f;
    const float tau = Mathf.PI * 2;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        UnityEngine.Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(wavePeriod <= Mathf.Epsilon) {return;} // Protect against NaN when wavePeriod reaches zero or less
        float cycles = Time.time / wavePeriod;
        float sinValue = Mathf.Sin(cycles * tau);
        UnityEngine.Debug.Log(sinValue);

        movementFactor = (sinValue + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
