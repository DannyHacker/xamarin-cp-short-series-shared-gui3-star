// Copyright 2019, Danny Hacker, Apache License 2.0, Soli Deo Gloria
using System;
namespace CPTest.Shared
{
    public class Calculate
    {
        private int m_savedValue = 0;

        public Calculate(int init)
        {
            m_savedValue = init;
        } // Calculate()

        public int Add(int inc)
        {
            m_savedValue += inc;
            return m_savedValue;
        } // Add()

        public int PostAdd(int inc)
        {
            var ret = m_savedValue;
            m_savedValue += inc;
            return ret;
        } // PostAdd()
    }
}
