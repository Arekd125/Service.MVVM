using System.ComponentModel;

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