using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class TopField : MonoBehaviour
    {
        #region VARIABLES

        public Transform[] CardPlaces;
        public CanvasGroup CanvasGroup;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void CanInteract(bool foo)
        {
            CanvasGroup.blocksRaycasts = foo;
            CanvasGroup.interactable = foo;
        }

        public void UpdateField(Card[] randomCardsToGuess)
        {
            Card newCard = null;

            for(int i = 0; i < CardPlaces.Length; i++)
            {
                newCard = Instantiate(randomCardsToGuess[i], CardPlaces[i]);
                newCard.Initialize(randomCardsToGuess[i].FrontSide, randomCardsToGuess[i].BackSide);
            }
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
