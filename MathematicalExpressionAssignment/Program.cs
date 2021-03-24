using System;

namespace MathematicalExpressionAssignment
{
    
    //using sigle linkedlist 
    // Declaration of Node
    public class Node
    {
        public float Coefficient { get; set; }

        public int PowerValues { get; set; }

        public Node NextTerm { get; set; }
    }
   
   
    public class MathematicalExpression
    {
        public Node polynomialDegreeFour
        {
            get
            {
                return new Node
                {
                    Coefficient = 3,
                    PowerValues = 4,
                    NextTerm = new Node
                    {
                        Coefficient = -2,
                        PowerValues = 3,
                        NextTerm = new Node
                        {
                            Coefficient = 5,
                            PowerValues = 2,
                            NextTerm = new Node
                            {
                                Coefficient = -6,
                                PowerValues = 1,
                                NextTerm = new Node
                                {
                                    Coefficient = 2,
                                    PowerValues = 0,
                                    NextTerm = null
                                }
                            }
                        }
                    }
                };
            }
        }
        public double ComputeEquation(Node equation, double xVariable)
        {
            double result = 0;

            Node evaluator = equation;

            while (evaluator != null)
            {
                result += evaluator.Coefficient * Math.Pow(xVariable, evaluator.PowerValues);
                evaluator = evaluator.NextTerm;
            }
            return result;
        }
    }

   public class Program
    {
       public static void Main(string[] args)
        {
            MathematicalExpression mathematicalExpression = new MathematicalExpression();
           
            Node polynomialFourthDegreeExpression = mathematicalExpression.polynomialDegreeFour;
            
            Console.WriteLine("The expression, \"3X^4 – 2X^3 + 5X^2 – 6X + 2\" :");

            Console.Write("\nEnter value for xVariable ");

            var xValue = Convert.ToDouble(Console.ReadLine());
            
            var result = mathematicalExpression.ComputeEquation(polynomialFourthDegreeExpression, xValue);
            
            Console.WriteLine("\nThe result of the equation is : " + result);
            
            Console.ReadKey();
        }
    }



















}
