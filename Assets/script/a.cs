using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;





public class a : MonoBehaviour
{
    [Header("�́H")]
    [SerializeField] private int score;

    [Range(0f, 10f)]        //�X���C�_�[��\��
    [SerializeField] private float Xbyou = 1f;










    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LogAfterDelay(Xbyou));

        InvokeRepeating(nameof(Delayyyy),1, Xbyou);
    }

    void Delayyyy()
    {
        Debug.Log($"{Xbyou}�b���Invoke��Debug.Log�����s�D�D�D�I");
    }
    

    IEnumerator LogAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log($"{Xbyou}�b���Debug.log���o��");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
