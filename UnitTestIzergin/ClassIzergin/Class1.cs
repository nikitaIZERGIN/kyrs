using System;

namespace ClassPenkin
{
    public class Class1
    {
        public int DiscountPrice(int price)
        {
            int sum = ((price / 100) * 15) * price;
            return sum;
        }
        public string SalaryNotNull(int salary)
        {
            if (salary <= 0 || salary > 100000)
            {
                return "цена не может быть меньше или равана нулю  или больше 100000";
            }
            else
                return "Все правильно";
        }
        
    }
}
