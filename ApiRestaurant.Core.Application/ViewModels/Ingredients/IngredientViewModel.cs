﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiRestaurant.Core.Application.ViewModels.Ingredients
{
    public class IngredientViewModel
    {

        [EventIgnore]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
