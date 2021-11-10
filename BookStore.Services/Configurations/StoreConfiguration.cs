using BookStore.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Configurations
{
    public class StoreConfiguration
    {
        public CommonStoreConfiguration StoreA { get; set; }
        public CommonStoreConfiguration StoreB { get; set; }
    }
}
