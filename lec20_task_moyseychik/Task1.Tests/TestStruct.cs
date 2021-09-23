namespace Task1.Tests
{
    [TrackingEntity]
    public struct TestStruct
    {
        private int _someInt;

        [TrackingProperty("Bool private field")]
        private bool _trackingBool;

        public TestStruct(int someInt, bool someBool)
        {
            _someInt = someInt;
            _trackingBool = someBool;
        }
    }
}
