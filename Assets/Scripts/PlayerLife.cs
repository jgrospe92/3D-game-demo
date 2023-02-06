using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // condition to see if player is dead;
    bool isDead = false;

    private void FixedUpdate()
    {
        //if (GetComponent<Rigidbody>().transform.position.y < 0.30f)
        //{
        //    Die();
        //}
        if (transform.position.y < -4f && !isDead) Die();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
        
    }

    void Die()
    {
        // player is dead
        isDead = true;

        // Other way to do is Destroy() the player gameobject

        // after the player die, calls the ReloadLevel() function
        Invoke(nameof(ReloadLevel), 1.3f);
      
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
