using UnityEngine;
//using System.Collections;

public class MatrixController : MonoBehaviour
{
    [SerializeField] private Transform A;
    [SerializeField] private Transform B;
    [SerializeField] private float AddDegree = 90;
    float angle;
    float dir;
	void Update () 
    {
        if (B.position.x < A.position.x)
        {
            dir = -1;
            AddDegree = 180;
        } else
        {
            dir = 1;
            AddDegree = 0;
        }
        angle = Vector3.Angle (Vector3.up*dir, B.position);
        A.rotation = ExtractRotation (GetMatrix(angle-AddDegree));
        print (angle);
	}

    [ContextMenu ("GetAMatrix")]
    public void GetAMatrix ()
    {
        Matrix4x4 m = GetTransformationMatrix (A);
    }

    [ContextMenu ("GetBMatrix")]
    public void GetBMatrix ()
    {
        Matrix4x4 m = GetTransformationMatrix (B);
    }

    public Matrix4x4 GetTransformationMatrix (Transform t) 
    {
        Matrix4x4 m =  t.localToWorldMatrix;
        for (int i = 0; i < 4; i++)
        {
            string rowS = "";
            Vector4 row = m.GetRow (i);
            for (int j = 0; j < 4; j++)
            {
                rowS += row [j] + "  ";    
            }

            Debug.LogError (rowS);
        }
        return m;
    }

    private Matrix4x4 GetMatrix (float teta) 
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

    public Quaternion ExtractRotation (Matrix4x4 matrix) 
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
}
