using System.Collections.Generic;
using System.ComponentModel;
using EzMacroS.Conditions;

namespace EzMacroS
{
    public class MacroBase
    {
       //обьект который и будет сохраняться и с которым и будет синхронизирована вся программа

       public MacroBase()
       {
           //generate one for fun //todo remove in future mb
          // MacrosList.Add(new MacroUnit());
       }

       public List<MacroUnit> MacrosList = new List<MacroUnit>();

       public BindingList<BaseCondition> ConditionList = new BindingList<BaseCondition>();
       
    }
    
}