public static class GameStats
{
    public static int chestsFound = 0;
    public static int relics = 0;
    public static int traps = 0;
    public static bool keyFound = false;
    //TODO propagate
    public static float finishTime = 0;
    
    public static bool gameOver = false;

    public static void Reset()
    {
        chestsFound = 0;
        relics = 0;
        traps = 0;
        keyFound = false;
        finishTime = 0;
        gameOver = false;
    }
}
