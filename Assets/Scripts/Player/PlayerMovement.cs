using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerMovement : MonoBehaviour
{
    Plane groundPlane;
    Camera cam;

    internal void Init()
    {
        groundPlane = new Plane(Vector3.up, Vector3.zero);
        cam = Camera.main;
    }

    internal void Move(float speed)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(h, 0, v);

        transform.Translate(inputDir.normalized * Time.deltaTime * speed, Space.World);
    }

    internal void LookAt(Vector3 mouseInput)
    {
        float rayDst;
        Ray mouseRay = cam.ScreenPointToRay(mouseInput);
        groundPlane.Raycast(mouseRay, out rayDst);
        Vector3 groundPos = mouseRay.GetPoint(rayDst);

        groundPos.y = transform.position.y;
        transform.LookAt(groundPos);
    }
}
