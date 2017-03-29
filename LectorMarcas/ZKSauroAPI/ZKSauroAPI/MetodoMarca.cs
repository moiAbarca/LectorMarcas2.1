using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKSauroAPI
{
    public enum MetodoMarcas
    {
        PF_OR_PW_OR_RF, 
        FP,
        PIN,
        PW,
        RF,
        FP_OR_PW,
        FP_OR_RF,
        PW_OR_RF,
        PIN_AND_FP,
        FP_AND_PW,
        FP_AND_RF,
        PW_AND_RF,
        FP_AND_PW_AND_RF,
        PIN_AND_FP_AND_PW,
        FP_AND_RF_OR_PIN,
        None
    }
}
