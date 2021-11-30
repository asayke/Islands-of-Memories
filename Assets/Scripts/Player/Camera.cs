
using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _mouseSens = 2.5f;

    //Камера сначала смотрит на 0 по y.
    private float _cameraPitch = 0.0f;
    
    
    
    
    
    private void FixedUpdate()
    {
        UpdateLooking();
    }

    
    private void UpdateLooking()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        _cameraPitch -= (mouseDelta.y * _mouseSens);

        //Чтобы мы смотри смотреть в оси y тока от -90 до 90 градусов, то есть вверх и вниз.
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90f, 90f);
    
        _cameraTransform.localEulerAngles = Vector3.right * _cameraPitch;
        
        transform.Rotate(Vector3.up * mouseDelta.x * _mouseSens);
    }


}
