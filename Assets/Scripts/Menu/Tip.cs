using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    Text tipTextUI;
    string tipTextToDisplay;

    private void Start()
    {
        tipTextUI = GetComponent<Text>();
    }
    public void SetTip(string tipText)
    {
        print(123);
        tipTextToDisplay = tipText;
        StartCoroutine("TipFadeIn");
    }

    public void RemoveTip()
    {
        StopAllCoroutines();
        tipTextUI.text = "";
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    IEnumerator TipFadeIn()
    {
        yield return new WaitForSeconds(2);
        tipTextUI.text = tipTextToDisplay;
    }
}
