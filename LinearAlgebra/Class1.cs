using System;
using System.Collections;

namespace LinearAlgebra
{
    public interface IMathVector : IEnumerable
    {
        /// <summary>
        /// Получить размерность вектора (количество координат).
        /// </summary>
        int Dimensions { get; }

        /// <summary>
        /// Индексатор для доступа к элементам вектора. Нумерация с нуля.
        /// </summary>
        double this[int i] { get; set; }

        /// <summary>Рассчитать длину (модуль) вектора.</summary>
        //double Length { get; }
        //double Lenght { get; }
        /// <summary>Покомпонентное сложение с числом.</summary>
        IMathVector SumNumber(double number);

        /// <summary>Покомпонентное умножение на число.</summary>
        IMathVector MultiplyNumber(double number);

        /// <summary>Сложение с другим вектором.</summary>
        IMathVector Sum(IMathVector vector);

        /// <summary>Покомпонентное умножение с другим вектором.</summary>
        IMathVector Multiply(IMathVector vector);

        /// <summary>Скалярное умножение на другой вектор.</summary>
        double ScalarMultiply(IMathVector vector);

        /// <summary>
        /// Вычислить Евклидово расстояние до другого вектора.
        /// </summary>
        double CalcDistance(IMathVector vector);
    }

    public class MathVector : IMathVector
    {
        private double[] elements;

        public enum Operations
        {
            plus = 1,
            multiply,
            divide,
            distance
        }

        public MathVector()
        {
            elements = new double[0];
        }

        public MathVector (int lenght)
        {
            elements = new double[lenght];
            for (int i = 0; i < lenght; i++)
            {
                elements[i] = 0;
            }
        }

        public MathVector (MathVector A)
        {
            elements = new double[A.Dimensions];
            for (int i = 0; i < A.Dimensions; i++)
            {
                elements[i] = A.elements[i];
            }
        }

        public MathVector (double[] NewElements)
        {
            elements = NewElements;
        }

        public int Dimensions
        {
            get
            {
                return elements.Length;
            }
        }

        public double this[int i]
        { 
            get
            {
                return elements[i];
            }
            set
            {
                elements[i] = value;
            }
        }

        public double Lenght
        {
            get 
            { 
                double result_lenght = 0;
                for (int i = 0; i < Dimensions; i++)
                {
                    result_lenght += this[i] * this[i];
                }
                return Math.Sqrt(result_lenght);
            }
        }

        public IMathVector SumNumber(double number)
        {
            MathVector NewVector = new MathVector(this);
            for (int i = 0; i < Dimensions; i++)
            {
                NewVector[i] += number;
            }
            return NewVector;
        }

        public IMathVector MultiplyNumber(double number)
        {
            MathVector NewVector = new MathVector(this);
            for (int i = 0; i < Dimensions; i++)
            {
                NewVector[i] *= number;
            }
            return NewVector;
        }

        public IMathVector Sum(IMathVector vector)
        {
            MathVector newvector = DoVectorOperations (vector, Operations.plus);
            return newvector;
        }

        public IMathVector Multiply (IMathVector vector)
        {
            MathVector newvector = DoVectorOperations(vector, Operations.multiply);
            return newvector;
        }

        public IMathVector Divide (IMathVector vector)
        {
            MathVector newvector = DoVectorOperations(vector, Operations.divide);
            return newvector;
        }

        public double ScalarMultiply(IMathVector vector)
        {
            double result = 0;
            result = DoNumberOperations(vector, Operations.multiply);
            return result;
        }

        public double CalcDistance(IMathVector vector)
        {
            double result = 0;
            result = DoNumberOperations(vector, Operations.distance);
            result = Math.Sqrt(result);
            return result;
        }

        //обработка операций с 2 векторами, в результате которых возвращается вектор
        public MathVector DoVectorOperations (IMathVector vector, Operations operation)
        {
            MathVector newvector = null;
            if (AreEqvivalent(vector)) {
                newvector = new MathVector(this);
                for (int i = 0; i < Dimensions; i++)
                {
                    newvector[i] = ChooseOperation(this[i], vector[i], operation);
                }
            }
            return newvector;
        }

        //обработка операций с 2 векторами, в результате которых возвращается скаляр
        public double DoNumberOperations (IMathVector vector, Operations operation)
        {
            double result = 0;
            if (AreEqvivalent(vector))
            {
                for (int i = 0; i < Dimensions; i++)
                {
                    result += ChooseOperation(vector[i], this[i], Operations.multiply);
                }
            }
            return result;
        }

