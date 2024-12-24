using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay = 1f;
    string collisionObjectTag;
    bool isLoading = false;
    AudioSource audioSource;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;
    
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;
    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        collisionObjectTag = other.gameObject.tag;
        if(isLoading)
            return;

        switch(collisionObjectTag){
            case "Friendly":
                // Debug.Log("Nothing happened, nothing happened, go on!");
                break;
            case "Finish":
                // Debug.Log("Congrats!! You did it");
                StartLoadingSequence();
                break;
            default:
                // Debug.Log("Oops! you lost");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence(){
        deathParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        isLoading = true;
        Invoke("Respawn", invokeDelay);
    }

    void StartLoadingSequence(){
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        isLoading = true;
        Invoke("LoadNextLevel", invokeDelay);
    }
    void Respawn(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(++currentSceneIndex);
    }
}
