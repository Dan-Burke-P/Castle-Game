using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTest : MonoBehaviour
{
    public Card cd;
    public IBaseCard crdOBJ;
    public Hand hn;
    // Start is called before the first frame update
    void Start()
    {
        crdOBJ = (cd.giveCard(this.gameObject)).GetComponent(typeof(IBaseCard)) as IBaseCard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnPrs()
    {
        crdOBJ.play();
        hn.addCardToHand(cd);
    }
}
