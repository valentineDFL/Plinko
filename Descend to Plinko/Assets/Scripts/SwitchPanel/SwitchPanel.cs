using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        public void ClosePanel()
        {
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
            ClosePanel();
        }

        public void ExitApplication()
        {
            Application.Quit();
        }
    }
}
