using System;
using UnityEngine;
using UnityEngine.UI;

public class ForTest : MonoBehaviour
{
    [SerializeField] public Text _header;
    [SerializeField] public Text _task1;
    [SerializeField] public Text _task2;
    [SerializeField] public Text _task3;

    public bool IsFireReady = false;
    public bool IsHasEaten = false;
    public bool IsHasDrank = false;
    
    //Скопированный метод с интернета.
    public string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }
    
    private void Update()
    {
        if (IsFireReady)
        {
            _task1.text = StrikeThrough(_task1.text);
            IsFireReady = !IsFireReady;
        }
           
        if (IsHasEaten)
        {
            _task2.text = StrikeThrough(_task2.text);
            IsHasEaten = !IsHasEaten;
        }
        
        if (IsHasDrank)
        {
            _task3.text = StrikeThrough(_task3.text);
            IsHasDrank = !IsHasDrank;
        }
        
    }


   

    
    
}
