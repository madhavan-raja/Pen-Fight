using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    public ValueHolder data;

    public Camera mainCam;
    public GameObject arrowPrefab;

    public Button fireButton;
    public Slider powerSlider;

    public Rigidbody redPen;
    public Rigidbody bluePen;

    public float firePower = 50;

    GameObject arrow;
    Vector3 normal;

    void Start()
    {
        fireButton.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetButton("Mark"))
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitInfo, 10))
            {
                string tagToMatch;

                if (data.GetCurrentTurn() == false)
                    tagToMatch = "Red Pen";
                else
                    tagToMatch = "Blue Pen";

                if (hitInfo.transform.gameObject.CompareTag(tagToMatch))
                {
                    if (arrow)
                        Destroy(arrow);
                    else
                        fireButton.enabled = true;

                    arrow = Instantiate(arrowPrefab, hitInfo.point, Quaternion.LookRotation(-hitInfo.normal));
                    normal = -hitInfo.normal;
                }
            }
        }
    }

    public void Fire()
    {
        Rigidbody currentPen;

        if (data.GetCurrentTurn() == false)
            currentPen = redPen;
        else
            currentPen = bluePen;

        currentPen.AddForceAtPosition(normal * firePower * powerSlider.value, arrow.transform.position);
        fireButton.enabled = false;
        Destroy(arrow);

        data.SwitchTurn();
    }
}
