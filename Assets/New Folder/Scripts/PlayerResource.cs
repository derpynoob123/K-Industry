public class PlayerResource
{
    private static int money = 0;
    public static int Money 
    {
        get => money;
        set
        {
            if (value < 0)
            {
                money = 0;
            }
            else
            {
                money = value;
            }
        }
    }
}
