using UnityEngine;
using UnityEngine.UI;

namespace Kaynir.TDSTest.Detection
{
    public class UIFieldOfView : MonoBehaviour
    {
        // �������, �� ������������ ������ ������ ����������� ���� ������
        // ������ � ������ ��������� �������
        
        // � �������� ������� ����� ������������ Mesh ����� ���
        // ��� ��������� ��������� ��������� � ������� ��� �������� ��������
        // ������� ��������� ����� ��� ������������� � ������������

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