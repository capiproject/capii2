using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Arrays : MonoBehaviour
{

    public bool[] array1;
    public bool[] array2;
    int indice;
    int i;
  
    // Start is called before the first frame update
    void Start()
    {
        indice = 0;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
    // Update is called once per frame
    public void ClicouBotao(int valorBotao)
    {
        if (indice == valorBotao - 1)
        {
            Debug.Log("ValorCerto");
            if (!array1[indice])
            {
                array1[indice] = true;
                indice++;
                Debug.Log("Proximo");
            }
        }
    } 
}

