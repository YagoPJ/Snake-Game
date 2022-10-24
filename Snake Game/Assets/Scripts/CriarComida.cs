using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarComida : MonoBehaviour
{
    public Transform bordaCima, bordaBaixo, bordaDireita, bordaEsquerda; // definir os limites para a criação das comidas
    public GameObject preFabComida;


    void Start()
    {
    }
    void Update()
    {
        
    }

    void Criar()
    {
        //definir os limites que a comida sera criada
        int x = (int)Random.Range(bordaEsquerda.position.x, bordaDireita.position.x);
        int y = (int)Random.Range(bordaCima.position.y, bordaBaixo.position.y);
        Instantiate(preFabComida, new Vector2(x, y), Quaternion.identity);
    }

    public void StartComida()
    {
        InvokeRepeating("Criar", 3f, 4f);
    }
}
