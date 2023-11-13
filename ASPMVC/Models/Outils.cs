namespace ASPMVC.Models
{
    public static class Outils
    {
        public static string CestQuandLaPause(int tempsDePause)
        {
            //Récupérer la date
            DateTime ladate = DateTime.Now;
            //Calculer le temps qui reste pour la pause qui est à 11:10
            DateTime laPause = new DateTime(ladate.Year, ladate.Month, ladate.Day, 11, 15, 00);

            //La différence entre les deux varaible me donne le temps restant , non ????
            string message = "";
            if (ladate > laPause.AddMinutes(tempsDePause))
            {
                message = "La pause est finie";
            }
            else
            {
                if (ladate > laPause && laPause <= ladate.AddMinutes(tempsDePause)) message = "PAUSE!!!!";
                else
                {
                    TimeSpan diff = laPause.Subtract(ladate);
                    message = $"Il vous reste {diff.Days} jour(s) {diff.Hours} heure(s) {diff.Minutes} minute(s) {diff.Seconds} seconde(s) ";
                }
            }
            return message; 
        }
    }
}
