using SN2LNJ.abstractfolder;
using SN2LNJ.FilmRatingsServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SN2LNJ
{
    public partial class Form1 : Form
    {
        List<Rating> _ratings = new List<Rating>();

        string Halloween()
        {
            var filmservice = new ServiceSoapClient();
            var response = filmservice.GetExportWithTitle("Halloween");
            return response;
        }
        public Form1()
        {
            InitializeComponent();
            LoadData();
            DisplayFilms();
        }
        public void LoadData()
        {
            var halloweenData = Halloween();
            var xml = new XmlDocument();
            xml.LoadXml(halloweenData);

            foreach (XmlElement e in xml.DocumentElement)
            {
                /*
                 * így sajnos nem működött
                 * var childelement_name = (XmlElement)e.ChildNodes[0];
                var childelement_rating = (XmlElement)e.ChildNodes[4];
                var childelement_ratingreason = (XmlElement)e.ChildNodes[5];

                var name = childelement_name.InnerText;
                var rating = childelement_rating.InnerText;
                var ratingreason = childelement_ratingreason.InnerText;
                */


                var name = e.SelectSingleNode("name").InnerText;
                var rating = e.SelectSingleNode("rating").InnerText;
                var ratingReason = e.SelectSingleNode("ratingReason").InnerText;


                if (ratingReason=="")
                {
                    var sr = new classes.StandardRating();
                    sr.Title = name;
                    sr.RatingType = rating;
                    _ratings.Add(sr);
                }
                else
                {
                    var dr = new classes.DetailedRating();
                    dr.Title = name;
                    dr.RatingType = rating;
                    dr.RatingReason = ratingReason;
                    _ratings.Add(dr);
                }

            }
        }

        public void DisplayFilms()
        {
            int counter = 0;
            foreach (var item in _ratings)
            {
                
                item.Left = (Size.Width / 2) - (item.Width / 2);
                item.Top = counter + item.Height;
                counter += item.Height;
                Controls.Add(item);
            }
        }
    }
}
