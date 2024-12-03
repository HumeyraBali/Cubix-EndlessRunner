using UnityEngine;

[CreateAssetMenu(fileName = "LeaderboardData", menuName = "ScriptableObjects/LeaderboardData", order = 1)]
public class LeaderboardData : ScriptableObject
{
    // The player's score
    [SerializeField] private int score;

    // Property to access the score
    public int Score
    {
        get => score;
        set => score = value;
    }

    // You can add methods to modify the score as needed
    public void AddToScore(int value)
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
