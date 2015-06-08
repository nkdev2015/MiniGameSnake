using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Prompt
    {
        private TextBox textBox;
        private Form prompt;
      public event  EventHandler clickOK ;
      public Prompt()
      { }
        public  string ShowDialog(string text, string caption)
        {
             prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += confirmation_Click;
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.ShowDialog();
            return textBox.Text;
        }

        private void confirmation_Click(object sender, EventArgs e)
        {
            this.clickOK(sender,e);
        }

        public string GetText()
        {
            return textBox.Text;
        }

        public void Hide()
        {
            prompt.Close();
        }
    }
}
