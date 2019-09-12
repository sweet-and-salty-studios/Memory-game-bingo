using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class UIManager : MonoBehaviour
    {
        #region VARIABLES

        public TopField TopField;
        public TargetCardsFieldCenter TargetCardsFieldCenter;
        public TargetCardsField TargetCardsField_Left;
        public TargetCardsField TargetCardsField_Right;

        public UI_Panel GameOverPanel;

        #endregion VARIABLES

        #region PROPERTIES

        public static UIManager Instance
        {
            get;
            private set;
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            if(Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            GameOverPanel.gameObject.SetActive(false);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void OpenGameOverPanel(string endMessage)
        {
            GameOverPanel.gameObject.SetActive(true);
            GameOverPanel.ChangeMessage(endMessage);
        }

        public void CheckFoundedCard(Card card)
        {
            TargetCardsField_Left.ContainsCard(card);
            TargetCardsField_Right.ContainsCard(card);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
