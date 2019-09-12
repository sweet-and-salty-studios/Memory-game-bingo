using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sweet_And_Salty_Studios
{
    public class GameManager : MonoBehaviour
    {
        #region VARIABLES

        public Card CurrentTargetCard;
        public Card GuessedCard;

        [Space]
        [Header("VARIABLES")]
        public Card CardPrefab;
        public Sprite CardBackSprite;
        public Sprite[] CardFrontSprites;

        private int deckTotalAmount;
        private List<Card> deck = new List<Card>();

        private Coroutine iCheckMatch_Coroutine;
        private readonly WaitForSeconds waitForMatch = new WaitForSeconds(2f);

        #endregion VARIABLES

        #region PROPERTIES

        public static GameManager Instance
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
        }

        private void Start()
        {
            CreateDeck();

            SetCardsToGuess();

            SetTargetCardsField(UIManager.Instance.TargetCardsField_Left);
            SetTargetCardsField(UIManager.Instance.TargetCardsField_Right);

            SetCurrentCard();
        }

        private void SetCurrentCard()
        {
            CurrentTargetCard = deck[0];
            deck.RemoveAt(0);

            CurrentTargetCard.Flip();
            UIManager.Instance.TargetCardsFieldCenter.UpdateField(CurrentTargetCard, $"{deck.Count } / { deckTotalAmount}");
        }

        private void SetTargetCardsField(TargetCardsField targetCardsField)
        {
            var randomCards = GetRandomCards(3);

            targetCardsField.UpdateField(randomCards);
        }

        private void SetCardsToGuess()
        {
            var randomCards = GetRandomCards(6);

            UIManager.Instance.TopField.UpdateField(randomCards);
        }

        private Card[] GetRandomCards(int arrayLenght)
        {
            var randomCards = new List<Card>();
            var deckClone = new List<Card>(deck);

            Card randomCard = null;

            for(int i = 0; i < arrayLenght; i++)
            {
                randomCard = deckClone[Random.Range(0, deckClone.Count)];
                deckClone.Remove(randomCard);

                if(randomCards.Contains(randomCard))
                {
                    continue;
                }

                randomCards.Add(randomCard);
            }

            return randomCards.ToArray();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void CreateDeck()
        {
            Sprite frontSprite = null;
            Card newCard = null;

            for(deckTotalAmount = 0; deckTotalAmount < CardFrontSprites.Length; deckTotalAmount++)
            {
                frontSprite = CardFrontSprites[deckTotalAmount];
                newCard = Instantiate(CardPrefab, UIManager.Instance.TargetCardsFieldCenter.DeckCardsParent);
                newCard.Initialize(frontSprite, CardBackSprite);
                deck.Add(newCard);
            }
        }

        public void CheckCardMatch(Card card)
        {
            if(iCheckMatch_Coroutine != null)
            {
                return;
            }

            iCheckMatch_Coroutine = StartCoroutine(ICheckMatch(card));

            if(deck.Count == 0)
            {
                Debug.LogError("No cards left!");
                GameOver("Game Over");
            }
        }

        private void GameOver(string endMessage)
        {
            UIManager.Instance.OpenGameOverPanel(endMessage);
        }

        private IEnumerator ICheckMatch(Card card)
        {
            UIManager.Instance.TopField.CanInteract(false);

            card.Flip();

            if(CurrentTargetCard.name == card.name)
            {
                Debug.LogError("MATCH");

                UIManager.Instance.CheckFoundedCard(CurrentTargetCard);

                yield return waitForMatch;
                card.SetInteractable(false);
            }
            else
            {
                Debug.LogError("NO MATCH");
                yield return waitForMatch;

                card.Flip();
            }

            SetCurrentCard();

            UIManager.Instance.TopField.CanInteract(true);

            if(deck.Count == 0)
            {
                Debug.LogError("No cards left!");
                yield return new WaitForSeconds(4f);
                GameOver("Game Over");
            }

            iCheckMatch_Coroutine = null;
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