        //обработка каждой отедльной операции из двух функций выше
        public double ChooseOperation (double num1, double num2, Operations operation)
        {
            double result = 0;
            switch (operation)
            {
                case Operations.plus:
                    result = num1 + num2;
                    break;
                case Operations.multiply:
                    result = num1 * num2;
                    break;
                case Operations.divide:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
                case Operations.distance:
                      result =  Math.Pow((num1 - num2), 2);
                      break;
            }
            return result;
        }

        //вспомогательный метод, проверяет равенство длин двух векторов
        public bool AreEqvivalent(IMathVector vector)
        {
            return Dimensions == vector.Dimensions;
        }
        /*
        + - покомпонентное сложение с числом или другим вектором
        - - покомпонентное вычитание с числом или другим вектором
        * - покомпонентное умножение с числом или другим вектором
        / - покомпонентное деление с числом или другим вектором
        % - скалярное умножение двух векторов*/

        public static IMathVector operator +(MathVector vector1, MathVector vector2)
        {
            return vector1.Sum(vector2);
        }

        public static IMathVector operator +(MathVector vector, double number)
        {
            return vector.SumNumber(number);
        }

        public static IMathVector operator -(MathVector vector1, MathVector vector2)
        {
            return vector1.Sum(vector2.MultiplyNumber(-1));
        }

        public static IMathVector operator -(MathVector vector, double number)
        {
            return vector.SumNumber((-1) * number);
        }

        public static IMathVector operator *(MathVector vector1, MathVector vector2)
        {
            return vector1.Multiply(vector2);
        }

        public static IMathVector operator *(MathVector vector, double number)
        {
            return vector.MultiplyNumber(number);
        }

        public static IMathVector operator /(MathVector vector1, MathVector vector2)
        {
            return vector1.Divide(vector2);
        }

        public static IMathVector operator /(MathVector vector, double number)
        {
            return vector.MultiplyNumber(1 / number);
        }

        public static double operator % (MathVector vector1, MathVector vector2)
        {
            return vector1.ScalarMultiply(vector2);
        }

        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        //другие варианты функций Divide, Mylptiply, Sum

        /*public MathVector Sum(MathVector vector)
       {
           int minlenght = vector.Dimensions;
           MathVector newvector = new MathVector(this);
           if (Dimensions < vector.Dimensions)
           {
               Array.Resize<double>(ref newvector.elements, vector.Dimensions);
               minlenght = Dimensions;
               for (int i = minlenght; i < newvector.Dimensions; i++)
               {
                   newvector[i] = vector[i];
               }
           }
           for (int i = 0; i < minlenght; i++)
           {
               newvector[i] += vector[i];
           }
           return newvector;
       }


       public void PutBack(double num)
       {
           Array.Resize<double>(ref elements, Dimensions + 1);
           elements[Dimensions - 1] = num;
       }

       MathVector Multiply(MathVector vector)
       {
           MathVector newvector;
           if (Dimensions > vector.Dimensions)
           {
               newvector = MultiplyActions(this, vector);
           }
           else
           {
               newvector = MultiplyActions(vector, this);
           }
           return newvector;     
       }

       //вспомогательная функция для Multiply
       public MathVector MultiplyActions (MathVector vectormore, MathVector vectorless)
       {
           MathVector newvector = new MathVector(vectormore);
           for (int i = 0; i < vectorless.Dimensions; i++)
           {
                  newvector[i] *= vectorless[i];
           }
           for (int i = vectorless.Dimensions; i < vectormore.Dimensions; i++)
           {
               newvector[i] = 0;
           }
           return newvector;
       }

       public MathVector Divide (MathVector vector)
       {
           MathVector newvector = null;
           if (Dimensions > vector.Dimensions)
           {
               newvector = new MathVector(this);
               for (int i = 0; i < vector.Dimensions; i++)
               {
                   newvector[i] /= vector[i];
               }
           }
           return null;
       }*/

        //Один из возможных вариантов сложения векторов - в результате сложения возвращается вектор, состоящий из чисел двух векторов
        /*public MathVector Sum(MathVector vector)
        {
            MathVector newvector = new MathVector(this);
            Array.Resize<double>(ref newvector.elements, Dimensions + vector.Dimensions);
            for (int i = Dimensions - 1; i < vector.Dimensions; i++)
            {
                newvector[i] = vector[i - Dimensions];
            }
            return newvector;
        }*/
    }
}
