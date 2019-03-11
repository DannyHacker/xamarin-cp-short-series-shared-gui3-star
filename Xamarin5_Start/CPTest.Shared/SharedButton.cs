// Copyright 2019, Danny Hacker, Apache License 2.0, Soli Deo Gloria
using System;
namespace CPTest.Shared
{
    public class SharedButton
    {
        public enum ControlEvent
        {
            Init,
            Click
        }

        public delegate void HandleButton(ControlEvent control, float x, float y, float width, float height, string text);

        float m_x;
        float m_y;
        float m_width;
        float m_height;
        string m_text;
        HandleButton m_handler;

        public SharedButton()
        {
        }

        public void Init(float x, float y, float width, float height, string text, HandleButton handler)
        {
            m_x = x;
            m_y = y;
            m_width = width;
            m_height = height;
            m_text = text;
            m_handler = handler;
            m_handler?.Invoke(ControlEvent.Init, m_x, m_y, m_width, m_height, m_text);
        }

        Calculate calc = new Calculate(1); //int count = 1;

        public void Click(float x, float y)
        {
            m_text = string.Format("Shared: {0} clicks!", calc.PostAdd(1)); //count++);
            m_handler?.Invoke(ControlEvent.Click, m_x, m_y, m_width, m_height, m_text);
        }
    }
}
