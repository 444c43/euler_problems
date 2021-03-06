﻿using System;
using Extensions;
using System.Collections;
using System.Collections.Generic;
using Services;

namespace EulerProblems
{
    public class Euler03<T> : EulerProblem<T>
    {
        public Euler03()
            : base()
        {
            base.Name = "Euler # 3";
            base.Title = "Largest Prime Factor";
            base.ProblemDescription = new List<string>{
                "The prime factors of 13195 are 5, 7, 13 and 29.",
                "",
                "What is the largest prime factor of the number 600851475143 ?",
            };
            base.EulerInstructions = new List<string>{
                "Let's solve " + Name,
                "\n", "\n",
                "Enter a maximum range value: "};
        }

        public override void EulerMain()
        {
            base.EulerMain();

            long[] IntResults = CalculateValues(ValidateInput());

            Output.DisplayArray(IntResults);
            Output.PauseForUser("Press any key to continue...");
        }

        private long[] CalculateValues(T UserInput)
        {
            long inputValue = (long)Convert.ChangeType(UserInput, typeof(long));

            long[] IntResults = new long[]{
                CalculateIterative(inputValue),
                CalculateEfficient(inputValue)};
            return IntResults;
        }

        private long CalculateIterative(long number)
        {
            long LargestPrime = 0;
            for (long i = number; i >= 2; --i)
            {
                if (number % i == 0 && IsPrime(i))
                {
                    LargestPrime = i;
                    break;
                }
            }
            return LargestPrime;
        }

        private long CalculateEfficient(long number)
        {
            int iteration = 2;
            List<long> list = new List<long>() { 1 };

            while (!ProductOfList(list, number))
            {
                if (number % iteration == 0)
                {
                    list.Add(iteration);
                }
                iteration += 1;
            }
            return 0;
        }

        private static bool ProductOfList(List<long> list, long number)
        {
            int product = 1;
            foreach (int member in list)
            {
                product *= member;
            }
            return (product == number);
        }

        public bool IsPrime(long value)
        {
            if (value == 1) return false;
            if (value == 2) return true;

            for (int i = 2; i < value; ++i)
            {
                if (value % i == 0) return false;
            }

            return true;
        }
    }
}
