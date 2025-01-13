using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] private TMP_Text _scoreText;

        [SerializeField] private GameObject warningPopup; // Reference to the warning popup UI
        [SerializeField] private TMP_Text warningText; // Text field to display warning messages

        // Make changes to this section according to how you're storing the player's score:
        // ------------------------------------------------------------
        [SerializeField] private LeaderboardData _leaderboardData;
        
        private int Score => _leaderboardData.Score;
        // ------------------------------------------------------------

        private void Start()
        {
            _leaderboardData.Score = PlayerPrefs.GetInt("HighScore", 0); 
            LoadEntries();
            ScoreText();
        }

        public void UpdateEntries() {
            LoadEntries();
        }


        private void LoadEntries()
        {
            // Q: How do I reference my own leaderboard?
            // A: Leaderboards.<NameOfTheLeaderboard>
        
            Leaderboards.CubixLeaderBoardMaster.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";
                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
        }
        
        public void UploadEntry()
        {
            string username = _usernameInputField.text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                ShowWarning("Username cannot be empty!");
                return;
            }

            // Check for duplicate usernames
            Leaderboards.CubixLeaderBoardMaster.GetEntries(entries =>
            {
                foreach (var entry in entries)
                {
                    if (entry.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase))
                    {
                        ShowWarning("Username is already taken!");
                        return;
                    }
                }

                // If no duplicates, upload the entry
                Leaderboards.CubixLeaderBoardMaster.UploadNewEntry(username, Score, isSuccessful =>
                {
                    if (isSuccessful)
                        LoadEntries();
                });
            });
        }

        public void ScoreText()
        {
            _scoreText.text = $"High Score: {Score}"; 
        }

        public void MainMenuLoad()
        {
            SceneManager.LoadScene(0);
        }

        private void ShowWarning(string message)
        {
            warningText.text = message;
            warningPopup.SetActive(true); // Show the warning popup
        }

        public void HideWarning()
        {
            warningPopup.SetActive(false); // Hide the warning popup
        }
    }
}
