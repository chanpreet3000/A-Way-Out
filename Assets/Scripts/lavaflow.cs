using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lavaflow : MonoBehaviour
{
    public float speed = 0.16f;
    void Update()
    {
        Vector2 backoffset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = backoffset;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
