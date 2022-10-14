namespace LexiconMVC.Models
{
    public class DoctorModel
    {
        public static string FeverCheck(float fever)
        {
            if (fever >= 37.9) // feber över 37.8 referens https://www.1177.se/sjukdomar--besvar/infektioner/feber/feber/#:~:text=Den%20normala%20kroppstemperaturen%20hos%20vuxna,dig%20svag%20och%20lite%20yr.
                return "You got a fever! Get some rest & drink plenty of fluides to get better soon!";
            else if (fever < 35.9 && fever != 0)
                return "You got hypothermia! Take a hot shower and rest under some blankets to increase your body temperature!";
            else if (fever == 0)
                return "";
            else
                return "Your temperature are normal!";
        }

 

    }
}
