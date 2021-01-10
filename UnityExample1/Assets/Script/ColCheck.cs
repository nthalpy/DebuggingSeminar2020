using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColCheck : MonoBehaviour
{
    //동시에 여러 Collider에 닿아있을 때도 처리하기 위한 클래스
    public int colNum = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Platform"))
            colNum += 1;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Platform"))
            colNum -= 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsColliding()
    {
        return colNum > 0;
    }
}
