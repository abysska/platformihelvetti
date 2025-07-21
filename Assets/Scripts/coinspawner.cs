using System.Linq.Expressions;
using UnityEngine;

public class coinspawner : MonoBehaviour
{

    public GameObject coin;
    public float spawnRate = 1;
    public float timer = 0f;
    public bool hasCoin; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    // Update is called once per frame
    void Update()
    {

        timer +=Time.deltaTime;

       if (timer > spawnRate)
        {
            spawnCoin();
            Destroy(gameObject);
        }
     

    
    }

    void spawnCoin()
    {
        Instantiate(coin, transform.position, Quaternion.identity);

    }
}