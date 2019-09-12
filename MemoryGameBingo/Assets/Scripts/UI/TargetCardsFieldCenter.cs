using TMPro;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class TargetCardsFieldCenter : MonoBehaviour
    {
        #region VARIABLES

        public Transform CurrentTarget;
        public Transform DeckCardsParent;
        public TextMeshProUGUI DeckTotalText;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS      

        public void UpdateField(Card currentCard, string DeckTotalAmount)
        {
            currentCard.transform.SetParent(CurrentTarget);
            currentCard.transform.localPosition = Vector2.zero;
            DeckTotalText.text = DeckTotalAmount;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
