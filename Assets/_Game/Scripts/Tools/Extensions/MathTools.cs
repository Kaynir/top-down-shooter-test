using UnityEngine;

namespace Kaynir.TDSTest.Tools.Math
{
    public static class MathTools
    {
        public static Vector2 VectorFromAngle(float angle)
        {
            angle *= Mathf.Deg2Rad;
            return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        }
    }
}