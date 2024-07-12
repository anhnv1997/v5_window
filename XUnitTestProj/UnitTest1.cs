using iParkingv5.Controller;
using iParkingv5.Objects.Configs;

namespace XUnitTestProj
{
    public class UnitTest1
    {
        string baseHexExpected = "9741F1";
        string baseDecExpected = "9912817";
        string baseReHexExpected = "F14197";
        string baseReHexEcpected = "F14197";
        string baseReDecEcpected = "15810967";
        string baseXXX_XXXXXExpected = "151:16881";

        #region INPUT_DEC
        [Fact]
        public void CheckCardDecToDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseDecExpected, config);
            Assert.Equal(baseDecExpected, result);
        }

        [Fact]
        public void CheckCardDecToHex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseDecExpected, config);
            Assert.Equal(baseHexExpected, result);
        }

        [Fact]
        public void CheckCardDecToRehex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseDecExpected, config);
            Assert.Equal(baseReHexEcpected, result);
        }

        [Fact]
        public void CheckCardDecToReDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseDecExpected, config);
            Assert.Equal(baseReDecEcpected, result);
        }

        [Fact]
        public void CheckCardDecToXXX_XXXX()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseDecExpected, config);
            Assert.Equal(baseXXX_XXXXXExpected, result);
        }
        #endregion

        #region INPUT_HEX
        [Fact]
        public void CheckCardHexToDEC()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseHexExpected, config);
            Assert.Equal("9912817", result);
        }

        [Fact]
        public void CheckCardHexToHex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseHexExpected, config);
            Assert.Equal("9741F1", result);
        }

        [Fact]
        public void CheckCardHexToREHEX()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseHexExpected, config);
            Assert.Equal("F14197", result);
        }

        [Fact]
        public void CheckCardHexToReDEC()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseHexExpected, config);
            Assert.Equal("15810967", result);
        }

        [Fact]
        public void CheckCardHexToXXX_XXXX()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseHexExpected, config);
            Assert.Equal("151:16881", result);
        }
        #endregion

        #region INPUT_REHEX
        [Fact]
        public void CheckCardReHexToDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReHexEcpected, config);
            Assert.Equal(baseDecExpected, result);
        }

        [Fact]
        public void CheckCardReHexToHex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReHexEcpected, config);
            Assert.Equal(baseHexExpected, result);
        }

        [Fact]
        public void CheckCardReHexToRehex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReHexEcpected, config);
            Assert.Equal(baseReHexEcpected, result);
        }

        [Fact]
        public void CheckCardReHexToReDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReHexEcpected, config);
            Assert.Equal(baseReDecEcpected, result);
        }

        [Fact]
        public void CheckCardReHexToXXX_XXXX()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReHexEcpected, config);
            Assert.Equal(baseXXX_XXXXXExpected, result);
        }
        #endregion

        #region INPUT_REDEC
        [Fact]
        public void CheckCardReDecToDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReDecEcpected, config);
            Assert.Equal(baseDecExpected, result);
        }

        [Fact]
        public void CheckCardReDecToHex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReDecEcpected, config);
            Assert.Equal(baseHexExpected, result);
        }

        [Fact]
        public void CheckCardReDecToRehex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReDecEcpected, config);
            Assert.Equal(baseReHexEcpected, result);
        }

        [Fact]
        public void CheckCardReDecToReDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReDecEcpected, config);
            Assert.Equal(baseReDecEcpected, result);
        }

        [Fact]
        public void CheckCardReDecToXXX_XXXX()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseReDecEcpected, config);
            Assert.Equal(baseXXX_XXXXXExpected, result);
        }
        #endregion

        #region INPUT_XXX_XXXXX
        [Fact]
        public void CheckCardXXX_XXXXToDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.DECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseXXX_XXXXXExpected, config);
            Assert.Equal(baseDecExpected, result);
        }

        [Fact]
        public void CheckCardXXX_XXXXToHex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.HEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseXXX_XXXXXExpected, config);
            Assert.Equal(baseHexExpected, result);
        }

        [Fact]
        public void CheckCardXXX_XXXXToRehex()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REHEXA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseXXX_XXXXXExpected, config);
            Assert.Equal(baseReHexEcpected, result);
        }

        [Fact]
        public void CheckCardXXX_XXXXToReDec()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.REDECIMA,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseXXX_XXXXXExpected, config);
            Assert.Equal(baseReDecEcpected, result);
        }

        [Fact]
        public void CheckCardXXX_XXXXToXXX_XXXX()
        {
            CardFormatConfig config = new CardFormatConfig()
            {
                InputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputFormat = iParkingv5.Objects.Enums.CardFormat.EmCardFormat.XXX_XXXXX,
                OutputOption = iParkingv5.Objects.Enums.CardFormat.EmCardFormatOption.Type1
            };
            string result = CardFactory.StandardlizedCardNumber(baseXXX_XXXXXExpected, config);
            Assert.Equal(baseXXX_XXXXXExpected, result);
        }
        #endregion
    }
}