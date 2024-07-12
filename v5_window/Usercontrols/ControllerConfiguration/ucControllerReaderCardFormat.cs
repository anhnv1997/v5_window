using iParkingv5.Objects.Configs;
using iParkingv5.Objects.Enums;
using static iParkingv5.Objects.Enums.CardFormat;

namespace iParkingv5_window.Usercontrols.ControllerConfiguration
{
    public partial class ucControllerReaderCardFormat : UserControl
    {
        #region Properties
        private CardFormatConfig cardFormatConfig;
        private int readerIndex;
        #endregion End Properties

        #region Forms
        public ucControllerReaderCardFormat(CardFormatConfig config)
        {
            InitializeComponent();
            lblReaderName.Text = "Reader " + config.ReaderIndex;
            this.readerIndex = config.ReaderIndex;
            this.cardFormatConfig = config;
            foreach (EmCardFormat item in Enum.GetValues(typeof(CardFormat.EmCardFormat)))
            {
                cbInputFormat.Items.Add(CardFormat.ToString(item));
                cbOutputFormat.Items.Add(CardFormat.ToString(item));
            }
            foreach (EmCardFormatOption item in Enum.GetValues(typeof(CardFormat.EmCardFormatOption)))
            {
                cbConfigOption.Items.Add(CardFormat.ToString(item));
            }
            cbInputFormat.SelectedIndex = (int)this.cardFormatConfig.InputFormat;
            cbOutputFormat.SelectedIndex = (int)this.cardFormatConfig.OutputFormat;
            cbConfigOption.SelectedIndex = (int)this.cardFormatConfig.OutputOption;
        }

        private void UcControllerCardFormat_Load(object? sender, EventArgs e)
        {
          
        }
        #endregion End Forms

        #region Controls In Form

        #endregion End Controls In Form

        #region Private Function

        #endregion End Private Function

        #region Public Function
        public CardFormatConfig GetNewConfig()
        {
            return new CardFormatConfig()
            {
                ReaderIndex = this.readerIndex,
                InputFormat = (EmCardFormat)cbInputFormat.SelectedIndex,
                OutputFormat = (EmCardFormat)cbOutputFormat.SelectedIndex,
                OutputOption = (EmCardFormatOption)cbConfigOption.SelectedIndex,
            };
        }
        #endregion End Public Function
    }
}
