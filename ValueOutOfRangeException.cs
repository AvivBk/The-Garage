using System;


namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private string m_MaxValue;

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValued, float i_MaxValue)
            : base(string.Format("Error: value must be between {0} to {1}", i_MinValued, i_MaxValue),
                i_InnerException)
        { }
        public ValueOutOfRangeException(string message)
            : base(message)
        { }
    }
}
