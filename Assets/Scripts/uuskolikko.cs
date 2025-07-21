using UnityEngine;

public class uuskolikko : MonoBehaviour
{

    public GameObject Coinspawner;
    public float spawnRate;
    private float timer;
    private bool coinCollected;
    public void coinGet()
    {
    coinCollected = true;
    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCollected) {
            timer =+ Time.deltaTime;
        }
        if (timer >= spawnRate)
        {
            Instantiate(Coinspawner, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
