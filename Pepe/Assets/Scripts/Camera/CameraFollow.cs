using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSmoothTime = 0.33f;

    private Transform player;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocityRef;

    // Start is called before the first frame update
    void Start()
    {
        player = Game.instance.refs.GetPlayer();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocityRef, followSmoothTime);
    }
}
