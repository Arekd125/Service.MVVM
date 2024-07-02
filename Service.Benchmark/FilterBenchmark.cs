using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using Service.Model.DbContexts;
using Service.Model.Repositories;
using Servis.Models.OrderModels;
using System.Diagnostics.CodeAnalysis;

namespace Service.Benchmark

{
    public class InProcessConfig : ManualConfig
    {
        public InProcessConfig()
        {
            AddJob(BenchmarkDotNet.Jobs.Job.Default.WithToolchain(InProcessEmitToolchain.Instance));
        }
    }

    [Config(typeof(InProcessConfig))]
    [MemoryDiagnoser]
    public class FilterBenchmark
    {
        public readonly OrdersDbContextFactory ordersDbContextFactory;
        public readonly IOrderRepository repo;
        public readonly IEnumerable<Order> _orderDtos;

        public FilterBenchmark()
        {
            ordersDbContextFactory = new OrdersDbContextFactory("Data Source=serviceDB.db");

            repo = new OrderRepository(ordersDbContextFactory);

            _orderDtos = repo.GetAllOrders().Result;
        }

        [Benchmark]
        public int GetOrderDtos()
        {
            var _searchText = "a";

            IEnumerable<Order> orderDtos = _orderDtos;

            return orderDtos.Where(o => !string.IsNullOrEmpty(o.Contact.Name)
            && o.Contact.Name.Contains(_searchText)
            || o.Contact.PhoneNumber.Contains(_searchText)
            || o.Device.Contains(_searchText)
            || o.Model.Contains(_searchText)
            || o.OrderName.Contains(_searchText)).ToList().Count();
        }

        [Benchmark]
        public int GetOrderDtosAsync()
        {
            var _searchText = "a";

            IEnumerable<Order> orderDtos = _orderDtos;

            var a = orderDtos.Where(o => !string.IsNullOrEmpty(o.Contact.Name) && o.Contact.Name.Contains(_searchText));

            var b = orderDtos.Where(o => o.Contact.PhoneNumber.Contains(_searchText));
            var c = orderDtos.Where(o => o.Device.Contains(_searchText));
            var d = orderDtos.Where(o => o.Model.Contains(_searchText));
            var e = orderDtos.Where(o => o.OrderName.Contains(_searchText));

            var resutl = a.Union(b, new OrderCompare())
                         .Union(c, new OrderCompare())
                         .Union(d, new OrderCompare())
                         .Union(e, new OrderCompare()).ToList();

            return resutl.Count();
        }

        public class OrderCompare : IEqualityComparer<Order>
        {
            public bool Equals(Order? x, Order? y)
            {
                if (x == null && y == null)
                    return false;
                return x.OrderName == y.OrderName;
            }

            public int GetHashCode([DisallowNull] Order obj)
            {
                if (obj == null) return 0;
                return obj.OrderName.GetHashCode();
            }
        }

        [Benchmark]
        public int GetOrderDtosbyID()
        {
            var _searchText = "a";

            IEnumerable<Order> orderDtos = _orderDtos;

            var a = orderDtos.Where(o => !string.IsNullOrEmpty(o.Contact.Name) && o.Contact.Name.Contains(_searchText));

            var b = orderDtos.Where(o => o.Contact.PhoneNumber.Contains(_searchText));
            var c = orderDtos.Where(o => o.Device.Contains(_searchText));
            var d = orderDtos.Where(o => o.Model.Contains(_searchText));
            var e = orderDtos.Where(o => o.OrderName.Contains(_searchText));

            var resutl = a.Union(b, new OrderCompareByID())
                         .Union(c, new OrderCompareByID())
                         .Union(d, new OrderCompareByID())
                         .Union(e, new OrderCompareByID()).ToList();

            return resutl.Count();
        }

        public class OrderCompareByID : IEqualityComparer<Order>
        {
            public bool Equals(Order? x, Order? y)
            {
                if (x == null && y == null)
                    return false;
                return x.Id == y.Id;
            }

            public int GetHashCode([DisallowNull] Order obj)
            {
                if (obj == null) return 0;
                return obj.Id.GetHashCode();
            }
        }
    }
}