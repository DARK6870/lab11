﻿using lab11.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.ProductsCRUD
{
    public interface IProductRepository
    {
        Task<List<ProductViewModel>> GetAllProducts();
    }
}