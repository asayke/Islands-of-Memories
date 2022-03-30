using DG.Tweening;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float _heath;

    public void Damage(float value)
    {
        _heath -= value;
        if (_heath < 0)
            Kill();
        else Shake();
    }

    private void Shake()
    {
        transform.DOShakePosition(0.2f,2f);
        transform.DOShakeScale(0.2f,2f);
    }

    private void Kill()
    {
        //TODO выпадение дров.
    }
}