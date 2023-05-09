using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_event
{
    public class Mathematics
    {
        // delegate 타입 정의 (내부 타입: MulticastDelegate)
        // 관례로 Delegate 접미사 붙임

        // 1. 메서드의 반환값으로 델리게이트를 사용할 수 있다.
        // 2. 메서드의 인자로 델리게이트를 사용할 수 있다.
        // 3. 클래스의 멤버로 델리게이트를 정의할 수 있다.
        public delegate int CalcDelegate(int x, int y);

        static int Add(int x, int y) { return x + y; }
        static int Substract(int x, int y) { return x - y; }
        static int Multiply(int x, int y) { return x * y; }
        static int Divide(int x, int y) { return x / y; }

        CalcDelegate[] methods;

        public CalcDelegate allCalculate;

        public Mathematics()
        {
            methods = new CalcDelegate[]
            {
                Mathematics.Add,
                Mathematics.Substract,
                Mathematics.Multiply,
                Mathematics.Divide
            };

            allCalculate = Mathematics.Add;
            allCalculate += Mathematics.Substract;
            allCalculate += Mathematics.Multiply;
            allCalculate += Mathematics.Divide;
        }

        public void Calculate(char opCode, int operand1, int operand2)
        {
            switch (opCode)
            {
                case '+':
                    Console.WriteLine("+: " + methods[0](operand1, operand2));
                    break;
                case '-':
                    Console.WriteLine("-: " + methods[1](operand1, operand2));
                    break;
                case '*':
                    Console.WriteLine("*: " + methods[2](operand1, operand2));
                    break;
                case '/':
                    Console.WriteLine("/: " + methods[3](operand1, operand2));
                    break;
            }
        }
    }
}
