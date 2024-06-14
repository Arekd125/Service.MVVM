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

        [Description("Tydzień")]
        week,

        [Description("Miesiąc")]
        month,

        [Description("Od początku")]
        from_the_beginning,
    };
}