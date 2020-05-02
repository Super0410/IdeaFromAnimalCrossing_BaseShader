using UnityEngine;

sealed public class MatrixHelper
{
    public static Matrix4x4 World2CameraMatrix_PosFull_EularX_ScaleNone(Vector3 pos, float eularX)
    {
        Matrix4x4 m = World2LocalMatrix_PosFull_EularX_ScaleNone(pos, eularX);
        m.SetRow(2, -m.GetRow(2));
        return m;
    }

    public static Matrix4x4 World2LocalMatrix_PosFull_EularX_ScaleNone(Vector3 pos, float eularX)
    {
        Matrix4x4 trans = new Matrix4x4();
        trans.m00 = 1;
        trans.m11 = 1;
        trans.m22 = 1;
        trans.m33 = 1;

        // pos
        // 由于是world2local，这里取逆
        pos = -pos;
        trans.m03 = pos.x;
        trans.m13 = pos.y;
        trans.m23 = pos.z;

        Matrix4x4 rotX = new Matrix4x4();
        rotX.m00 = 1;
        rotX.m33 = 1;
        // eularX
        float radX = Mathf.Deg2Rad * eularX;
        float cosValue = Mathf.Cos(radX);
        float sinValue = Mathf.Sin(radX);
        rotX.m11 = cosValue;
        rotX.m12 = sinValue;
        rotX.m21 = -sinValue;
        rotX.m22 = cosValue;

        return rotX * trans;
    }

    public static Matrix4x4 ProjectionMatrix(float fov, float aspect, float near, float far)
    {
        float cotFov = 1 / Mathf.Tan(Mathf.Deg2Rad * fov * 0.5f);
        Matrix4x4 m = new Matrix4x4();
        m.m00 = cotFov / aspect;
        m.m11 = cotFov;
        m.m22 = -(far + near) / (far - near);
        m.m23 = -2 * near * far / (far - near);
        m.m32 = -1;
        return m;
    }
}
