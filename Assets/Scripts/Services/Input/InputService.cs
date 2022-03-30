

using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool IsAttackedButtonUp();
    }

    public class InputService : IInputService
    {
        private readonly string _vertical = "Vertical";
        private readonly string _horizontal = "Horizontal";
        
        public Vector2 Axis => new Vector2(UnityEngine.Input.GetAxis(_horizontal), UnityEngine.Input.GetAxis(_vertical));

        public bool IsAttackedButtonUp() => UnityEngine.Input.GetMouseButtonUp(0);
    }
}