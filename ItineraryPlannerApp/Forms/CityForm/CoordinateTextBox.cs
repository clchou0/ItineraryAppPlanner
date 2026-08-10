using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace ItineraryPlannerApp.Forms.CityForm
{
    public class CoordinateTextBox : TextBox
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Cap { get; set; }
        
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            char c = e.KeyChar;
            // True: - is pressed as first char, does not have other -'s like --45
            bool minusHandle = (c == '-') && SelectionStart == 0 && !Text.Contains('-');
            // True: . is the only occurence
            bool decimalHandle = (c == '.') && !Text.Contains('.');

            if (!(char.IsDigit(c) || char.IsControl(c) || minusHandle || decimalHandle))
            {
                e.Handled = true;
            }

        }
        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            bool valid = float.TryParse(Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value)
                && value <= Cap && value >= -Cap;

            BackColor = valid ? Color.White : Color.MistyRose;
        }
        public bool IsValid()
        {
            bool valid = float.TryParse(Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float value)
                && value <= Cap && value >= -Cap;

            return valid;
        }
    }
}
