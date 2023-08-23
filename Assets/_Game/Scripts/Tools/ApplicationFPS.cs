using UnityEngine;

namespace Kaynir.TDSTest.Tools
{
    public class ApplicationFPS : MonoBehaviour
    {
        // инструмент для тестирования физики при разном FPS

        [SerializeField, Range(10, 240)] private int targetFPS = 60;

        private void Awake()
        {
            Application.targetFrameRate = targetFPS;
        }
    }
}