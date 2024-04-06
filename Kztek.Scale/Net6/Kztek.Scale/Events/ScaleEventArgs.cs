using System;
using System.Collections.Generic;
using System.Text;

namespace Kztek.Scale_net6.Events
{
    public class ScaleEventArgs : EventArgs
    {
        private int gross;
        private int tare;
        private bool isMinusValue;
        private int decimalValue;
        private bool isStable = true;
        public int Gross
        {
            get
            {
                return gross;
            }
            set
            {
                gross = value;
            }
        }
        public int Tare
        {
            get
            {
                return tare;
            }
            set
            {
                tare = value;
            }
        }
        public bool IsMinusValue
        {
            get
            {
                return isMinusValue;
            }
            set
            {
                isMinusValue = value;
            }
        }
        public int DecimalValue
        {
            get
            {
                return decimalValue;
            }
            set
            {
                decimalValue = value;
            }
        }
        public bool IsStable
        {
            get { return isStable; }
            set { isStable = value; }
        }

    }
}
