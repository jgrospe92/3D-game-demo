using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().transform.position.y < 0.30f)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;

        // Other way to do is Destroy() the player gameobject

        // after the player die, calls the ReloadLevel() function
        Invoke(nameof(ReloadLevel), 1.3f);
      
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
