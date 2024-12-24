using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float thrustValue = 900f;
    [SerializeField] float torque = 90f;
    [SerializeField] AudioClip engineThrust;
    [SerializeField] ParticleSystem sideThrusterParticles;
    [SerializeField] ParticleSystem boosterParticles;
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){

        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        StartRotation();
    }
    
    void StartThrusting()
    {
        RocketThrust();
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(engineThrust);

        if (!boosterParticles.isPlaying)
            boosterParticles.Play();

        if (!sideThrusterParticles.isPlaying)
            sideThrusterParticles.Play();
    }

    void StopThrusting()
    {
        audioSource.Stop();
        boosterParticles.Stop();
        sideThrusterParticles.Stop();
    }

    void StartRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RocketRotation(torque);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RocketRotation(-torque);
        }
    }

    void RocketThrust(){
        rb.AddRelativeForce(Vector3.up * thrustValue * Time.deltaTime);
    }

    void RocketRotation(float rotationDirection){
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
