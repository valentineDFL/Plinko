using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    internal class SwitchPanel : MonoBehaviour
    {
        public async void PanelActive(int scene)
        {
            gameObject.SetActive(true);
            await LoadSceneDelayAsync(scene);
        }

        private async Task LoadSceneDelayAsync(int scene)
        {
            await Task.Delay(3000);
            SceneManager.LoadScene(scene);
        }

        public void OpenPanelTurn()
        {
            gameObject.SetActive(!gameObject.active);
        }
    
        public void OpenPanel()
        {
            gameObject.SetActive(true);
        }

        public async void ClosePanel(AudioSource audioSource)
        {
            audioSource.Play();
            await Task.Delay((int)(audioSource.clip.length * 1000));
            gameObject.SetActive(false);
        }

        public void OpenPausePanel()
        {
            Time.timeScale = 0;
            OpenPanel();
        }

        public void ClosePausePanel()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void ExitApplication()
        {
            Application.Quit();
        }
    }
}
