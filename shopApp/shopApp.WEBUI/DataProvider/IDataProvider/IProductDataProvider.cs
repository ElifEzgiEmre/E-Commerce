using shopApp.WEBUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApp.WEBUI.DataProvider.IDataProvider
{
    public interface IProductDataProvider
    {
        string Add(Products products);

        List<Products> GetList();

        Products Get(int id);

        void Edit(Products products);

        void Delete(Products products);
    }
}
