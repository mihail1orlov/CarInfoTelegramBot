﻿namespace CarInfoCommon.Models
{
    public class CarInfo
    {
        public int Mileage { get; }

        public CarInfo(int mileage)
        {
            Mileage = mileage;
        }
    }
}