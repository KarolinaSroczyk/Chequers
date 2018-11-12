public static class Globals
{
    public static int PlayersCount;
    public static string[] PlayerNames = { "Player1", "Player2", "Player3", "Player4" };

    public static void SetPlayers(int players)
    {
        PlayersCount = players;
    }
}
