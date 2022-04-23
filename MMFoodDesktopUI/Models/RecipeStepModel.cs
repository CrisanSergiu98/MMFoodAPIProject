﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Models
{
    public class RecipeStepModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public string StepNumber 
        {
            get
            {
                return $"Step { Number }: ";
            }                
        }
    }
}
