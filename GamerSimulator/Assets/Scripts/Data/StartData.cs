using UnityEngine;

namespace Data
{
    public class StartData : MonoBehaviour
    {

        public int _money;
        private const string saveKey = "mainSave";

        public void Initialize()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                Save();
            }
        }

        private void OnDisable()
        {
            Save();
        }

        private void Load()
        {
            var data = SaveManager.Load<Data.GameData>(saveKey);

            _money = data.money;
        }

        private void Save()
        {
            SaveManager.Save(saveKey, GetSaveSnapshot());
            PlayerPrefs.Save();
        }

        public Data.GameData GetSaveSnapshot()
        {
            var data = new Data.GameData()
            {
                money = _money
            };

            return data;
        }
    }
}
