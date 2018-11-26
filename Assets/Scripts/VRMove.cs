using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMove : MonoBehaviour
{

    private Animator anim;                      // Animatorへの参照
    private AnimatorStateInfo currentState;     // 現在のステート状態を保存する参照
    private AnimatorStateInfo previousState;    // ひとつ前のステート状態を保存する参照
    private bool _random = true;                // ランダム判定スタートスイッチ
    private float _threshold = 0.5f;             // ランダム判定の閾値
    private float _interval;
    // Use this for initialization
    void Start()
    {
        _interval += Time.deltaTime;
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;
        StartCoroutine("RandomChange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RandomChange()
    {
        if (_interval > 3)
        {
            int _random = Random.Range(0, 3);
            anim.SetBool("Next" + _random, true);
        }
        _interval = 0;
        yield return new WaitForSeconds(_interval);
    }
}


