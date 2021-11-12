using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class Settings : MonoBehaviour,IButton
    {
        public void OnClick()
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
}