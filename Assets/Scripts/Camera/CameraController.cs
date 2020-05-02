using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.position = GameManager.Inst.playerTrans.position;
    }
}