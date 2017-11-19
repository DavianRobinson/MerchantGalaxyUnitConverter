using System.Text;

namespace MerchantGalaxyConverter.Domain
{
    public class GalaxyContext
    {
        private string input;
        private decimal _quantity;
        private string _credits;
        private string _romanOutput;
        private string _output;
        private string _messageRoman;
        public string _previousToken;
        private bool _isKnown = false;
        private const string  UNKNOWMESSAGE= "I have no idea what you are talking about";

        public GalaxyContext(string input)
        {
            this.Input = input;
            this._output = string.Empty;
            _quantity = 0;         
        }
        public string Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
            }
        }

        public string Output
        {
            get
            {
                
                return _output;
            }

            set
            {
                _output=value;        

            }
        }

        public string RomanOutput
        {
            get
            {
                return _romanOutput;
            }

            set
            {
                _romanOutput = value;
            }
        }

        public string Credits
        {
            get
            {
                return _credits;
            }

            set
            {
                _credits = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }

        public string MessageRoman
        {
            get
            {
                return _messageRoman;
            }

            set
            {
                _messageRoman = value;
            }
        }

        public bool IsKnown
        {
            get
            {
                return _isKnown;
            }

            set
            {
                _isKnown = value;
            }
        }

        public void SetUnknown()
        {
            _output = UNKNOWMESSAGE;
        }
    }
}