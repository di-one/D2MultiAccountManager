using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.Core.Controllers
{
    public class GroupController
    {
        public List<GameController> GameControllers = new List<GameController>();
        public GameController Leader;

        public static GroupController Instance;

        private int _index;

        public GroupController()
        {
            Instance = this;
        }

        public void Next()
        {
            _index++;

            if (_index >= GameControllers.Count)
            {
                _index = 0;
            }
        }

        public GameController ActualController => GameControllers[_index];

        public void ReOrder()
        {
            GameControllers = GameControllers.OrderByDescending(x => x.Initiative).ToList();

            string msg = "Re order group : \n";
            for (int i = 0; i < GameControllers.Count; i++)
            {
                msg += $"{GameControllers[i].Name}|{GameControllers[i].Initiative} ";
            }

            System.Console.WriteLine(msg);
        }
    }
}
