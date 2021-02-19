using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhipPosition : MonoBehaviour
{

    public Transform Bone0;
    public Transform Bone1;
    public Transform Bone2;
    public Transform Bone3;
    public Transform Bone4;
    public Transform Bone5;
    public Transform Bone6;
    public Transform Bone7;
    public Transform Bone8;
    public Transform Bone9;
    public Transform Bone10;
    public Transform Bone11;

    public Transform Ball0;
    public Transform Ball1;
    public Transform Ball2;
    public Transform Ball3;
    public Transform Ball4;
    public Transform Ball5;
    public Transform Ball6;
    public Transform Ball7;
    public Transform Ball8;
    public Transform Ball9;
    public Transform Ball10;
    public Transform Ball11;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(Bone0.transform.forward);

        // Ball0.position = Bone0.position + (Bone0.transform.up * 0.2f);
        Bone0.position = Ball0.position;
        Bone0.rotation = Ball0.rotation;

        Ball1.position = Ball0.position + (Bone0.transform.up * 0.23f);
        Ball1.rotation = Ball0.rotation;

        Bone1.position = Ball1.position;
        Bone2.position = Ball2.position;
        Bone3.position = Ball3.position;
        Bone4.position = Ball4.position;
        Bone5.position = Ball5.position;
        Bone6.position = Ball6.position;
        Bone7.position = Ball7.position;
        Bone8.position = Ball8.position;
        Bone9.position = Ball9.position;
        Bone10.position = Ball10.position;
        Bone11.position = Ball11.position;
    }

}
