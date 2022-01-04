using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragdrop : MonoBehaviour
{
    public GameObject detector;
    public Vector3 scaleAwal, randomPos;
    public bool onPos = false, onTempel = false;
    public Soundsfx soundsfx;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-0.35f, 0.35f), -4.28f);

        randomPos = transform.position;

        scaleAwal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        if (!onTempel)
        {
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            transform.position = new Vector3(posMouse.x, posMouse.y, -1);
            transform.localScale = new Vector2(1.2f, 1.2f);
        }
    }

    public void OnMouseUp()
    {
        if (onPos)
        {
            transform.position = detector.transform.position;
            onTempel = true;
            transform.localScale = scaleAwal;
            soundsfx.PlayJigsaw();
        }
        else
        {
            //transform.position = randomPos;
            onTempel = false;
            transform.localScale = scaleAwal;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == detector)
        {
            onPos = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == detector)
        {
            onPos = false;
        }
    }
}
