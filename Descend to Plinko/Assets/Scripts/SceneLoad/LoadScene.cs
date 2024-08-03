using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    internal class LoadScene : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        public async void PanelActive()
        {
            await LoadSceneDelayAsync();
            _panel.SetActive(true);
            print(this.name);
        }

        private async Task LoadSceneDelayAsync()
        {
            await Task.Delay(3000);
            SceneManager.LoadScene(1);
        }
    }
}
