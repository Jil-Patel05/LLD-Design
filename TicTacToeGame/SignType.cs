using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.TicTacToeGame
{
    public class SignType
    {
        Type playerSignType;
        public SignType(Type signType)
        {
            this.playerSignType = signType;
        }
    }

    public class CrossSignType : SignType
    {
        CrossSignType() : base(Type.cross)
        {

        }
    }
    
    public class roundSignType : SignType
    {
        roundSignType() : base(Type.round)
        {
            
        }
    }
}