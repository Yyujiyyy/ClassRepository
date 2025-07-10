using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;





public class a : MonoBehaviour
{
    [Header("は？")]
    [SerializeField] private int score;

    [Range(0f, 10f)]        //スライダーを表示
    [SerializeField] private float Xbyou = 1f;










    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogAfterDelay(Xbyou));

        InvokeRepeating(nameof(Delayyyy),1, Xbyou);
    }

    void Delayyyy()
    {
        Debug.Log($"{Xbyou}秒後にInvokeでDebug.Logを実行ゥゥゥ！");
    }
    

    IEnumerator LogAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log($"{Xbyou}秒後にDebug.logを出す");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
