﻿using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public class OpenOrdersDecorator : FiltrDecorator
    {
        public OpenOrdersDecorator(IFilter filter) : base(filter)
        {
        }

        public override IEnumerable<OrderDto> GetOrderDtos()
        {
            return base.GetOrderDtos().Where(o => o.IsFinished == false);
        }
    }
}