using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    // Start is called before the first frame update
    public TextMeshProUGUI txtAnim;
    public TextMeshProUGUI txtStarCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStar(int count,Vector3 pos)
    {
        
    }
    public void AnimText(string txt, Vector3 pos)
    {
        txtAnim.transform.position = Camera.main.WorldToScreenPoint(pos);
        txtAnim.text = txt;
        DOTween.Kill("animText");
        DOVirtual.DelayedCall(0.2f, () =>
        {
            txtAnim.text = "";
        }).SetId("animText");
    }
}
