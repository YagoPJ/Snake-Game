using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobra : MonoBehaviour
{
    Vector2 dir = Vector2.right; // direção pra cobra andar
    bool comeu = false; // ela comeu 
    public GameObject caudaPreFab; // cauda
    List<Transform> cauda = new List<Transform>();
    GameObject gameController;
    [SerializeField]
    private GameObject cobra;
    public float speed;
    private float startTime;





    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        //InvokeRepeating("Mover", 0.3f, 0.3f);
        speed = 0.3f;
        startTime = Time.time;
        StartCoroutine("NewMove");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
    }

    void Mover()
    {
        Vector2 v = transform.position; //salvando a coordenada atual

        transform.Translate(dir);
        if(comeu)
        {
            GameObject g = (GameObject)Instantiate(caudaPreFab, v, Quaternion.identity); //criação da cauda
            cauda.Insert(0, g.transform); //comeu, defini o inicio da cauda
            comeu = false;   //ja comi
        }
        else if(cauda.Count > 0)
        {
            cauda[cauda.Count - 1].position = v; //muda a coordenada de tela da cobra
            cauda.Insert(0, cauda[cauda.Count - 1]);
            cauda.RemoveAt(cauda.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //é comida ?
        if(coll.gameObject.CompareTag("Comida"))
        {
            comeu = true;
            Destroy(coll.gameObject);
            gameController.GetComponent<GameController>().IncScore();
        }
        else
        {
            gameController.GetComponent<GameController>().GameOver();
            Destroy(cobra);
            Debug.Log("Morreu");
        }
    }

    private IEnumerator NewMove()
    {
        while (true)
        {
            Mover();
            yield return new WaitForSeconds(speed);
            if (Time.time - startTime > 30)
            {
                if(speed > 0.03f)
                {
                    speed -= 0.01f;
                    startTime = Time.time;
                }
            }
        }
    }
}
