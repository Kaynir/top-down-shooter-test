using UnityEngine;
using UnityEngine.UI;

namespace Kaynir.TDSTest.Detection
{
    public class UIFieldOfView : MonoBehaviour
    {
        // простой, но недостаточно гибкий способ отображения поля зрения
        // выбран в рамках тестового задания
        
        // в реальном проекте лучше отрисовывать Mesh через код
        // это позволяет добавлять материалы и шейдеры для красивых эффектов
        // включая изменение формы при столкновениях с препятствием

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