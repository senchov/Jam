using UnityEngine;
using System.Collections;

public class AIMComponent : MonoBehaviour 
{
    [SerializeField] private Transform AIM;
    [SerializeField] private Transform Target;

    private void Start () 
    {
        GetAngles ();
        Rotate ();
    }

    private void Update () 
    {
        if (AIM.rotation != ExtractRotation (GetMatrix ()))
            Rotate ();
    }

    private void Rotate () 
    {
        Matrix4x4 matrix = GetMatrix ();
        AIM.rotation = ExtractRotation (matrix);
        //AIM.rotation = Quaternion.LookRotation (Target.position - AIM.position);
       
    }

    private Matrix4x4 GetMatrix () 
    {
        int teta = (int)Vector3.Angle ( AIM.localPosition .normalized,AIM.TransformVector (Target.localPosition).normalized);

        float rad = Mathf.Deg2Rad * (90-teta);

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

    [ContextMenu ("GetAngles")]
    public void GetAngles ()
    {
        int teta = (int)Vector3.Angle ( AIM.localPosition .normalized,AIM.TransformVector (Target.localPosition).normalized);
        print (teta);
        float rad = Mathf.Deg2Rad * (90-teta);
        print ("rad-->" +  rad);


        Matrix4x4 m = AIM.localToWorldMatrix;
        for (int i = 0; i < 4; i++)
        {
            string rowS = "";
            Vector4 row = m.GetRow (i);
            for (int j = 0; j < 4; j++) {
                rowS += row [j] + " ";
            }
            print (rowS);
        }
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
