using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] public Animator _animator;
        
        private static readonly int MoveHash = Animator.StringToHash("Moving");
        //
        // private void Update()
        // {
        //     _animator.SetFloat(MoveHash, _characterController.velocity.magnitude, 0.1f,Time.deltaTime);
        // }
        
    }
}