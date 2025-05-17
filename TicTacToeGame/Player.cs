using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.TicTacToeGame
{
    public class Player
    {
        public string userName;
        public string userId;
        public Type playerSignType;

        public void setPlayerData(string name, string userId, Type playerSignType)
        {
            this.userId = userId;
            this.userName = name;
            this.playerSignType = playerSignType;
        }
    }
}