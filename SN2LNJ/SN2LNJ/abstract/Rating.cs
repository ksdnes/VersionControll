using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SN2LNJ.abstractfolder
{
    public abstract class Rating : Button
    {
        public Rating()
        {
            Height = 50;
            Width = 200;

            Click += Rating_Click;
        }

        private void Rating_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show(GetDisplay());
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value;
                Text = _title;
            }
        }

        private string _ratingType;

        public string RatingType
        {
            get { return _ratingType; }
            set {
                _ratingType = value;
                if (RatingType=="PG")
                {
                    BackColor = Color.Green;
                }
                else if (RatingType == "R")
                {
                    BackColor = Color.Red;
                }
                else if (RatingType == "PG")
                {
                    BackColor = Color.Blue;
                }
                else if (RatingType == "PG-13")
                {
                    BackColor = Color.Yellow;
                }
                
                
            }
        }

        protected abstract string GetDisplay();



    }
}
