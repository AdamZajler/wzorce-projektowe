using System;
using System.Collections.Generic;

public interface IObserver
{
    void UpdateStatus(Dictionary<string, int> scores);
}

public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class Player : IObserver
{
    private string playerName;
    private ISubject gameNotifier;

    public Player(string playerName, ISubject gameNotifier)
    {
        this.playerName = playerName;
        this.gameNotifier = gameNotifier;
        gameNotifier.AddObserver(this);
    }

    public void UpdateStatus(Dictionary<string, int> scores)
    {
        Console.WriteLine($"{playerName}'s updated scores:");
        foreach (var score in scores)
        {
            Console.WriteLine($"Player: {score.Key}, Score: {score.Value}");
        }
        Console.WriteLine();
    }
}

public class Game : ISubject
{
    private List<IObserver> observers;
    private Dictionary<string, int> playerScores;

    public Game()
    {
        observers = new List<IObserver>();
        playerScores = new Dictionary<string, int>();
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.UpdateStatus(playerScores);
        }
    }

    public void SetScore(string playerName, int score)
    {
        if (playerScores.ContainsKey(playerName))
        {
            playerScores[playerName] = score;
        }
        else
        {
            playerScores.Add(playerName, score);
        }
        NotifyObservers();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();

        Player player1 = new Player("Adam", game);
        Player player2 = new Player("John", game);
        Player player3 = new Player("Michael", game);

        game.SetScore("Adam", 10);
        game.SetScore("John", 15);
        game.SetScore("Michael", 8);
        game.SetScore("Adam", 20);

        Console.ReadKey();
    }
}
