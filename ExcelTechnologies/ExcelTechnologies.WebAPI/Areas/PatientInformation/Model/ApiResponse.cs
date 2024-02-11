﻿namespace ExcelTechnologies.WebAPI.Areas.PatientInformation.Model
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
