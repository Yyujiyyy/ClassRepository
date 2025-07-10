using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;



public class jugyou : MonoBehaviour
{
    [SerializeField] private int Hensuu;
    public int Hensuu1;
    [SerializeField] float random;
    int total;

    const float Aha = 1;


    int x = 0;
    int VX = 1;

    [System.Serializable]
    private class Parameters
    {
        public int X;
        public int Y;
        public int S;
        public int P;
        public int R;
    }

    [SerializeField]
    private Parameters param;

    // Start is called before the first frame update
    void Start()
    {
        Hensuu = 1; Hensuu1 = 0;

        Debug.Log(20);

        int result = Hensuu1 + Hensuu;

        total = addField();
    }

    public int addField()
    {
        var result = Hensuu1 + Hensuu;

        return result;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            DoAction(0);

        if (Input.GetMouseButton(1))
            DoAction(1);

        if (Input.GetMouseButton(2))
            DoAction(2);

        if (Input.GetMouseButton(3))
            DoAction(3);

        if (Input.GetMouseButton(4))
            DoAction(4);


        if (x > 500)
        {
            me();
        }

        else if (x < 0)
        {
            me();
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int x = Clamp(Hensuu, 0, 100);

            

        }

        string num = "333";
        int number = int.Parse(num);

    }
        

    void me()
    {
        VX += 1;
    }

    int Clamp(int random,int max,int min)
    {
        //random = Random.Range(0, 200);

        if (random > max)
        {
            random = max;
        }

        if (random < min)
        {
            random = min;
        }

        Debug.Log(random);

        return random;
    }

    void DoAction(int tukareta)
    {
        switch (tukareta)
        {
            case 0:

                for (int i = 0; i < param.X; i++)
                    Debug.Log($"{param.X}‰ñ");
                break;

            case 1:

                for (int i = 0; i < param.Y; i++)
                    transform.position += new Vector3(2,2,2);
                break;

            case 2:
                for (int i = 0; i < param.S; i++)
                    transform.localScale += new Vector3(2, 2, 2);
                break;

            case 3:
                for (int i = 0; i < param.P; i++)
                    transform.localPosition += new Vector3(2, 2, 2);
                break;

            case 4:
                for (int i = 0; i < param.R; i++)
                    transform.localRotation *= Quaternion.Euler(2, 2, 2);

                break;
        }
    }
}


