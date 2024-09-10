﻿using iParkingv5.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Controller.CardControllers
{
    public class MifareController : ICardFactory
    {
        private int cardType;
        public MifareController(int _cardType)
        {
            cardType = _cardType;
        }

        public int CardLen()
        {
            return 4;
        }

        public string GetCardHexNumber(string cardNumber)
        {
            try
            {
                return Convert.ToInt32(cardNumber).ToString("X8");
            }
            catch (Exception)
            {
                return cardNumber;
            }
        }
    }
}
