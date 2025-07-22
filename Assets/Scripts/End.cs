using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    

   public void OnTriggerEnter(Collider other)
    {

        AudioManager.Instance.PlaySFX("end music");

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }


    }
}

    
    
    

