namespace LexiconMVC.Models
{
    public class GuessingGameModel
    {
        public static int RandGenerator() 
        { 
        Random random = new Random();
        int rInt = random.Next(0, 101);
        return rInt;
        }
    }
}
