using UnityEngine;
using System.Collections;

namespace MatrixOperations
{
    public static class MatrixRotation
    {
        public static Quaternion ExtractRotation (this Matrix4x4 matrix) 
        {
            Vector3 forward;
            forward.x = matrix.m02;
            forward.y = matrix.m12;
            forward.z = matrix.m22;

            Vector3 upWards;
            upWards.x = matrix.m01;
            upWards.y = matrix.m11;
            upWards.z = matrix.m21;

            return Quaternion.LookRotation (forward,upWards);
        }

        public static Matrix4x4 GetRotateMatrixAroundZ (this Matrix4x4 m, float teta) 
        { 
            float rad = Mathf.Deg2Rad * teta;

            Matrix4x4 matrix = new Matrix4x4 ();

            matrix.m00 = Mathf.Cos (rad);
            matrix.m01 = Mathf.Sin (rad);
            matrix.m02 = 0;
            matrix.m03 = 0;

            matrix.m10 = -Mathf.Sin (rad);
            matrix.m11 = Mathf.Cos (rad);
            matrix.m12 = 0;
            matrix.m13 = 0;

            matrix.m20 = 0;
            matrix.m21 = 0;
            matrix.m22 = 1;
            matrix.m23 = 0;

            matrix.m30 = 0;
            matrix.m31 = 0;
            matrix.m32 = 0;
            matrix.m33 = 1;
            return matrix;
        }

        public static Matrix4x4 GetRotateAroundY (this Matrix4x4 m, float teta) 
        { 
            float rad = Mathf.Deg2Rad * teta;

            Matrix4x4 matrix = new Matrix4x4 ();

            matrix.m00 = Mathf.Cos (rad);
            matrix.m01 = 0;
            matrix.m02 = -Mathf.Sin (rad);
            matrix.m03 = 0;

            matrix.m10 = 0;
            matrix.m11 = 1;
            matrix.m12 = 0;
            matrix.m13 = 0;

            matrix.m20 = Mathf.Sin (rad);
            matrix.m21 = 0;
            matrix.m22 = Mathf.Cos (rad);
            matrix.m23 = 0;

            matrix.m30 = 0;
            matrix.m31 = 0;
            matrix.m32 = 0;
            matrix.m33 = 1;
            return matrix;
        }

        public static Matrix4x4 GetRotateAroundX (this Matrix4x4 m, float teta) 
        { 
            float rad = Mathf.Deg2Rad * teta;

            Matrix4x4 matrix = new Matrix4x4 ();

            matrix.m00 = 1;
            matrix.m01 = 0;
            matrix.m02 = 0;
            matrix.m03 = 0;

            matrix.m10 = Mathf.Cos (rad);
            matrix.m11 = Mathf.Sin (rad);
            matrix.m12 = 0;
            matrix.m13 = 0;

            matrix.m20 = 0;
            matrix.m21 = -Mathf.Sin (rad);
            matrix.m22 = Mathf.Cos (rad);
            matrix.m23 = 0;

            matrix.m30 = 0;
            matrix.m31 = 0;
            matrix.m32 = 0;
            matrix.m33 = 1;
            return matrix;
        }
    }
}
