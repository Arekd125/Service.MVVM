using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.Converstes
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum DateFilerEnum
    {
        [Description("Dzisja")]
        today,
        [Description("Wczoraj")]
        yesterday,
        [Description("Tyedzień")]
        week,
        [Description("Miesiąc")]
        month,
        [Description("Ostatnie 30 dni")]
        last_30Days,
        [Description("Od początku")]
        from_the_beginning,

    };

}
