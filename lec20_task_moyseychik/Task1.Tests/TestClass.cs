using System;
using System.Collections.Generic;

namespace Task1.Tests
{
    [TrackingEntity]
    public class TestClass
    {
        [TrackingProperty]
        public static List<double> Doubles = new()
        {
            -13.7,
            100.01,
            14.44
        };

        public Type TypeProperty { get; set; } = typeof(long);

        [TrackingProperty("Welcome string")]
        public string TrackedString => "Hello world!";
    }
}
