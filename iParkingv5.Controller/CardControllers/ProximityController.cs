﻿using iParkingv5.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using static iParkingv5.Controller.CardFactory;

namespace iParkingv5.Controller.CardControllers
{
    class ProximityController : ICardFactory
    {
        private int cardType;

        public ProximityController(int _cardType)
        {
            cardType = _cardType;
        }

        public int CardLen()
        {
            return 3;
        }

        public string GetCardHexNumber(string cardNumber)
        {
            switch (cardType)
            {
                case (int)EM_CardType.Proximity_Left:
                    return Convert.ToInt32(cardNumber).ToString("X6");
                case (int)EM_CardType.ProximityRight:
                    try
                    {
                        string cardNum = cardNumber.Length != 8 ? "" : Convert.ToInt32(cardNumber.Substring(0, 3)).ToString("X2") + Convert.ToInt32(cardNumber.Substring(3, 5)).ToString("X4");
                        return cardNum;
                    }
                    catch
                    {

                        return "";
                    }
                default:
                    return "";
            }
        }
    }
}
