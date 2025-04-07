namespace QueryAssignment.Service
{

    public class HomeService
    {
        public object Add(object num1, object num2, string op)
        {
            if(num1 == null)
            {
                throw new NullReferenceException("Num1 cant be null");
            }
            if(num2 == null) { 
                throw new NullReferenceException("Num2 cant be null");
            }



            dynamic a = num1;
            dynamic b = num2;

            switch (op)
            {
                case "Add":
                    return (a + b);
                case "Substract":
                    return (a - b);
                case "Divide":
                    if (b == 0) { throw new DivideByZeroException("Can not divide by zero"); }
                    if(b > a ) { throw new DivideByZeroException("Divisor can not be greater"); }
                    return (a / b);
                case "Multiply":
                    return (a * b);
                default:
                    throw new InvalidOperationException("Unsupported Operator");


            }

           
        }
       
    }
}
