
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 13;
    private float maxSpeed = 15;
    private float maxTorque = 2;
    private float xRange = 4;
    private float ySpawnPos = -2;


    //pounts tpo get after destroying our object. we can fix this to different value according to different objects we have.
    public int pointValue;


    //for particle effect on touching
    public ParticleSystem explosionParticel;

    //variable to store our script 
    private GameManager gameManager;

    // This script is applied to a GameObject to reference its Rigidbody component.

    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {

        //finding Game Manager gameobject and then get its script component and store it in gameManager variable
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // Get a reference to the GameObject's Rigidbody component.
        targetRb = GetComponent<Rigidbody>();

        // Now we can apply forces or perform other operations using the Rigidbody.

        // Apply an upward force with a random strength in the range of 12 to 20, using impulse mode.
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Apply a random torque (rotation force) in all three axes.
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);

        // Set a random starting position within the given range (-4 to 4 on X-axis, fixed at Y = -6).
        transform.position = RandomSpawnPos();
    }
    void Update()
    {

    }


    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticel, transform.position, explosionParticel.transform.rotation);
            gameManager.updateScore(pointValue);
        }
        
    }

    //so that we have to write less we made all this functions here

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.gameOver();
        }
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }


    
    

    
}
