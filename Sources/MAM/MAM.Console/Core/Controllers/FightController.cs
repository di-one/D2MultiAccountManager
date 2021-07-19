using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.Core.Controllers
{
    public class FightController
    {
        public IEnumerable<double> Ids { get; set; }
        public IEnumerable<double> DeadsIds { get; set; }

        public List<GameController> AvailablePlayers = new List<GameController>();

        public FightController(List<GameController> players)
        {
            AvailablePlayers = new List<GameController>(players);
        }

        public void Refresh(IEnumerable<double> ids, IEnumerable<double> deadsIds)
        {
            System.Console.WriteLine("[Fight] - Refresh");

            Ids = ids;
            DeadsIds = deadsIds;

            if (deadsIds != null)
            {
                for (int i = 0; i < deadsIds.Count(); i++)
                {
                    GameController find = AvailablePlayers.Find(x => x.ID == deadsIds.ElementAt(i));
                    if (find != null)
                    {
                        System.Console.WriteLine($"[Fight] - Remove player {find.Name}");
                        AvailablePlayers.Remove(find);
                    }
                }
            }
        }
    }
}
