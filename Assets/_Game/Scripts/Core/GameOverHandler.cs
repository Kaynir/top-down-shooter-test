using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kaynir.TDSTest.Core
{
    public class GameOverHandler : MonoBehaviour
    {
        // проста€ реализаци€ завершени€ игры в рамках тестового задани€
        // устанавливаетс€ и внедр€етс€ в ProjectContext

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