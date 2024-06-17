using Service.ViewModel.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace Service.ViewModel.Stores
{
    public class ToDoComparer : IEqualityComparer<ToDoDto>
    {
        public bool Equals(ToDoDto? x, ToDoDto? y)
        {
            if (x == null && y == null)
                return false;
            return x.ToDoName == y.ToDoName && x.Prize == y.Prize;
        }

        public int GetHashCode([DisallowNull] ToDoDto obj)
        {
            if (obj == null) return 0;
            return obj.ToDoName.GetHashCode() ^ obj.Prize.GetHashCode();
        }
    }
}