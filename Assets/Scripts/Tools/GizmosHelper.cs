using UnityEngine;

sealed public class GizmosHelper
{
    public static void DrawFrustum(Vector3 pos, Vector3 fwd, Vector3 up, float fov, float aspect, float near, float far)
    {
        Vector3[] nearCornerArr = GetCorners(pos, fwd, up, fov, aspect, near);
        Vector3[] farCornerArr = GetCorners(pos, fwd, up, fov, aspect, far);

        Gizmos.DrawLine(nearCornerArr[0], farCornerArr[0]);
        Gizmos.DrawLine(nearCornerArr[1], farCornerArr[1]);
        Gizmos.DrawLine(nearCornerArr[2], farCornerArr[2]);
        Gizmos.DrawLine(nearCornerArr[3], farCornerArr[3]);

        Gizmos.DrawLine(nearCornerArr[0], nearCornerArr[1]);
        Gizmos.DrawLine(nearCornerArr[0], nearCornerArr[2]);
        Gizmos.DrawLine(nearCornerArr[1], nearCornerArr[3]);
        Gizmos.DrawLine(nearCornerArr[2], nearCornerArr[3]);

        Gizmos.DrawLine(farCornerArr[0], farCornerArr[1]);
        Gizmos.DrawLine(farCornerArr[0], farCornerArr[2]);
        Gizmos.DrawLine(farCornerArr[1], farCornerArr[3]);
        Gizmos.DrawLine(farCornerArr[2], farCornerArr[3]);
    }

    private static Vector3[] GetCorners(Vector3 pos, Vector3 fwd, Vector3 up, float fov, float aspect, float distance)
    {
        Vector3[] corners = new Vector3[4];

        float halfFOV = fov * 0.5f * Mathf.Deg2Rad;
        float height = distance * Mathf.Tan(halfFOV);
        float width = height * aspect;

        Vector3 right = Vector3.Cross(fwd, up);
        Vector3 rightXwidth = right * width;
        Vector3 upXheight = up * height;
        Vector3 fwdXdst = fwd * distance;

        //左上
        corners[0] = pos - rightXwidth;
        corners[0] += upXheight;
        corners[0] += fwdXdst;

        // 右上
        corners[1] = pos + rightXwidth;
        corners[1] += upXheight;
        corners[1] += fwdXdst;

        // 左下
        corners[2] = pos - rightXwidth;
        corners[2] -= upXheight;
        corners[2] += fwdXdst;

        // 右下
        corners[3] = pos + rightXwidth;
        corners[3] -= upXheight;
        corners[3] += fwdXdst;

        return corners;
    }
}
