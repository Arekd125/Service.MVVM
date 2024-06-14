﻿using Service.ViewModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Stores.OrderFiltr
{
    public class SearchOrdersDecorator : FiltrDecorator
    {
        private string _searchText { get; }

        public SearchOrdersDecorator(IFilter filter, string searchText) : base(filter)
        {
            _searchText = searchText;
        }

        public override IEnumerable<OrderDto> GetOrderDtos()
        {
            if (string.IsNullOrEmpty(_searchText))
                return base.GetOrderDtos();

            return base.GetOrderDtos().Where(order => !string.IsNullOrEmpty(order.ContactName) && order.ContactName.ToLower().Contains(_searchText.ToLower())).ToList();
        }
    }
}