using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    [SerializeField] Text tipTextUI;

    public void SetTip(string tipText)
    {
        tipTextUI.text = tipText;
        
    }
}
