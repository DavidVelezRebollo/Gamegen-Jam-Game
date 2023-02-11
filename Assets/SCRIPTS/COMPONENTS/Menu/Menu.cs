using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GOM.Components.Sounds;
using GOM.Components.Core;

namespace GOM.Components.Menu {
    public class Menu : MonoBehaviour {
        [SerializeField] private GameObject LoadingScreen;
        [SerializeField] private Image LoadingBar;

        #region Methods

        /// <summary>
        /// Function that runs when the start button is clicked.
        /// </summary>
        public void OnStartButton()
        {
            StartCoroutine(loadSceneAsync());
            //PlayButton();
        }

        /// <summary>
        /// Function that runs when the exit button is clicked.
        /// </summary>
        public void OnExitButton()
        {
            Application.Quit();
            //PlayButton();
        }

        /// <summary>
        /// Function that plays the general sound of a button.
        /// </summary>
        public void PlayButton()
        {
            SoundManager.Instance.Play("Button");
        }

        private IEnumerator loadSceneAsync()
        {
            AsyncOperation loadScene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            LoadingScreen.SetActive(true);

            while (!loadScene.isDone)
            {
                float progressValue = Mathf.Clamp01(loadScene.progress / 0.09f);
                LoadingBar.fillAmount = progressValue;

                yield return null;
            }
        }

        #endregion
    }
}
