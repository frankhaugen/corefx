﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Xunit.Performance;

namespace System.Numerics.Tests
{
    public static partial class Perf_Vector3
    {
        [Benchmark(InnerIterationCount = VectorTests.DefaultInnerIterationsCount)]
        public static void SubtractOperatorBenchmark()
        {
            var expectedResult = VectorTests.Vector3Value;

            foreach (var iteration in Benchmark.Iterations)
            {
                Vector3 actualResult;

                using (iteration.StartMeasurement())
                {
                    actualResult = SubtractOperatorTest();
                }

                VectorTests.AssertEqual(expectedResult, actualResult);
            }
        }

        public static Vector3 SubtractOperatorTest()
        {
            var result = VectorTests.Vector3Value;

            for (var iteration = 0; iteration < Benchmark.InnerIterationCount; iteration++)
            {
                result -= VectorTests.Vector3Delta;
            }

            return result;
        }
    }
}
