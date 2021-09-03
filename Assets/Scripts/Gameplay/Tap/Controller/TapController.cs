using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapController : MonoBehaviour
{
    private List<TapText> _tapTextPool = new List<TapText>();
    public TapText TapTextPrefab;
    public Transform CoinIcon;

    private TapText GetOrCreateTapText()
    {
        TapText tapText = _tapTextPool.Find(t => !t.gameObject.activeSelf);
        if (tapText == null)
        {
            tapText = Instantiate(TapTextPrefab).GetComponent<TapText>();
            _tapTextPool.Add(tapText);
            tapText.InitController(CoinIcon);
        }

        return tapText;
    }

    public void ShowTapText(Vector3 tapPosition, Transform parent, double output)
    {
        TapText tapText = GetOrCreateTapText();
        tapText.SetTapTextPosition(tapPosition, parent, output);
    }

    public void AnimateCoinIcon()
    {
        CoinIcon.transform.localScale = Vector3.LerpUnclamped
        (CoinIcon.transform.localScale, Vector3.one * 2f, 0.15f);

        CoinIcon.transform.Rotate(0f, 0f, Time.deltaTime * -100f);
    }
}