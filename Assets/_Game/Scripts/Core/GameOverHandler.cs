using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kaynir.TDSTest.Core
{
    public class GameOverHandler : MonoBehaviour
    {
        // simple game over implementation for test
        // installed in ProjectContext

        [SerializeField, Min(0)] private int sceneToReload = 0;
        [SerializeField, Min(0f)] private float reloadDelayInSeconds = 2f;

        public bool IsGameOver { get; private set; }

        public void EndGame()
        {
            if (IsGameOver) return;

            IsGameOver = true;
            StartCoroutine(GameOverRoutine());
        }

        private IEnumerator GameOverRoutine()
        {
            Debug.Log($"Game is over. Reloading in {reloadDelayInSeconds} seconds.");

            for (float t = 0; t < reloadDelayInSeconds; t += Time.deltaTime)
            {
                yield return null;
            }

            yield return SceneManager.LoadSceneAsync(sceneToReload);
            
            IsGameOver = false;
        }
    }
}