using System.Collections;
using UnityEngine;

public class blinking : MonoBehaviour
{
    void Start()
    {
        Invoke("blink",1f);
    }

    void blink()
    {
        StartCoroutine(changeSize());
        float rnd = Random.Range(2, 10);
        Invoke("blink",rnd);
        
    }
    IEnumerator changeSize()
    {
        this.transform.localScale -= new Vector3(0f,0.9f,0f);
        yield return new WaitForSeconds(0.2f);
        this.transform.localScale += new Vector3(0f,0.9f,0f);
        
    }
}
