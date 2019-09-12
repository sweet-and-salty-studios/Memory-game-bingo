using System.Collections.Generic;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class TargetCardsField : MonoBehaviour
    {
        #region VARIABLES

        public Transform[] TargetCards;

        private List<Card> targetCards = new List<Card>();

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void UpdateField(Card[] randomCardsToGuess)
        {
            Card newCard = null;

            for(int i = 0; i < TargetCards.Length; i++)
            {
                newCard = Instantiate(randomCardsToGuess[i], TargetCards[i]);
                newCard.Initialize(randomCardsToGuess[i].FrontSide, randomCardsToGuess[i].BackSide, true);
                targetCards.Add(newCard);
            }
        }

        public void ContainsCard(Card card)
        {
            foreach(var targetCard in targetCards)
            {
                if(targetCard.name == card.name)
                {                    
                    targetCard.SetFoundedColor();
                }
            }
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
