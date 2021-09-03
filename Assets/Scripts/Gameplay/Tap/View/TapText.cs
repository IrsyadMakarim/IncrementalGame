using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapText : MonoBehaviour
{
    public float SpawnTime = 0.5f;
    public Text Text;

    private float _spawnTime;


    private Transform _coinIcon;

    public void InitController(Transform coinIcon)
    {
        _coinIcon = coinIcon;
    }
    private void OnEnable() 
    {
        _spawnTime = SpawnTime;
    }

    // Update is called once per frame
    private void Update()
    {
        _spawnTime -= Time.unscaledDeltaTime;
        if (_spawnTime <= 0f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Text.CrossFadeAlpha(0f, 0.5f,false);
            if (Text.color.a == 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SetTapTextPosition(Vector3 tapPosition, Transform parent, double output)
    {
        transform.SetParent(parent, false);
        transform.position = tapPosition;

        Text.text = $"+{output.ToString("0")}";
        gameObject.SetActive(true);
        _coinIcon.transform.localScale = Vector3.one * 1.75f;
    }
}
