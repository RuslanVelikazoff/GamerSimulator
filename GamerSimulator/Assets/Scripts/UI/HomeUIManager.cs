using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HomeUIManager : MonoBehaviour
    {
        [Header("Tips panel")]
        [SerializeField] private GameObject tipPanel;
        [SerializeField] private GameObject tipFridgeText;
        [SerializeField] private GameObject tipBedText;

        [Space(7)]

        [Header("Sleep panel")]
        [SerializeField] private GameObject bedPanel;
        [SerializeField] private Button yesSleepButton;
        [SerializeField] private Button noSleepButton;

        [Space(7)]

        [Header("Fridge panel")]
        [SerializeField] private GameObject fridgePanel;
        [SerializeField] private Button yesEatButton;
        [SerializeField] private Button noEatButton;

        [Space(7)]

        [Header("Stats panel")]
        [SerializeField] private GameObject statsPanel;
        public Text satietyText;
        public Text cheerfulnessText;

        [Header("Extra")]
        private FSMScripts.FsmPlayer _player;

        public void Initialize()
        {
            _player = FindAnyObjectByType<FSMScripts.FsmPlayer>();

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
                    TipPanel("Fridge", false);
                    _player._fsm.SetState<FSMScripts.FsmStateIdle>();
                });
            }
            #endregion

            #region BedPanel
            if (yesSleepButton != null)
            {
                yesSleepButton.onClick.RemoveAllListeners();
                yesSleepButton.onClick.AddListener(() =>
                {
                    _player._fsm.SetState<FSMScripts.FsmStateSleep>();
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
                    TipPanel("Bed", false);
                    _player._fsm.SetState<FSMScripts.FsmStateIdle>();
                });
            }
            #endregion
        }

        public void OpenBedPanel()
        {
            bedPanel.SetActive(true);
            TipPanel("", false);
        }

        public void OpenFridgePanel()
        {
            fridgePanel.SetActive(true);
            TipPanel("", false);
        }

        public void TipPanel(string itemTag, bool OpenClose)
        {
            tipPanel.SetActive(OpenClose);

            if (itemTag == "Fridge")
            {
                tipFridgeText.SetActive(OpenClose);
            }

            if (itemTag == "Bed")
            {
                tipBedText.SetActive(OpenClose);
            }
        }
    }
}
