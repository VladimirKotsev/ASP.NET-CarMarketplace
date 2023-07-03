namespace CarMarketplace.Common
{
    public class EntityValidations
    {
        public static class Car
        {
            public static int YearMaxValue = DateTime.UtcNow.Year;
            public const int YearMinValue = 1886;

            public const int OdometerMaxLength = 7;
            public const int OdometerMinLength = 1;

            public const int OdometerMinValue = 1;

            public const int DescriptionMinLength = 10;

            public const double PriceMaxValue = 1;

            public const int EuroStandartMaxValue = 6;
            public const int EuroStandartMinValue = 1;

            public const int VINNumberFixedLength = 17;
        }

        public class CarManufacturer
        {
            public const int ManufacturerMaxLength = 29;
            public const int ManufacturerMinLength = 2;
        }

        public class CarModel
        {
            public const int ModelMaxLenght = 45;
            public const int ModelMinLenght = 3;
        }

        public static class Engine
        {
            public const int DisplacementMaxValue = 80000;
            public const int DisplacementMinValue = 49;

            public const int HorsepowerMaxValue = 1580;
            public const int HorsePowerMinValue = 2;

            public const double OilCapacityMaxValue = 6;
            public const double OilCapacityMinValue = 0.6;

            public const double CoolantCapacityMaxValue = 4;
            public const double CoolantCapacityMinValue = 0.5;
        }


    }
}