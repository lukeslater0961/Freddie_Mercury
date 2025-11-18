using System.Collections;

public interface ILevelInitializer
{
    IEnumerator InitializeLevel();
}

public static class LevelInitializerService
{
    public static ILevelInitializer current;
}
