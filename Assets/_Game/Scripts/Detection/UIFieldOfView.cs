using UnityEngine;
using UnityEngine.UI;

namespace Kaynir.TDSTest.Detection
{
    public class UIFieldOfView : MonoBehaviour
    {
        // not the most flexible way to visualize FOV
        // chosen just for test
        
        // in real project it's better to create mesh through code
        // it allows to add custom materials and shaders for better visuals
        // it also allows to show FOV collisions when looking on obstacles

        private const float MAX_ANGLE = 360f;

        [SerializeField] private FieldOfView fieldOfView = null;
        [SerializeField] private Image filledImage = null;
        [SerializeField] private float scaleModifier = 2f;

        private void Start()
        {
            DrawFovDisplay();
        }

        private void DrawFovDisplay()
        {
            float angleOffset = fieldOfView.ViewAngle * .5f;
            
            transform.localEulerAngles = Vector3.forward * angleOffset;
            transform.localScale = fieldOfView.ViewRadius * scaleModifier * Vector3.one;

            filledImage.fillMethod = Image.FillMethod.Radial360;
            filledImage.fillOrigin = (int)Image.Origin360.Top;
            filledImage.fillClockwise = true;
            filledImage.fillAmount = fieldOfView.ViewAngle / MAX_ANGLE;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!fieldOfView || !filledImage) return;

            DrawFovDisplay();
        }
#endif
    }
}