using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightfollow : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset;
    private void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
