using UnityEngine;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        private FSMScripts.FsmPlayer _player;
        private PlayerStats _playerStats;
        private HomeUIManager UIManager;

        public void Initialize()
        {
            _player = FindAnyObjectByType<FSMScripts.FsmPlayer>();
            _playerStats = FindAnyObjectByType<PlayerStats>();
            UIManager = FindAnyObjectByType<HomeUIManager>();

            SetStatsInUI();

            Debug.Log("PlayerUI initialized");
        }

        public void SetStatsInUI()
        {
            UIManager.satietyText.text = "Сытость: " + _playerStats.Satiety;
            UIManager.cheerfulnessText.text = "Бодрость: " + _playerStats.Cheerfulness;
        }
    }
}
