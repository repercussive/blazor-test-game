namespace MyFirstBlazorApp.Logic;

public enum BattleStatus
{
    AwaitingGameStart,
    AwaitingDiceRoll,
    AwaitingPlayerChoice,
    AwaitingOpponentAction,
    OpponentActionSummary,
    PlayerWin,
    OpponentWin
}

public enum PlayerAction
{
    RollDice,
    Attack,
    Heal
}

public class GameManager
{
    public bool IsPlayerTurn { get; private set; } = true;
    public Hero Player { get; private set; } = new Hero("Placeholder", 1);
    public Monster Opponent { get; private set; }
    public int Round { get; private set; } = 1;
    public BattleStatus BattleStatus { get; private set; } = BattleStatus.AwaitingGameStart;
    private bool IsRoundOver { get { return Player.HealthPoints <= 0 || Opponent.HealthPoints <= 0; } }

    public void RegisterPlayer(Hero player)
    {
        Player = player;
    }

    public void StartNewRound()
    {
        SetBattleStatus(BattleStatus.AwaitingDiceRoll);
        Opponent = new Monster("Bob", 10, 2, Player);
        Player.CurrentOpponent = Opponent;
    }

    public void HandlePlayerAction(PlayerAction playerAction)
    {
        if (playerAction == PlayerAction.RollDice)
        {
            Player.RollDice();
            SetBattleStatus(BattleStatus.AwaitingPlayerChoice);
            return;
        }
        else if (playerAction == PlayerAction.Attack)
        {
            Player.Attack();
        }
        else if (playerAction == PlayerAction.Heal)
        {
            Player.Heal();
        }

        if (IsRoundOver) SetBattleStatus(BattleStatus.PlayerWin);
        else SetBattleStatus(BattleStatus.AwaitingOpponentAction);
    }

    public void HandleOpponentTurn()
    {
        Opponent.Attack();

        if (IsRoundOver) SetBattleStatus(BattleStatus.OpponentWin);
        else SetBattleStatus(BattleStatus.OpponentActionSummary);
    }

    public void NextRound()
    {
        Round += 1;
    }

    public void SetBattleStatus(BattleStatus newStatus)
    {
        BattleStatus = newStatus;
    }

    public string GetStatusMessage()
    {
        return BattleStatus switch
        {
            BattleStatus.AwaitingDiceRoll => "You're up! Start by rolling the dice.",
            BattleStatus.AwaitingPlayerChoice => $"You rolled a {Player.DiceRoll}. Choose to attack or heal!",
            BattleStatus.AwaitingOpponentAction => $"{Opponent.Name} is up next!",
            BattleStatus.OpponentActionSummary => $"{Opponent.Name} dealt {Opponent.AttackPower} damage!",
            BattleStatus.PlayerWin => "You won the battle!",
            BattleStatus.OpponentWin => $"{Opponent} won the battle! Game over.",
            _ => "Something is wrong."
        };
    }
}
