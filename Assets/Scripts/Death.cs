using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    public ValueHolder data;

    public GameObject redPen;
    public GameObject bluePen;

    void OnTriggerEnter(Collider pen)
    {
        if (pen.CompareTag("Red Pen") || pen.CompareTag("Blue Pen"))
        {
            if (pen.CompareTag("Red Pen"))
                data.IncrementBlue();
            else
                data.IncrementRed();

            Rigidbody redPenRB = redPen.GetComponent<Rigidbody>();
            Rigidbody bluePenRB = bluePen.GetComponent<Rigidbody>();

            redPenRB.isKinematic = true;
            redPenRB.isKinematic = false;
            bluePenRB.isKinematic = true;
            bluePenRB.isKinematic = false;

            redPen.transform.position = new Vector3(-0.6f, 0.01f, -0.011f);
            redPen.transform.rotation = Quaternion.Euler(0, 90, 0);

            bluePen.transform.position = new Vector3(0.6f, 0.01f, 0.011f);
            bluePen.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
