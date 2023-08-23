using UnityEngine;

namespace Kaynir.TDSTest.Tools
{
    public class ApplicationFPS : MonoBehaviour
    {
        // ���������� ��� ������������ ������ ��� ������ FPS

        [SerializeField, Range(10, 240)] private int targetFPS = 60;

        private void Awake()
        {
            Application.targetFrameRate = targetFPS;
        }
    }
}