﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories;
using WebAPI_for_Anugular_Restaurant.Models;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer
{
    public interface IServiceLayer
    {
        CategoryRepository CategoryList { get; }

        MenuRepository MenuList { get; }

        ProfileRepository ProfileManager { get; }

        void test();
    }
}
