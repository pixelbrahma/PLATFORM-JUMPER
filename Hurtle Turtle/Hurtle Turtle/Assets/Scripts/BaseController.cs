using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (transform.position.x < player.position.x - PlayerController.screenWidth)
            Destroy(this.gameObject);
    }
}
