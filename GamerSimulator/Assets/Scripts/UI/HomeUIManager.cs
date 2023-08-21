using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HomeUIManager : MonoBehaviour
    {
        [Header("Sleep panel")]
        [SerializeField] private GameObject bedPanel;
        [SerializeField] private Button yesSleepButton;
        [SerializeField] private Button noSleepButton;

        [Space(7)]
        [Header("Fridge panel")]
        [SerializeField] private GameObject fridgePanel;
        [SerializeField] private Button yesEatButton;
        [SerializeField] private Button noEatButton;

        public void Initialize()
        {
            InitializeButton();
            Debug.Log("UI initialized");
        }

        private void InitializeButton()
        {
            #region FridgeUI
            if (yesEatButton != null)
            {
                yesEatButton.onClick.RemoveAllListeners();
                yesEatButton.onClick.AddListener(() =>
                {
                    fridgePanel.SetActive(false);
                    Debug.Log("Eat");
                });
            }
            if (noEatButton != null)
            {
                noEatButton.onClick.RemoveAllListeners();
                noEatButton.onClick.AddListener(() =>
                {
                    fridgePanel.SetActive(false);
                });
            }
            #endregion

            #region BedPanel
            if (yesSleepButton != null)
            {
                yesSleepButton.onClick.RemoveAllListeners();
                yesSleepButton.onClick.AddListener(() =>
                {
                    bedPanel.SetActive(false);
                    Debug.Log("Sleep");
                });
            }
            if (noSleepButton != null)
            {
                noSleepButton.onClick.RemoveAllListeners();
                noSleepButton.onClick.AddListener(() =>
                {
                    bedPanel.SetActive(false);
                });
            }
            #endregion
        }

        public void OpenBedPanel()
        {
            bedPanel.SetActive(true);
        }

        public void OpenFridgePanel()
        {
            fridgePanel.SetActive(true);
        }
    }
}
