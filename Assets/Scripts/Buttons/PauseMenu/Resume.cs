using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class Resume : MonoBehaviour, IButton
    {
        
        public void OnClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}