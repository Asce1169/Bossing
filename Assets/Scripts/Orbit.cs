using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float sensitivity = 4.0f;
    public Transform player;

    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
    }

    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * sensitivity, Vector3.right) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
