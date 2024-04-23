using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {




        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {

            //withdraw background from currentScreen and change this background accordingly
            this.BackgroundImage = CurrentScreen.background.BackgroundImage;

            // create lists to manage each label and give data accordingly
            Label[] dateLabels = new Label[] { date1, date2, date3, date4, date5, date6, date7 };
            Label[] maxLabels = new Label[] { max1, max2, max3, max4, max5, max6, max7 };
            Label[] minLabels = new Label[] { min1, min2, min3, min4, min5, min6, min7 };
            List<PictureBox> weatherIconList = new List<PictureBox>() { weather1, weather2, weather3, weather4, weather5, weather6, weather7 };

            //display location            
            cityOutput.Text = Form1.days[0].location;

            // display each day of the weeks forecast
            for (int i = 0; i < 7; i++)
            {
                //grab next date, low temp and high temp  and then display each value
                DateTime nextDate = Convert.ToDateTime(Form1.days[i].date);
                dateLabels[i].Text = Convert.ToString(nextDate.DayOfWeek).Substring(0, 3);

                double tHigh = double.Parse(Form1.days[i].tempHigh);
                maxLabels[i].Text = $"{Convert.ToInt16(tHigh)}°";

                double tLow = double.Parse(Form1.days[i].tempLow);
                minLabels[i].Text = $"{Convert.ToInt16(tLow)}°";

            }
            // display a weather forecast for the user
            for (int i = 0; i < 7; i++)
            {
                double weather = Convert.ToDouble(Form1.days[i].condition) / 100;
                switch ((int)weather)
                {
                    case 2: //thunder
                        weatherIconList[i].BackgroundImage = Properties.Resources.thunder_man;

                        break;
                    case 3://drizzle
                        weatherIconList[i].BackgroundImage = Properties.Resources.drizzle_man;

                        break;
                    case 5://rain
                        if (weather <= 500 && weather <= 504)
                        {
                            weatherIconList[i].BackgroundImage = Properties.Resources.cloud_rain_man;

                        }
                        else if (weather == 511)
                        {
                            weatherIconList[i].BackgroundImage = Properties.Resources.freeze_man;

                        }
                        else
                        {
                            weatherIconList[i].BackgroundImage = Properties.Resources.heavy_rain_man;

                        }

                        break;
                    case 6://snow
                        weatherIconList[i].BackgroundImage = Properties.Resources.freeze_man;

                        break;
                    case 7: //clouds
                        weatherIconList[i].BackgroundImage = Properties.Resources.cloud_rain_man;
                        this.BackgroundImage = Properties.Resources.cloudy_rain_background;
                        break;
                    case 8: //clouds
                        if (weather == 8)
                        {
                            weatherIconList[i].BackgroundImage = Properties.Resources.sun_man;

                        }
                        else if (weather == 8.04)
                        {
                            weatherIconList[i].BackgroundImage = Properties.Resources.cloud_rain_man;

                        }
                        else
                        {
                            weatherIconList[i].BackgroundImage = Properties.Resources.cloud_man;

                        }
                        break;
                }


            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
