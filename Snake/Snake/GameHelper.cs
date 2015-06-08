using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Snake
{
    class GameHelper
    {
       private  List<Player> olistPlayer = new List<Player>();
       public GameHelper()
       {

       }
        public  void SaveScore(Player oPlay)
        {
            ConvertTextToList();
            if (olistPlayer.Count > 5)
            {
                int minScore = olistPlayer.Min(p => p.Score);
                var minPlayer = olistPlayer.Where(p => p.Score == minScore).FirstOrDefault();
                olistPlayer.Remove(minPlayer);
                olistPlayer.Add(oPlay);
            }
            else
            {
                olistPlayer.Add(oPlay);
            
            }
            string jsonData = JsonConvert.SerializeObject(olistPlayer);
                       

            using (StreamWriter file = new StreamWriter(@"Score\Scores.txt",false))
            {
                
                file.WriteLine(jsonData);
            }



        }

        private void ConvertTextToList()
        {
            using (StreamReader r = new StreamReader(@"Score\Scores.txt"))
            {
                if (!r.Equals(""))
                {
                    string json = r.ReadToEnd();
                    olistPlayer = JsonConvert.DeserializeObject<List<Player>>(json);
                }
            }
        }
        public static List<Player> GetHighScore()
        { 
            List<Player> olistPlayer = new List<Player>();
            return olistPlayer;
        }
    }
}
