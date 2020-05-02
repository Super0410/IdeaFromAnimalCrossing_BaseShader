using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCulling : MonoBehaviour
{
    [Range(0.1f, 179f)] public float fov = 60f;
    public float aspect = 1.777778f;
    public float eularXOffset;

    private Camera _cam;
    private Camera cam
    {
        get
        {
            if (_cam == null)
                _cam = Camera.main;
            return _cam;
        }
    }

    void OnPreCull()
    {
        Matrix4x4 projectionMatrix = MatrixHelper.ProjectionMatrix(fov, aspect, cam.nearClipPlane, cam.farClipPlane);
        Matrix4x4 world2CameraMatrix = MatrixHelper.World2CameraMatrix_PosFull_EularX_ScaleNone(transform.position, transform.eulerAngles.x + eularXOffset); ;
        cam.cullingMatrix = projectionMatrix * world2CameraMatrix;
    }

    void OnDrawGizmos()
    {
        if (cam == null)
            return;

        Quaternion shift = Quaternion.Euler(new Vector3(eularXOffset, 0, 0));
        Vector3 fwd = shift * transform.forward;
        Vector3 up = shift * transform.up;

        Gizmos.color = Color.green;
        GizmosHelper.DrawFrustum(transform.position, fwd, up, fov, aspect, cam.nearClipPlane, cam.farClipPlane);
    }
}
