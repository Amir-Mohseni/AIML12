public class PerformanceLog
{
    public enum Limit
    {
        True,
        False,
    }
    public static Limit limit = Limit.False;

    private static int blueWonCount = 0;
    private static int purpleWonCount = 0;
    private static int gamesPlayed = 0;

    public static int getBlueWonCount()
    {
        return blueWonCount;
    }

    public static int getGamesPlayed()
    {
        return gamesPlayed;
    }

    public static int getPurpleWonCount()
    {
        return purpleWonCount;
    }

    public static void increaseBlueWonCount()
    {
        blueWonCount++;
        increaseGamesPlayed();
    }

    public static void increasePurpleWonCount()
    {
        purpleWonCount++;
        increaseGamesPlayed();
    }

    public static void increaseGamesPlayed()
    {
        gamesPlayed++;
    }
}

