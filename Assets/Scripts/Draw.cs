using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject Card;
    public GameObject Hand;
    private List<GameObject> CardsInHand { get; set; }
    public List<GameObject> CardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        CardsInHand = new();
    }

    public void OnClick()
    {
        GameObject drawCard = Instantiate(CardsInDeck[Random.Range(0, CardsInDeck.Count)], new Vector3(0,0,0), Quaternion.identity);
        drawCard.transform.SetParent(Hand.transform, false);
        CardsInHand.Add(drawCard);
    }

}
