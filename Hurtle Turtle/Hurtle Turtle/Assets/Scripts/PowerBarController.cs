using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarController : MonoBehaviour {
    private void Update()
    {
        Transform player = GameObject.Find("Player").transform;
        transform.position = new Vector3(player.position.x - 4f, 0f, 0f);
    }
}
