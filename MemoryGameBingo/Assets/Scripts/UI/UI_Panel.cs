using TMPro;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class UI_Panel : MonoBehaviour
    {
        #region VARIABLES

        public TextMeshProUGUI EndMessageText;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void ChangeMessage(string endMessage)
        {
            EndMessageText.text = endMessage;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
