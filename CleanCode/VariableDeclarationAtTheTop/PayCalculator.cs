namespace CleanCode.VariableDeclarationAtTheTop
{
    class PayCalculator
    {
        public decimal CalcGross(decimal rate, decimal hours)
        {
            decimal overtimeHours = 0;
            decimal regularHours = 0;


            if (_payFrequency == _payFrequency.Fortnightly)
            {
                if (hours > 80)
                {
                    overtimeHours = hours - 80;
                    regularHours = 80;
                }
                else
                {
                    regularHours = hours;
                }
            }
            else if (_payFrequency == _payFrequency.Weekly)
            {
                if (hours > 40)
                {
                    overtimeHours = hours - 40;
                    regularHours = 40;
                }
                else
                {
                    regularHours = hours;
                }
            }


            decimal overtimePay = 0;

            if (overtimeHours > 0m)
            {
                overtimePay += (rate * 1.5m) * overtimeHours;
            }


            var regularPay = (regularHours * rate);
            var grossPay = regularPay + overtimePay;
            return grossPay;
        }
    }
}
