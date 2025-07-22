using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    

   public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

    
    
    

