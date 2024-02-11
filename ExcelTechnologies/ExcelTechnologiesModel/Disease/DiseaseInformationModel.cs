﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologiesModel.Disease
{
    public class DiseaseInformationModel
    {
        [Key]
        public int DiseaseID { get; set; }
        public string DiseaseName { get;set; }
    }
}
