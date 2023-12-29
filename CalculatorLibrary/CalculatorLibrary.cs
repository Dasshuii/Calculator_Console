using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private JsonWriter writer;
        
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string opt)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            switch(opt.ToLower()) 
            {
                case "a":
                    result = Add(num1, num2);
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = Subtraction(num1, num2);
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = Multiply(num1, num2);
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    if (num2 != 0) result = Divide(num1, num2);
                    writer.WriteValue("Divide");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    writer.WriteValue("None");
                    break;
            }
            
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double Add(double num1, double num2) 
        {
            return num1 + num2;
        }

        public double Subtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Multiply(double num1, double num2) 
        {
            return num1 * num2;
        }

        public double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
