using UnityEngine;
using System.Collections;
using System;

public class NightFury : Character
{
    void Update()
    {
        Move();
    }
    protected override void Move()
    {
        var horz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        transform.position += (transform.right * horz + transform.up * vert) * 10 * Time.deltaTime;

    }
}
