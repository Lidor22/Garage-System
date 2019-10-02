using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) : base(string.Format("An error accured while trying to fulfill the method.Please be aware that the min value possible is {0} and the max possible is {1}", i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_WrongObejct) : base(string.Format("{0} is inavlid, please enter the two objects again.{0} must be within {1} - {2}", i_WrongObejct, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
