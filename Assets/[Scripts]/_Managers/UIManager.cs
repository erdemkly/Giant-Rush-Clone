using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoSingleton<UIManager>
{
    // Start is called before the first frame update
    public TextMeshProUGUI txtAnim;
    public TextMeshProUGUI txtStarCount;
    public GameObject animStar;
    public Transform starTransformUI;
    public MySlider mySlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddStar(int count,Vector3 pos)
    {
        var screenPos = Camera.main.WorldToScreenPoint(pos);
        var targetPos = starTransformUI.position;
        var myStar = Instantiate(animStar.gameObject,screenPos,Quaternion.identity,InputManager.Instance.transform);
        myStar.transform.DOMove(targetPos, .2f).SetEase(Ease.InBounce).OnComplete(() => 
        {
            GameManager.Instance.starCount += count;
            txtStarCount.text = $"{GameManager.Instance.starCount}";
            Destroy(myStar.gameObject);
        });
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

    public void SetSlider(int value)
    {
        mySlider.AddValue(value);
    }
}
