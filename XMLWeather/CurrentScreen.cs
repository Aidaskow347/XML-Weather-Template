using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        // display a new background variable to report background to another usercontrol
        public static PictureBox background = new PictureBox();
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            // display city name and current temperature

            cityOutput.Text = Form1.days[0].location;

            double temp = double.Parse(Form1.days[0].currentTemp);
            currentOutput.Text = $"{Convert.ToInt16(temp)}°C";
            // display min temperatures
            double minTemp = double.Parse(Form1.days[0].tempLow);
            minOutput.Text = $"{Convert.ToInt16(minTemp)}°C";
            // display max temperatures
            double maxTemp = double.Parse(Form1.days[0].tempHigh);
            maxOutput.Text = $"{Convert.ToInt16(maxTemp)}°C";

            // create a switch statement that displays the weather and the correct weatherman according to the forecast
            double weather = Convert.ToDouble(Form1.days[0].condition) / 100;
            switch ((int)weather)
            {
                case 2: //thunder
                    weatherIcon.BackgroundImage = Properties.Resources.thunder_man;
                    this.BackgroundImage = Properties.Resources.thunderBG;
                    break;
                case 3://drizzle
                    weatherIcon.BackgroundImage = Properties.Resources.drizzle_man;
                    this.BackgroundImage = Properties.Resources.rainy_background;
                    break;
                case 5://rain
                    if (weather <= 500 && weather <= 504)
                    {
                        weatherIcon.BackgroundImage = Properties.Resources.cloud_rain_man;
                        this.BackgroundImage = Properties.Resources.cloudy_rain_background;
                    }
                    else if (weather == 511)
                    {
                        weatherIcon.BackgroundImage = Properties.Resources.freeze_man;
                        this.BackgroundImage = Properties.Resources.snowy_background;
                    }
                    else
                    {
                        weatherIcon.BackgroundImage = Properties.Resources.heavy_rain_man;
                        this.BackgroundImage = Properties.Resources.rainy_background;
                    }
                    weatherIcon.BackgroundImage = Properties.Resources.rain_man;
                    this.BackgroundImage = Properties.Resources.rainy_background;
                    break;
                case 6://snow
                    weatherIcon.BackgroundImage = Properties.Resources.freeze_man;
                    this.BackgroundImage = Properties.Resources.snowy_background;
                    break;
                case 7: //clouds
                    weatherIcon.BackgroundImage = Properties.Resources.cloud_rain_man;
                    this.BackgroundImage = Properties.Resources.cloudy_rain_background;
                    break;
                case 8: //clouds
                    if (weather == 8)
                    {
                        weatherIcon.BackgroundImage = Properties.Resources.sun_man;
                        this.BackgroundImage = Properties.Resources.sunny_day_background;
                    }
                    else if (weather == 8.04)
                    {
                        weatherIcon.BackgroundImage = Properties.Resources.cloud_rain_man;
                        this.BackgroundImage = Properties.Resources.cloudy_rain_background;
                    }
                    else
                    {
                        weatherIcon.BackgroundImage = Properties.Resources.cloud_man;
                        this.BackgroundImage = Properties.Resources.cloudy_background;
                    }
                    break;
            }
            // display the current weather and report it to backgroundImage
            background.BackgroundImage = this.BackgroundImage;
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
