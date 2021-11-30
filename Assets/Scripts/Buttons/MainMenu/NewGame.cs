using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class NewGame : MonoBehaviour, IButton
    {
        
        public void OnClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}