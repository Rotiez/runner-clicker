using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObj : MonoBehaviour
{
   private bool move;

   private Vector2 randomVector;
   private void Update()
   {
      if (!move) return;
      transform.Translate(randomVector * Time.deltaTime * 100);
   }
   
   public void StartMotion(int ScoreIncrease)
   {
      transform.localPosition = Vector2.zero;
      GetComponent<Text>().text = "+" + ScoreIncrease;
      randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
      move = true;
   }
}
